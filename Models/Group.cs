namespace Client.Models
{
    public class Group
    {
        int id;
        string name;

        public int Id
        {
            set => id = value;
            get => id;
        }
        public string Name
        {
            set => name = value;
            get => name;
        }
    }
}
