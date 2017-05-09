using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace Test_OS
{
    public partial class MainForm : Form
    {

        //Client client = new Client();

        private int port = 12345;
        private static string InputMessage = "";

        public static Thread FirstThread;
        public static Thread SecondThread;
        public static Thread ThirdThread;
        public static Thread FourthThread;

        public MainForm()
        {
            InitializeComponent();
        }

        public void MainForm_Load(object sender, EventArgs e)
        {
            Client.Set_IP();
            Client.Set_PCname();

            FirstThread = new Thread(new ThreadStart(MultiSocket));
            InputMessage = Client.Get_IP() + ":" + Client.Get_PCname() + ":" + "Subjects";
            FirstThread.Start();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SecondThread = new Thread(new ThreadStart(MultiSocket));
            InputMessage = Client.Get_IP() + ":" + Client.Get_PCname() + ":" + "Themes:" + comboBox1.Text;
            SecondThread.Start();
            comboBox2.Enabled = true;
        }

        private void qStartTest_Click(object sender, EventArgs e)
        {
            //Даём задание для одного сокета, чтобы он отсылал сообщение о том, что хотим подключиться
            ThirdThread = new Thread(new ThreadStart(MultiSocket));
            InputMessage = Client.Get_IP() + ":" + Client.Get_PCname() + ":" + "Connect";
            ThirdThread.Start();

            //Даём задание другому сокету, чтобы он попросил у сервера вопросы
            FourthThread = new Thread(new ThreadStart(MultiSocket));
            while (!Client.isConnected) ;
            InputMessage = Client.Get_IP() + ":" + Client.Get_PCname() + ":" + "Questions:" + comboBox1.Text + ":" + comboBox2.Text;
            FourthThread.Start();
            while (!Client.isQuestionFull) ;

            Client.Set_StudentName(qNameStud.Text);
            Client.Set_StudentSurname(qFamStud.Text);

            

            TestingForm tf = new TestingForm();
            this.Hide();
            tf.Show();
        }

        private void qEndApp_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            isFill();
        }

        private void isFill()
        {
            if (comboBox2.SelectedItem != null && qFamStud.Text != "" && qNameStud.Text != "" && comboBox1.SelectedItem != null)
            {
                qStartTest.Enabled = true;
            }
            else
            {
                qStartTest.Enabled = false;
            }
        }

        private void qFamStud_TextChanged(object sender, EventArgs e)
        {
            isFill();
        }

        private void qNameStud_TextChanged(object sender, EventArgs e)
        {
            isFill();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChangeIP chIP = new ChangeIP();
            chIP.Show();
        }

        public void MultiSocket()
        {
            
            string message = InputMessage;
            InputMessage = null;
            m:
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

                MessageHandler(builder.ToString());

            }
            catch (Exception ex)
            {
                //socket.Shutdown(SocketShutdown.Both);
                socket.Close();
                goto m;
            }

        }

        public void MessageHandler(string message)
        {
            string[] arr = message.Split(';');

            string Query = arr[0];

            switch (Query)
            {
                case "Connect":
                    {
                        string[] arr2 = arr[1].Split(':');
                        if(arr2[1] == "Connected")
                        {
                            Client.isConnected = true;
                        }
                        break;
                    }
                //case "Disconnect":
                //    {
                //        break;
                //    }
                case "Subjects":
                    {

                        comboBox1.Invoke(new MethodInvoker(delegate { comboBox1.Items.Clear(); }));
                        comboBox1.Invoke(new MethodInvoker(delegate { comboBox1.Text = ""; }));

                        string[] Line = message.Split(';');
                        int l = Line.Length;

                        for (int i = 1; i < l; i++)
                        {
                            comboBox1.Invoke(new MethodInvoker(delegate { comboBox1.Items.Add(Line[i]); }));
                        }
                        break;
                    }
                case "Themes":
                    {

                        comboBox2.Invoke(new MethodInvoker(delegate { comboBox2.Items.Clear(); }));
                        comboBox2.Invoke(new MethodInvoker(delegate { comboBox2.Text = ""; }));

                        string[] Line = message.Split(';');
                        int l = Line.Length;
                        for (int i = 1; i < l; i++)
                        {
                            comboBox2.Invoke(new MethodInvoker(delegate { comboBox2.Items.Add(Line[i]); }));
                        }
                        break;
                    }
                case "Questions":
                    {
                        string[] Line = arr[1].Split(';');
                        int l = Line.Length;
                        Client.Set_TotalQuestions(l);
                        for (int i = 0; i < l; i++)
                        {
                            string[] Current = Line[i].Split('@');
                            for (int j = 0; j < 7; j++)
                            {
                                Client.Questions[i, j] = Current[j];
                            }
                        }

                        Client.isQuestionFull = true;

                        break;
                    }
                //case "Answer":
                //    {

                //        break;
                //    }
            }   
        }

    }
}