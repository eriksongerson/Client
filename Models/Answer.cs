using System.Collections.Generic;
namespace Client.Models {
    // Класс ответа
    public class Answer {
        public Question question; // Вопрос
        public List<Option> choosen; // Выбранные клиентом варианты ответа
    }
}
