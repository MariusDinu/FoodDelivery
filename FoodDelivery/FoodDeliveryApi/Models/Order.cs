using System;
using System.ComponentModel.DataAnnotations;



namespace FoodDeliveryApi.Models
{
    public class Order
    {
        public int Id { get; set; }
        [Required]
        public int IdUser { get; set; }
        [Required]
        public int IdRestaurant { get; set; }
        [Required]
        [MaxLength(100)]
        public string Products { get; set; }
        [Required]
        [MaxLength(100)]
        public string Price { get; set; }
        [Required]
        [MaxLength(100)]
        public string Location { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public string Status { get; set; }

        public Order(int Id, int IdUser, int IdRestaurant, string Products, string Price, string Location, DateTime CreatedAt, string Status)
        {
            this.Id = Id;
            this.IdUser = IdUser;
            this.IdRestaurant = IdRestaurant;
            this.Products = Products;
            this.Price = Price;
            this.Location = Location;
            this.CreatedAt = CreatedAt;
            this.Status = Status;
        }

        public Order(int IdUser, int IdRestaurant, string Products, string Price, string Location, DateTime CreatedAt, string Status)
        {
            this.IdRestaurant = IdRestaurant;
            this.IdUser = IdUser;
            this.Products = Products;
            this.Price = Price;
            this.Location = Location;
            this.CreatedAt = CreatedAt;
            this.Status = Status;
        }



        public Order() { }

    }
}