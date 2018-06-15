using System;
using System.Collections.Generic;
using Client.Models;
namespace Client.Helpers {
    // Класс управления информацией текущего тестирования
    public static class QuestionHelper {
        public static bool isTesting = false;
        // Объект клиента
        public static Models.Client client = new Models.Client()
        {
            // Для него нужен ip-адрес
            ip = SocketHelper.GetLocalIPAddress(),
            // И имя ПК
            pc = Environment.MachineName,
        };
        // Список вопросов
        private static List<Question> questions = new List<Question>();
        // Свойство класса под поле вопросов
        public static List<Question> Questions {
            set { 
                questions = value; 
                TotalQuestions = questions.Count;
                currentQuestionId = -1;
            }
            get { return questions; }
        }
        // Выбранные предмет и тема
        public static Subject currentSubject;
        public static Theme currentTheme;
        // Метод получения следующего вопроса
        public static Question GetNextQuestion() {
            currentQuestionId++;
            if(currentQuestionId >= TotalQuestions) {
                return null;
            }
            return Questions[currentQuestionId];
        }
        // Переменные хранения информации о тестировании
        // Количество правильных ответов
        public static int RightQuantity = 0;
        // Количество вопросов в тесте
        public static int TotalQuestions = 0;
        // Текущий id вопроса
        public static int currentQuestionId = 0;
        // Список ответов 
        public static List<Answer> answers = new List<Answer>();
    }
}
