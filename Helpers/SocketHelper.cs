using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

using Client.Models;

namespace Client.Helpers
{
    public class SocketHelper
    {
        static private bool isConnected = false;
        static public bool IsConnected
        {
            set
            {
                isConnected = value;
                if(isConnected == false)
                {
                    if (QuestionHelper.isTesting)
                    {
                        MessageBox.Show("Вы были отключены от сервера. Прогресс тестирования не сохранён. Перезапустите тестирование.");
                        Application.Exit();
                    }
                    else
                    {
                        Request request = new Request()
                        {
                            request = "connect",
                            client = QuestionHelper.client,
                            body = null,
                        };
                        MessageBox.Show("Вы были отключены от сервера");
                        new Thread(() =>
                        {
                            Thread.CurrentThread.IsBackground = true;
                            new SocketHelper().DoRequest(request, (foo) => IsConnected = true);
                        }).Start();
                    }
                }
                else
                {
                    StartListener();
                }
            }
            get => isConnected;
        }

        static public string ip = Properties.Settings.Default.IP;
        static private int port = 32768;
        static private int listenerPort = 32769;

        public delegate void Execute(object sender);

        public static void NotificateIpChanged()
        {
            ip = Properties.Settings.Default.IP;
        }

        public void DoRequest(Request request, Execute execute)
        {
            try
            {
                TcpClient tcpClient = null;
                
                tcpClient = new TcpClient(ip, port);
            
                NetworkStream networkStream = tcpClient.GetStream();

                string message = JsonConvert.SerializeObject(request, Formatting.Indented);

                byte[] data = Encoding.Unicode.GetBytes(message);
                networkStream.Write(data, 0, data.Length);
            
                // получаем ответ
                data = new byte[1_048_576]; // буфер для получаемых данных (1МБ)
                StringBuilder builder = new StringBuilder();
                int bytes = 0;
                do
                {
                    bytes = networkStream.Read(data, 0, data.Length);
                    builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                }
                while (networkStream.DataAvailable);

                new ResponseHandler().Handle(builder.ToString(), (sender) => execute(sender));

                tcpClient.Close();
            }
            catch(SocketException)
            {      
                Thread.Sleep(1000);
                DoRequest(request, execute);
            }
            catch (IOException)
            {  
                Thread.Sleep(1000);
                DoRequest(request, execute);
            }
        }

        public static string GetLocalIPAddress()
        {
            var adresses = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (var item in adresses)
            {
                if(item.AddressFamily == AddressFamily.InterNetwork)
                {
                    return item.ToString();
                }
            }
            return null;
        }

        private static TcpListener tcpListener = new TcpListener(IPAddress.Parse(GetLocalIPAddress()), listenerPort);
        public static void StartListener()
        {
            tcpListener.Start();
            new Thread(() => 
            {
                Thread.CurrentThread.IsBackground = true;
                while (isConnected)
                {
                    TcpClient tcpClient;
                    try
                    {
                        tcpClient = tcpListener.AcceptTcpClient();

                        NetworkStream networkStream = null;
                        byte[] buffer = new byte[1_048_576];
                        try
                        {
                            networkStream = tcpClient.GetStream();

                            StringBuilder stringBuilder = new StringBuilder();
                            int bytes = 0;
                            do
                            {
                                bytes = networkStream.Read(buffer, 0, buffer.Length);
                                stringBuilder.Append(Encoding.Unicode.GetString(buffer, 0, bytes));
                            }
                            while (networkStream.DataAvailable);

                            string message = stringBuilder.ToString();

                            Request request = JsonConvert.DeserializeObject<Request>(message);

                            if (request.request == "disconnect")
                            {
                                IsConnected = false;
                            }

                            Response response = new Response()
                            {
                                response = request.request,
                                body = "OK",
                            };

                            message = JsonConvert.SerializeObject(response, Formatting.Indented);

                            buffer = Encoding.Unicode.GetBytes(message);
                            networkStream.Write(buffer, 0, buffer.Length);
                        }
                        finally
                        {
                            networkStream.Close();
                            tcpClient.Close();
                        }
                    }
                    catch (SocketException)
                    {
                        continue;
                    }
                }
                tcpListener.Stop();
            }).Start();  
        }
    }
}
