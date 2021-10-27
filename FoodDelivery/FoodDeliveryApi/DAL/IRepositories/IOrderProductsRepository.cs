using FoodDeliveryApi.Models;
using System.Collections.Generic;

namespace FoodDeliveryApi.DAL.IRepositories
{
    public interface IOrderProductsRepository
    {
        IEnumerable<OrderProducts> GetAllById(int id);
        void Add(IEnumerable<OrderProducts> order, int id);
    }
}
