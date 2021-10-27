using System;

namespace FoodDelivery.Model
{
    public class Order
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public int IdRestaurant { get; set; }
        public string Price { get; set; }
        public string Location { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Status { get; set; }

        public Order(int idRestaurant, string price, string location, string status)
        {
            IdRestaurant = idRestaurant;
            Price = price;
            Location = location;
            Status = status;
        }
        public Order(int idUser, int idRestaurant, string price, string location, DateTime createdAt, DateTime updatedAt, string status)
        {
            IdUser = idUser;
            IdRestaurant = idRestaurant;
            Price = price;
            Location = location;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            Status = status;
        }
        public Order(int idUser, int idRestaurant, string price, string location, DateTime createdAt, string status)
        {
            IdUser = idUser;
            IdRestaurant = idRestaurant;
            Price = price;
            Location = location;
            CreatedAt = createdAt;
            Status = status;
        }
        public Order() { }
    }
}