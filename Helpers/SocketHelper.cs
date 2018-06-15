using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using Newtonsoft.Json;
using Client.Models;
namespace Client.Helpers {
    // Класс SocketHelper позволяет отправлять запросы
    public class SocketHelper {
        // Буёвая переменная соединения
        static private bool isConnected = false;
        // Свойство для поля соединения
        static public bool IsConnected {
            set {
                isConnected = value;
                // Если нас вдруг отключили 
                if(isConnected == false) {
                    if (QuestionHelper.isTesting) {
                        // Если ещё и прямо во время тестирования
                        // То надо бы сообщить, что прогресс-то не сохранён
                        MessageBox.Show("Вы были отключены от сервера. Прогресс тестирования не сохранён. Перезапустите тестирование.");
                        Application.Exit();
                    } else {
                        // Иначе просто отправить запрос на соединение
                        Request request = new Request() {
                            request = "connect",
                            client = QuestionHelper.client,
                            body = null,
                        };
                        // И сказать "ну чё, ты отключен"
                        MessageBox.Show("Вы были отключены от сервера");
                        // А потом отправить запрос и посмотреть что будет дальше
                        new Thread(() => {
                            Thread.CurrentThread.IsBackground = true;
                            new SocketHelper().DoRequest(request, (foo) => IsConnected = true);
                        }).Start();
                    }
                } else {
                    // Иначе просто перейти в режим сервера и слушать от него сообщений
                    StartListener();
                }
            }
            get => isConnected;
        }
        // Это у нас ip сервера
        static public string ip = Properties.Settings.Default.IP;
        // Это порт прослушивания на стороне сервера 
        static private int port = 32768;
        // А это на стороне клиента
        static private int listenerPort = 32769;
        public delegate void Execute(object sender);
        // Эта функция говорит нам, что клиент изменил ip-шник сервера
        public static void NotificateIpChanged() {
            ip = Properties.Settings.Default.IP;
        }
        // Функция отправки запроса
        public void DoRequest(Request request, Execute execute) {
            TcpClient tcpClient = null;
            NetworkStream networkStream = null;
            try {
                // Пытаемся подключиться к серверу
                tcpClient = new TcpClient(ip, port);
                // Получаем с ним соединение
                networkStream = tcpClient.GetStream();
                // Конвертируем наш запрос
                string message = JsonConvert.SerializeObject(request, Formatting.Indented);
                // Передаём сначала в массив байтов
                byte[] data = Encoding.Unicode.GetBytes(message);
                // А затем оттуда в соединение.
                // Как в бездну кидаем слова и ждём, что нам оттуда плюнут другими словами
                networkStream.Write(data, 0, data.Length);
                // получаем ответ
                data = new byte[1_048_576]; // буфер для получаемых данных (1МБ)
                StringBuilder builder = new StringBuilder();
                int bytes = 0;
                // Всё ещё получаем ответ
                do {
                    bytes = networkStream.Read(data, 0, data.Length);
                    builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                }
                while (networkStream.DataAvailable);
                // И получили ответ, надо его отправить обработчику
                new ResponseHandler().Handle(builder.ToString(), (sender) => execute(sender));
                // Закрываем соединение и сокет
                networkStream.Close();
                tcpClient.Close();
            }
            catch (SocketException)
            {
                // Если запрос не получается отправить, пытаемся снова и снова
                networkStream?.Close();
                tcpClient?.Close();
                DoRequest(request, execute);
            }
        }
        // Функция получения локального ip-адреса
        public static string GetLocalIPAddress() {
            var adresses = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (var item in adresses) {
                if(item.AddressFamily == AddressFamily.InterNetwork) {
                    return item.ToString();
                }
            }
            return null;
        }
        // новый сокет. С помощью него становимся сервером ненадолго
        private static TcpListener tcpListener = new TcpListener(IPAddress.Parse(GetLocalIPAddress()), listenerPort);
        // Начинаем прослушивать соединения
        public static void StartListener() {
            tcpListener.Start();
            new Thread(() => {
                Thread.CurrentThread.IsBackground = true;
                while (isConnected) {
                    TcpClient tcpClient;
                    try {
                        // при подключении
                        tcpClient = tcpListener.AcceptTcpClient();
                        // Ловим соединение
                        NetworkStream networkStream = null;
                        byte[] buffer = new byte[1_048_576];
                        try {
                            // Поймали соединение
                            networkStream = tcpClient.GetStream();
                            // Получаем сообщение
                            StringBuilder stringBuilder = new StringBuilder();
                            int bytes = 0;
                            do {
                                bytes = networkStream.Read(buffer, 0, buffer.Length);
                                stringBuilder.Append(Encoding.Unicode.GetString(buffer, 0, bytes));
                            }
                            while (networkStream.DataAvailable);
                            string message = stringBuilder.ToString();
                            // Конвертируем в объект
                            Request request = JsonConvert.DeserializeObject<Request>(message);
                            // Читаем его. Если нас пытаются отключить, что поделать, отключаемся
                            if (request.request == "disconnect") {
                                IsConnected = false;
                            }
                            // Пишем ответ
                            Response response = new Response() {
                                response = request.request,
                                body = "OK",
                            };
                            // Конвертируем в одну строку и отправляем
                            message = JsonConvert.SerializeObject(response, Formatting.Indented);
                            // Записываем сообщение в соединение.
                            buffer = Encoding.Unicode.GetBytes(message);
                            networkStream.Write(buffer, 0, buffer.Length);
                        }
                        finally {
                            // Закрываем соединение и сокет
                            networkStream.Close();
                            tcpClient.Close();
                        }
                    }
                    catch (SocketException) { continue; }
                }
                // Останавливаем прослушивание
                tcpListener.Stop();
            }).Start();  
        }
    }
}
