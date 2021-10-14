using FoodDeliveryApi.DAL.IRepositories;
using FoodDeliveryApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace FoodDeliveryApi.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        User IUserRepository.Add(User user)
        {
            throw new NotImplementedException();
        }

        IEnumerable<User> IUserRepository.GetAll()
        {
            throw new NotImplementedException();
        }

        User IUserRepository.GetById(int id)
        {
            throw new NotImplementedException();
        }

        User IUserRepository.GetByUsername(string username)
        {
            throw new NotImplementedException();
        }

        bool IUserRepository.Update(int id, User user)
        {
            throw new NotImplementedException();
        }
    }
}