namespace Client.Models {
    // Класс Предмета
    public class Subject {
        int id; // id предмета
        string name; // название предмета
    
        public int Id
        {
            get => id;
            set => id = value;
        }
        public string Name
        {
            get => name;
            set => name = value;
        }
    }
}
