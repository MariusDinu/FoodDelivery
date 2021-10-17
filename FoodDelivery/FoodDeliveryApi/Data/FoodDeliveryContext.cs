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

            modelBuilder.Entity<User>().HasData(
                new User(1, "mariusd30", "mariusd30", "12345"));

            modelBuilder.Entity<Restaurant>().HasData(
                new Restaurant(1, "SmilePizza", "Pacurari", "22", "Sc.B"));

            modelBuilder.Entity<Product>().HasData(
                new Product(1, 1, "Pizza", "10", "Pizza cu de toate"));

            modelBuilder.Entity<Order>().HasData(
                new Order(1, 1, 1, "{'1':2}", "100", "Pacurari,22", System.DateTime.Now, "Preparation"));



        }
    }
}