namespace Client.Models {
    // Класс варианта ответа
    public class Option {
        public int id; // id ответа
        public int id_question; // id вопроса соответствующего варианту ответа
        public string option; // название ответа
        public bool isRight; // верный ли ответ
        // Конструктор
        public Option(){ }
        // Перегруженный итератор
        public static implicit operator string(Option v) => v.option;
    }
}
