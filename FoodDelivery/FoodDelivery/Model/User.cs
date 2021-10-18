using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FoodDelivery.Model
{
    public class User
    {
        public User(string username, string email, string password)
        {
            this.UserName = username;
            this.Email = email;
            this.Password = password;
        }
        public User(string username, string password)
        {
            this.UserName = username;
            this.Password = password;
        }

        public int Id { get; set; }
       
        public string UserName { get; set; }
        
        public string Email { get; set; }
       
        public string Password { get; set; }
    }
}