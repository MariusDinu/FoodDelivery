namespace FoodDelivery.Model
{
    public class UserToSend
    {
        public UserToSend(string imageData)
        {
            ImageData = imageData;
        }
        public UserToSend() { }

        public UserToSend(string userName, string email, string password, string imageData)
        {
            UserName = userName;
            Email = email;
            Password = password;
            ImageData = imageData;
        }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string ImageData { get; set; }
    }
}