namespace Client.Models {
    // Класс группы
    public class Group {
        int id; // id группы
        string name; // название группы
        // свойство поля id
        public int Id {
            set => id = value;
            get => id;
        }
        // свойство поля имени
        public string Name {
            set => name = value;
            get => name;
        }
    }
}
