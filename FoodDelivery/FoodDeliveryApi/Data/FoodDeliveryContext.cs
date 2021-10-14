using FoodDeliveryApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace FoodDeliveryApi.Data
{
    public class FoodDeliveryContext : DbContext
    {
        public FoodDeliveryContext()
        {
          
        }

        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            modelBuilder.Entity<User>();
        }
    }
}