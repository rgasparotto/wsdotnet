namespace wsTest.Models.Data
{
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public User(int i, string n, string e)
        {
            this.id = i;
            this.name = name;
            this.email = e;
        }
    }
}
