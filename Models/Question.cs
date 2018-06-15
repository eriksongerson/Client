using System.Collections.Generic;
namespace Client.Models {
    // Класс вопроса
    public class Question {
        int id; // id вопроса
        int id_subject; // id предмета
        int id_theme; // id темы
        string name; // вопрос
        List<Option> options; // список вариантов ответа
        Type type; // Тип вопроса
        // свойство поля вопроса
        public string Name {
            set => this.name = value;
            get => this.name;
        }
        // Свойство вариантов ответа
        public List<Option> Options {
            set => this.options = value;
            get => this.options;
        }
        // Свойство типа вопроса
        public Type Type {
            set => this.type = value;
            get => this.type;
        }
    }
}
