using System.Collections.Generic;

namespace FoodDeliveryApi.Models
{
    public class OrderToAdd
    {
        public int IdRestaurant { get; set; }
        public string Price { get; set; }
        public string Status { get; set; }
        public List<OrderProducts> order { get; set; }
    }
}
