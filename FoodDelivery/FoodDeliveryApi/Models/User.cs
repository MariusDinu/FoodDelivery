﻿using System.ComponentModel.DataAnnotations;

namespace FoodDeliveryApi.Models
{
    public class User 
    {

        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(100)]
        public string Email { get; set; }
        [Required]
        [MaxLength(100)]
        public string Password { get; set; }
        public User(int Id,string UserName,string Email,string Password)
        {
            this.Id = Id;
            this.UserName = UserName;
            this.Email = Email;
            this.Password = Password;
        }
    }
}