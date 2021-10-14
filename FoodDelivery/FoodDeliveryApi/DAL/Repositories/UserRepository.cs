using FoodDeliveryApi.DAL.IRepositories;
using FoodDeliveryApi.Data;
using FoodDeliveryApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace FoodDeliveryApi.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly FoodDeliveryContext context;
        public UserRepository(FoodDeliveryContext context)
        {
            this.context = context;
        }

        public bool VerifyExistence(User user)
        {
            User existingUser = (from u in context.Users
                                 where (u.UserName == user.UserName || u.Email == user.Email)
                                 select u).FirstOrDefault();
            if (existingUser == null)
                return true;
            return false;
        }

        User IUserRepository.Add(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
            return user;
        }

        IEnumerable<User> IUserRepository.GetAll()
        {
            return context.Users;
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