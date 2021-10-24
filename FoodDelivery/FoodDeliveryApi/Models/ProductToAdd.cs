using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDeliveryApi.Models
{
    public class ProductToAdd
    {
        public ProductToAdd(int id,int idRestaurant, string name, string price, string description, string imageData)
        {
            Id = id;
            IdRestaurant = idRestaurant;
            Name = name;
            Price = price;
            Description = description;
            ImageData = imageData;
        }
        public ProductToAdd() { }
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
        public string ImageData { get; set; }
    }
}
