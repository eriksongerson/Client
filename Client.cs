using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Test_OS
{
    class Client
    {

        public static string[,] Questions = new string[100, 7];

        public static bool isConnected = false;
        public static bool isQuestionFull = false;

        private static string PCname = "";

        private static string NameStudent = "";
        private static string SurnameStudent = "";

        private static string Subject = "";
        private static string Theme = "";

        private static int RightQuantity = 0;
        private static int TotalQuestions = 0;

        private static string IP = "";

        //Немного интерфейсов:
        public static string Get_IP()
        {
            return IP;
        }
        public static void Set_IP()
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

        public static string Get_PCname()
        {
            return PCname;
        }
        public static void Set_PCname()
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

        public static int Get_RightQuantity()
        {
            return RightQuantity;
        }
        public static void Set_RightQuantity(int value)
        {
            RightQuantity = value;
        }

        public static int Get_TotalQuestions()
        {
            return TotalQuestions;
        }
        public static void Set_TotalQuestions(int value)
        {
            TotalQuestions = value;
        }

        public static string Get_StudentName()
        {
            return NameStudent;
        }
        public static void Set_StudentName(string value)
        {
            NameStudent = value;
        }

        public static string Get_StudentSurname()
        {
            return SurnameStudent;
        }
        public static void Set_StudentSurname(string value)
        {
            SurnameStudent = value;
        }

        public static void Set_Subject(string value)
        {
            Subject = value;
        }
        public static string Get_Subject()
        {
            return Subject;
        }

        public static void Set_Theme(string value)
        {
            Theme = value;
        }
        public static string Get_Theme()
        {
            return Theme;
        }

        //Конструктор:
        ~Client()
        {
            Set_IP();
            Set_PCname();
        }
    }
}
