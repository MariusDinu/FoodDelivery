using FoodDeliveryApi.DAL.IRepositories;
using FoodDeliveryApi.Data;
using FoodDeliveryApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace FoodDeliveryApi.DAL.Repositories
{
    public class OrderProductsRepository : IOrderProductsRepository
    {
        private readonly FoodDeliveryContext context;

        public OrderProductsRepository(FoodDeliveryContext context)
        {
            this.context = context;
        }
        public void Add(IEnumerable<OrderProducts> order, int id)
        {
            foreach (var item in order)
            {
                item.IdOrder = id;
                context.OrderProducts.Add(item);
                context.SaveChanges();
            }
        }

        public IEnumerable<OrderProducts> GetAllById(int id)
        {
            IEnumerable<OrderProducts> order = context.OrderProducts.Where(order => order.IdOrder == id);
            return order;
        }


    }
}
