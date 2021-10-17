using FoodDeliveryApi.Models;
using System.Collections.Generic;

namespace FoodDeliveryApi.DAL.IRepositories
{
    public interface IProductRepository
    {
        Product Add(Product product);
        bool Update(int id, Product product);
        Product GetById(int id);
        IEnumerable<Product> GetAll();
        IEnumerable<Product> GetByRestaurantId(int id);
        IEnumerable<Product> GetByRestaurantName(string name);
        bool VerifyExistence(Product product);
    }
}
