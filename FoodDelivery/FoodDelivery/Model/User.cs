namespace FoodDelivery.Model
{
    public class User
    {
        public User(string username, string email, string password)
        {
            this.UserName = username;
            this.Email = email;
            this.Password = password;
        }
        public User(string username, string password)
        {
            this.UserName = username;
            this.Password = password;
        }

        public User() { }
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}