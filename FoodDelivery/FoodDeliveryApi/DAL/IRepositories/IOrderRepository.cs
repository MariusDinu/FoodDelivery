using FoodDeliveryApi.Models;
using System.Collections.Generic;

namespace FoodDeliveryApi.DAL.IRepositories
{
    public interface IOrderRepository
    {
        Order Add(Order order);
        IEnumerable<Order> GetByUserId(int id);
        IEnumerable<Order> GetByRestaurantId(int id);
        bool Update(int id, Order order);
        Order GetById(int id);
        IEnumerable<Order> GetAll();
        bool VerifyExistence(Order order);
    }
}
