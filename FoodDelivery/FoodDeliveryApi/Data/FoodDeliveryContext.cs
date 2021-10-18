using FoodDeliveryApi.Models;
using Microsoft.EntityFrameworkCore;



namespace FoodDeliveryApi.Data
{
    public class FoodDeliveryContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }


        public FoodDeliveryContext(DbContextOptions<FoodDeliveryContext> options) : base(options)
        {
            ChangeTracker.LazyLoadingEnabled = false;
        }

        public FoodDeliveryContext() { }

        public override int SaveChanges()
        {

            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>();

            modelBuilder.Entity<Restaurant>();

            modelBuilder.Entity<Product>();

            modelBuilder.Entity<Order>();



        }
    }
}