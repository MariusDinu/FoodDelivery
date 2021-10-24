namespace FoodDelivery.Model
{
    public class Product
    {
        public int Id { get; set; }

        public int IdRestaurant { get; set; }

        public string Name { get; set; }

        public string Price { get; set; }
        public string Description { get; set; }
        public string ImageData { get; set; }
    }
}