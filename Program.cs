using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace Test_OS
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if(Client.Get_IP() == "" || Client.Get_PCname() == "")
            {
                Application.Run(new ChangeIP());
                Application.Run(new MainForm());
            }
            else
            {
                Application.Run(new MainForm());
            }

            if (MainForm.FirstThread != null && MainForm.FirstThread.IsAlive) 
                MainForm.FirstThread.Abort();
            if(MainForm.SecondThread != null && MainForm.SecondThread.IsAlive)
                MainForm.SecondThread.Abort();
            if(MainForm.ThirdThread != null && MainForm.ThirdThread.IsAlive)
                MainForm.ThirdThread.Abort();
            if(MainForm.FourthThread != null && MainForm.FourthThread.IsAlive)
                MainForm.FourthThread.Abort();

            while ((MainForm.FirstThread != null && MainForm.FirstThread.IsAlive) || (MainForm.SecondThread != null && MainForm.SecondThread.IsAlive) || (MainForm.ThirdThread != null && MainForm.ThirdThread.IsAlive) || (MainForm.FourthThread != null && MainForm.FourthThread.IsAlive)) ;

            if(Client.isConnected == true)
            {

                string message = Client.Get_IP() + ":" + Client.Get_PCname() + ":Disconnect";

                m:
                int port = 12345;
                Socket socket = null;
                Client.Set_IP();
                string IP = Client.Get_IP();
                try
                {
                    IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(IP), port);

                    socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                    socket.Connect(ipPoint);

                    byte[] data = Encoding.Unicode.GetBytes(message);

                    socket.Send(data);

                    data = new byte[256];
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0;

                    do
                    {
                        bytes = socket.Receive(data, data.Length, 0);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (socket.Available > 0);

                    socket.Shutdown(SocketShutdown.Both);
                    socket.Close();

                    if (builder.ToString() == "Disconnect;" + Client.Get_PCname() + ":Disconnected")
                    {
                        Client.isConnected = false;
                    }

                }
                catch (Exception ex)
                {
                    //socket.Shutdown(SocketShutdown.Both);
                    socket.Close();
                    goto m;
                }
            }

            Environment.Exit(1);
        }
    }
}