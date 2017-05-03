using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Test_OS
{
    class Client
    {
        
        //ThreadController ThrController = new ThreadController();
        SocketController SocketController = new SocketController();

        public static string[,] Questions = new string[100, 6];

        public static bool isConnected = false;

        private static string PCname = "";

        private static string NameStudent = "";
        private static string SurnameStudent = "";

        private static int RightQuantity = 0;
        private static int TotalQuestions = 0;

        private static string IP = "";

        //Немного интерфейсов:
        public string Get_IP()
        {
            return IP;
        }
        public void Set_IP()
        {
            StreamReader sr = new StreamReader("settings.client");
            while (!sr.EndOfStream)
            {
                string Line = sr.ReadLine();
                string[] arr = Line.Split('=');
                if(arr[0] == "IPADDR")
                {
                    IP = arr[1];
                }
            }
            
            sr.Close();
        }

        public int Get_RightQuantity()
        {
            return RightQuantity;
        }
        public void Set_RightQuantity(int value)
        {
            RightQuantity = value;
        }

        public int Get_TotalQuestions()
        {
            return TotalQuestions;
        }
        public void Set_TotalQuestions(int value)
        {
            TotalQuestions = value;
        }

        public string Get_StudentName()
        {
            return NameStudent;
        }
        public void Set_StudentName(string value)
        {
            NameStudent = value;
        }

        public string Get_StudentSurname()
        {
            return SurnameStudent;
        }
        public void Set_StudentSurname(string value)
        {
            SurnameStudent = value;
        }

        public string Get_PCname()
        {
            return PCname;
        }
        public void Set_PCname()
        {
            StreamReader sr = new StreamReader("settings.client");
            while (!sr.EndOfStream)
            {
                string Line = sr.ReadLine();
                string[] arr = Line.Split('=');
                if (arr[0] == "PCNAME")
                {
                    PCname = arr[1];
                }
            }
            sr.Close();
        }

        //Конструктор:
        public Client()
        {
            Set_IP();
            Set_PCname();
        }

        //public void Handler(string EventIn, string message = null)
        //{
        //    ThrController.CommandThread(true, message);
        //}

        //public void MessageHandler(string message)
        //{
        //    MainForm main = new MainForm();

        //    string[] arr = message.Split(';');

        //    string Query = arr[0];

        //    switch(Query)
        //    {
        //        case "Connect":
        //            {
        //                break;
        //            }
        //        case "Disconnect":
        //            {
        //                break;
        //            }
        //        case "Subjects":
        //            {
        //                main.SubjectHandler(message);
        //                break;
        //            }
        //        case "Themes":
        //            {
        //                string[] Line = message.Split(';');
        //                int l = Line.Length;
        //                for (int i = 1; i < l; i++)
        //                {
        //                    main.comboBox2.Invoke(new MethodInvoker(delegate { main.comboBox2.Items.Add(Line[i]); }));
        //                }
        //                break;
        //            }
        //        case "Questions":
        //            {
        //                string[] Line = message.Split(';');
        //                int l = Line.Length;
        //                for (int i = 1; i < l; i++)
        //                {
        //                    string[] Current = Line[i].Split(':');
        //                        for (int j = 0; j < 6; j++)
        //                    {
        //                        Questions[i, j] = Current[j];
        //                    }
        //                }
        //                break;
        //            }
        //        case "Answer":
        //            {
        //                break;
        //            }
        //    }
        //}

    }
}
