using System;
using System.Text;
using System.Net.Sockets;
using System.Windows.Forms;
using Newtonsoft.Json;
using Client.Models;
using System.Net;

namespace Client.Helpers
{
    public static class SocketHelper
    {
        static string ip = "127.0.0.1";
        static int port = 32768;

        public delegate void Execute(object sender);

        public static void DoRequest(Request request, Execute execute)
        {
            TcpClient tcpClient = null;
            try
            {
                tcpClient = new TcpClient(ip, port);
            }
            catch(SocketException ex)
            {
                
            }
            
            try{
                NetworkStream networkStream = tcpClient.GetStream();

                string message = JsonConvert.SerializeObject(request, Formatting.Indented);

                byte[] data = Encoding.Unicode.GetBytes(message);
                networkStream.Write(data, 0, data.Length);
            
                // получаем ответ
                data = new byte[256]; // буфер для получаемых данных
                StringBuilder builder = new StringBuilder();
                int bytes = 0;
                do
                {
                    bytes = networkStream.Read(data, 0, data.Length);
                    builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                }
                while (networkStream.DataAvailable);

                ResponseHandler.Handle(builder.ToString(), (sender) => execute(sender));
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                tcpClient.Close();
            }
        }

        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return null;
        }
    }
}
