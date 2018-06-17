namespace Client.Models {
    // Класс 
    public class Theme {
        int id; // id темы
        int id_subject; // id предмета
        string name; // название предмета
        public int Id
        {
            get => id;
            set => id = value;
        }
        public int SubjectId
        {
            get => id_subject;
            set => id_subject = value;
        }
        public string Name
        {
            get => name;
            set => name = value;
        }
    }
}
