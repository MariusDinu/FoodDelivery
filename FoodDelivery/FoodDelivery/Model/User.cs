namespace FoodDelivery.Model
{
    public class User
    {
        public User(string username, string password)
        {
            this.UserName = username;
            this.Password = password;
        }

        public User(string username, string password,string path)
        {
            this.UserName = username;
            this.Password = password;
            this.Path = path;
        }
        public User() { }

        public User(string userName, string email, string password, string path) : this(userName, email, password)
        {
            Path = path;
        }

        public int Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
        public string Path { get; set; }
    }
}