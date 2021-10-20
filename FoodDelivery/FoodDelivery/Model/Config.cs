namespace FoodDelivery.Model
{
    public class Config
    {

        public string IpPort { get; set; }
        public string Login { get; set; }
        public string Register { get; set; }
        public string Profile { get; set; }
        public string Restaurants { get; set; }
        public string Products { get; set; }
        public string Product { get; set; }
        public string Command { get; set; }

        public Config(string ipPort, string login, string register, string profile, string restaurants, string products, string product, string command)
        {
            this.IpPort = ipPort;
            this.Login = login;
            this.Register = register;
            this.Profile = profile;
            this.Restaurants = restaurants;
            this.Products = products;
            this.Product = product;
            this.Command = command;
        }

        public Config() { }
    }
}