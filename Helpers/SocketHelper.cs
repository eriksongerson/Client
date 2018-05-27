using System.Text;
using System.Net.Sockets;
using Newtonsoft.Json;
using Client.Models;
using System.Net;
using System.Threading;
using System.IO;

namespace Client.Helpers
{
    public class SocketHelper
    {
        static public string ip = Properties.Settings.Default.IP;
        static int port = 32768;

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
                //tcpClient?.Close(); 
                Thread.Sleep(1000);
                DoRequest(request, execute);
            }
            catch (IOException)
            {
                //tcpClient?.Close();
                Thread.Sleep(1000);
                DoRequest(request, execute);
            }
        }

        public static string GetLocalIPAddress()
        {
            //var host = Dns.GetHostEntry(Dns.GetHostName());
            var adresses = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (var item in adresses)
            {
                if(item.AddressFamily == AddressFamily.InterNetwork)
                {
                    return item.ToString();
                }
            }
            //foreach (var ip in host.AddressList)
            //{
            //    if (ip.AddressFamily == AddressFamily.InterNetwork)
            //    {
            //        return ip.ToString();
            //    }
            //}
            return null;
        }
    }
}
