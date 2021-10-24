using System.ComponentModel.DataAnnotations;



namespace FoodDeliveryApi.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string RestaurantName { get; set; }
        [Required]
        [MaxLength(100)]
        public string Street { get; set; }
        [Required]
        [MaxLength(100)]
        public string StreetNumber { get; set; }
        [Required]
        [MaxLength(100)]
        public string Building { get; set; }
        public string Path { get; set; }

        public Restaurant(int Id, string RestaurantName, string Street, string StreetNumber, string Building)
        {
            this.Id = Id;
            this.RestaurantName = RestaurantName;
            this.Street = Street;
            this.StreetNumber = StreetNumber;
            this.Building = Building;
        }
        public Restaurant(string RestaurantName, string Street, string StreetNumber, string Building)
        {
            this.RestaurantName = RestaurantName;
            this.Street = Street;
            this.StreetNumber = StreetNumber;
            this.Building = Building;
        }
        public Restaurant() { }
    }

}