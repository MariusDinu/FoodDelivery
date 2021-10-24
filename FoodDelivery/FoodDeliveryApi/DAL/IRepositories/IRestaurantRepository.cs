using FoodDeliveryApi.Models;
using System.Collections.Generic;

namespace FoodDeliveryApi.DAL.IRepositories
{
    public interface IRestaurantRepository
    {
        Restaurant Add(Restaurant restaurant);
        bool Update(int id, Restaurant restaurant);
        Restaurant GetByName(string name);
        Restaurant GetById(int id);
        List<RestaurantToAdd> GetAll();
        bool VerifyExistence(Restaurant restaurant);

    }
}
