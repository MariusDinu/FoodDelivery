using FoodDeliveryApi.DAL.IRepositories;
using FoodDeliveryApi.Data;
using FoodDeliveryApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace FoodDeliveryApi.DAL.Repositories
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly FoodDeliveryContext context;
        private readonly IImageHelper imageHelper;
        public RestaurantRepository(FoodDeliveryContext context)
        {
            this.context = context;
            this.imageHelper = new ImageHelper();
        }

        Restaurant IRestaurantRepository.Add(Restaurant restaurant)
        {
            context.Restaurants.Add(restaurant);
            context.SaveChanges();
            return restaurant;
        }

        List<RestaurantToAdd> IRestaurantRepository.GetAll()
        {
            List<RestaurantToAdd> restaurants = new List<RestaurantToAdd>();
            foreach (var item in context.Restaurants)
            {
                restaurants.Add(new RestaurantToAdd(item.Id, item.RestaurantName, item.Street, item.StreetNumber, item.Building, imageHelper.ReadImage(item.Path)));

            }
            return restaurants;
        }

        Restaurant IRestaurantRepository.GetById(int id)
        {
            Restaurant existingRestaurant = (from r in context.Restaurants
                                             where (r.Id == id)
                                             select r).FirstOrDefault();
            return existingRestaurant;
        }

        Restaurant IRestaurantRepository.GetByName(string name)
        {
            Restaurant existingRestaurant = (from r in context.Restaurants
                                             where (r.RestaurantName == name)
                                             select r).FirstOrDefault();
            return existingRestaurant;
        }

        bool IRestaurantRepository.Update(int id, Restaurant restaurant)
        {
            Restaurant restaurantUpdate = context.Restaurants.FirstOrDefault(r => r.Id == id);
            if (restaurantUpdate != null)
            {
                restaurantUpdate.RestaurantName = restaurant.RestaurantName;
                restaurantUpdate.Street = restaurant.Street;
                restaurantUpdate.StreetNumber = restaurant.StreetNumber;
                restaurantUpdate.Building = restaurant.Building;

                context.SaveChanges();
                return true;
            }
            return false;
        }

        bool IRestaurantRepository.VerifyExistence(Restaurant restaurant)
        {
            Restaurant existingRestaurant = (from r in context.Restaurants
                                             where (r.RestaurantName == restaurant.RestaurantName)
                                             select r).FirstOrDefault();
            return existingRestaurant == null;
        }

    }
}
