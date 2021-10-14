using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;



namespace FoodDeliveryApi.Models
{
    public class Order
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public int IdUser { get; set; }
        [Required]
        [MaxLength(100)]
        public int IdRestaurant { get; set; }
      
        public string Products { get; set; }
        [Required]
        [MaxLength(100)]
        public string Price { get; set; }
        [Required]
        [MaxLength(100)]
        public string Location { get; set; }

        public Order(int Id, int IdUser, int IdRestaurant, string Products, string Price, string Location)
        {
            this.Id = Id;
            this.IdUser = IdUser;
            this.IdRestaurant = IdRestaurant;
            this.Products = Products;
            this.Price = Price;
            this.Location = Location;
        }

        public Order(int IdUser,int IdRestaurant, string Products, string Price, string Location)
        {
            this.IdRestaurant = IdRestaurant;
            this.IdUser = IdUser;
            this.Products = Products;
            this.Price = Price;
            this.Location = Location;
        }

       
    }
}