﻿using FoodDeliveryApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace FoodDeliveryApi.Data
{
    public class FoodDeliveryContext : DbContext
    {
        public FoodDeliveryContext(DbContextOptions<FoodDeliveryContext> options) : base(options)
        {
            ChangeTracker.LazyLoadingEnabled = false;
        }

        public FoodDeliveryContext() { }
        public override int SaveChanges()
        {

            return base.SaveChanges();
        }



        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>().HasData(
                new User(1, "mariusd30", "mariusd30", "12345"));

            modelBuilder.Entity<Restaurant>().HasData(
                new Restaurant(1, "SmilePizza", "Pacurari", "22", "Sc.B"));

            modelBuilder.Entity<Product>().HasData(
                new Product(1, 1, "Pizza", "10", "Pizza cu de toate"));

            modelBuilder.Entity<Order>().HasData(
                new Order(1, 1, 1, "{'1':2}", "100", "Pacurari,22"));



        }
    }
}