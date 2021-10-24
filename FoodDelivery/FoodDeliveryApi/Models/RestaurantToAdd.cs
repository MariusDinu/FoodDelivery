using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDeliveryApi.Models
{
    public class RestaurantToAdd
    {
        public RestaurantToAdd(int id,string restaurantName, string street, string streetNumber, string building, string imageData)
        {
            Id = id;
            RestaurantName = restaurantName;
            Street = street;
            StreetNumber = streetNumber;
            Building = building;
            ImageData = imageData;
        }
        public RestaurantToAdd() { }
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
        public string ImageData { get; set; }
    }
}
