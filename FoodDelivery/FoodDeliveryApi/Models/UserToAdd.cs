namespace FoodDeliveryApi.Models
{
    public class UserToAdd
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string ImageData { get; set; }
        public UserToAdd() { }

        public UserToAdd(string imageData)
        {

            ImageData = imageData;
        }

        public UserToAdd(string userName, string email, string password, string imageData)
        {
            Email = email;
            UserName = userName;
            Password = password;
            ImageData = imageData;
        }
        public UserToAdd(string userName, string email, string imageData)
        {
            Email = email;
            UserName = userName;

            ImageData = imageData;
        }
    }
}
