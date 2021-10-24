using System.ComponentModel.DataAnnotations;



namespace FoodDeliveryApi.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public int IdRestaurant { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(100)]
        public string Price { get; set; }
        [Required]
        [MaxLength(100)]
        public string Description { get; set; }
        public string Path { get; set; }
        public Product(int Id, int IdRestaurant, string Name, string Price, string Description)
        {
            this.Id = Id;
            this.IdRestaurant = IdRestaurant;
            this.Name = Name;
            this.Price = Price;
            this.Description = Description;
        }

        public Product(int IdRestaurant, string Name, string Price, string Description)
        {
            this.IdRestaurant = IdRestaurant;
            this.Name = Name;
            this.Price = Price;
            this.Description = Description;
        }

        public Product() { }
    }
}