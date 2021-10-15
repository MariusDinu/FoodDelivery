using FoodDeliveryApi.DAL.IRepositories;
using FoodDeliveryApi.Data;
using FoodDeliveryApi.Models;
using System.Collections.Generic;
using System.Linq;



namespace FoodDeliveryApi.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly FoodDeliveryContext context;
        public UserRepository(FoodDeliveryContext context)
        {
            this.context = context;
        }

        public bool VerifyEmail(string email)
        {
            User existingUser = (from u in context.Users
                                 where (u.Email == email)
                                 select u).FirstOrDefault();
            if (existingUser == null)
                return true;
            return false;
            //rework
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

        public bool VerifyUsername(string username)
        {
            User existingUser = (from u in context.Users
                                 where (u.UserName == username)
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
            User existingUser = (from u in context.Users
                                 where (u.Id == id)
                                 select u).FirstOrDefault();
            return existingUser;
        }

        User IUserRepository.GetByUsername(string username)
        {
            User existingUser = (from u in context.Users
                                 where (u.UserName == username)
                                 select u).FirstOrDefault();
            return existingUser;
        }

        bool IUserRepository.Update(int id, User user)
        {
            User userUpdate = context.Users.FirstOrDefault(u => u.Id == id);
            if (userUpdate != null)
            {
                userUpdate.UserName = user.UserName;
                userUpdate.Email = user.Email;

                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}