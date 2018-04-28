using System;
//using System.Collections.Generic;
using System.ComponentModel;
//using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net.Sockets;
using System.Net;

namespace Client
{
    public partial class FinishTestingForm : Form
    {

        //Client client = new Client();
        Thread T = null;

        public FinishTestingForm()
        {
            InitializeComponent();
        }

        private void qExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FinishTestingForm_Load(object sender, EventArgs e)
        {
            qF.Text = Client.Get_StudentSurname();
            qN.Text = Client.Get_StudentName();
            qResult.Text = Convert.ToString(Client.Get_RightQuantity());

            double Percent = Client.Get_RightQuantity() / Client.Get_TotalQuestions();
            int Mark = 2;

            if (0.5 > Percent)
            {
                Mark = 2;
                label4.Text = "2";
            }
            
            if (Percent >= 0.5 && Percent > 0.75)
            {
                Mark = 3;
                label4.Text = "3";
            }
            
            if (Percent >= 0.75 && Percent < 0.875)
            {
                Mark = 4;
                label4.Text = "4";
            }
            
            if (Percent >= 0.875 && Percent <= 100)
            {
                Mark = 5;
                label4.Text = "5";
            }

            string message = Client.Get_IP() + ":" + Client.Get_PCname() + ":" + "Completed" + ":" + Client.Get_StudentSurname() + ":" + Client.Get_StudentName() + ":" + Client.Get_Subject() + ":" + Client.Get_Theme() + ":" + Mark;

            T = new Thread(delegate() 
            {
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

                    if(builder.ToString() == "Completed;" + Client.Get_PCname() + ":Complited")
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
            });

            T.Start();

            while (!T.IsAlive) ;

       }
    }
}