using System;
using System.Collections.Generic;

using Client.Models;

namespace Client.Helpers
{
    public static class QuestionHelper
    {
        public static bool isTesting = false;

        public static Models.Client client = new Models.Client()
        {
            ip = SocketHelper.GetLocalIPAddress(),
            pc = Environment.MachineName,
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

        public static int RightQuantity = 0;
        public static int TotalQuestions = 0;
        public static int currentQuestionId = 0;

        public static List<Answer> answers = new List<Answer>();
    }
}
