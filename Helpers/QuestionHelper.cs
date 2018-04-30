using System;
using System.Collections.Generic;
using System.Text;

using Client.Models;

namespace Client.Helpers
{
    public static class QuestionHelper
    {
        public static Models.Client client = new Models.Client()
        {
            ip = SocketHelper.GetLocalIPAddress(),
        };

        private static List<Question> questions = new List<Question>();
        public static List<Question> Questions
        {
            set 
            { 
                questions = value; 
                TotalQuestions = questions.Count;
                currentQuestionId = -1;
            }
            get { return questions; }
        }

        public static Subject currentSubject;
        public static Theme currentTheme;

        public static Question GetNextQuestion()
        {
            currentQuestionId++;
            if(currentQuestionId >= TotalQuestions)
            {
                return null;
            }
            return Questions[currentQuestionId];
        }

        //public static bool isConnected = false;
        //public static bool isQuestionFull = false;

        public static int RightQuantity = 0;
        public static int TotalQuestions = 0;
        public static int currentQuestionId = 0;

        //public static string Get_PCname()
        //{
        //    return PCname;
        //}
        //public static void Set_PCname()
        //{
        //    StreamReader sr = new StreamReader("settings.client");
        //    while (!sr.EndOfStream)
        //    {
        //        string Line = sr.ReadLine();
        //        string[] arr = Line.Split('=');
        //        if (arr[0] == "PCNAME")
        //        {
        //            PCname = arr[1];
        //        }
        //    }
        //    sr.Close();
        //}

        //public static int Get_RightQuantity()
        //{
        //    return RightQuantity;
        //}
        //public static void Set_RightQuantity(int value)
        //{
        //    RightQuantity = value;
        //}

        //public static int Get_TotalQuestions()
        //{
        //    return TotalQuestions;
        //}
        //public static void Set_TotalQuestions(int value)
        //{
        //    TotalQuestions = value;
        //}

        //public static string Get_StudentName()
        //{
        //    return NameStudent;
        //}
        //public static void Set_StudentName(string value)
        //{
        //    NameStudent = value;
        //}

        //public static string Get_StudentSurname()
        //{
        //    return SurnameStudent;
        //}
        //public static void Set_StudentSurname(string value)
        //{
        //    SurnameStudent = value;
        //}

        //public static void Set_Subject(string value)
        //{
        //    Subject = value;
        //}
        //public static string Get_Subject()
        //{
        //    return Subject;
        //}

        //public static void Set_Theme(string value)
        //{
        //    Theme = value;
        //}
        //public static string Get_Theme()
        //{
        //    return Theme;
        //}
    }
}
