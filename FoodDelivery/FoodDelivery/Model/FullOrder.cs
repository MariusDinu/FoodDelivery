using System.Collections.Generic;

namespace FoodDelivery.Model
{
    public class FullOrder
    {
        public Order order { get; set; }
        public FullOrder(Order order)
        {
            this.order = order;
        }
        public List<OrderProducts> orderProducts { get; set; }

        public FullOrder(Order order, List<OrderProducts> orderProducts)
        {
            this.order = order;
            this.orderProducts = orderProducts;
        }
        public FullOrder() { }
    }
}