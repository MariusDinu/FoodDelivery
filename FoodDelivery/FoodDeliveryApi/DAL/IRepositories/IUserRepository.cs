using FoodDeliveryApi.Models;
using System.Collections.Generic;

namespace FoodDeliveryApi.DAL.IRepositories
{

    public interface IUserRepository
    {

        User Add(User user);
        bool Update(int id, User user);
        User GetByUsername(string username);
        User GetById(int id);
        IEnumerable<User> GetAll();
        bool VerifyExistence(User user);
        bool VerifyEmail(string email);
        bool VerifyUsername(string username);
    }

}