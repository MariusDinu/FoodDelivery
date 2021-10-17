using FoodDeliveryApi.Models;
using System.Collections.Generic;

namespace FoodDeliveryApi.DAL.IRepositories
{
    public interface IRestaurantRepository
    {
        Restaurant Add(Restaurant restaurant);
        bool Update(int id, Restaurant restaurant);
        Restaurant GetByUsername(string name);
        Restaurant GetById(int id);
        IEnumerable<Restaurant> GetAll();
        bool VerifyExistence(Restaurant restaurant);

    }
}
