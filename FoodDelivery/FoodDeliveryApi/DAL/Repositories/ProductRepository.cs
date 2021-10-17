using FoodDeliveryApi.DAL.IRepositories;
using FoodDeliveryApi.Data;
using FoodDeliveryApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace FoodDeliveryApi.DAL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly FoodDeliveryContext context;

        public ProductRepository(FoodDeliveryContext context)
        {
            this.context = context;
        }
        Product IProductRepository.Add(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
            return product;
        }

        IEnumerable<Product> IProductRepository.GetAll()
        {
            return context.Products;
        }

        Product IProductRepository.GetById(int id)
        {
            Product existingProduct = context.Products.Where(product => product.Id == id).FirstOrDefault();
            return existingProduct;
        }

        IEnumerable<Product> IProductRepository.GetByRestaurantId(int id)
        {
            IEnumerable<Product> existingProducts = context.Products.Where(product => product.IdRestaurant == id);
            return existingProducts;
        }

        IEnumerable<Product> IProductRepository.GetByRestaurantName(string name)
        {
            IEnumerable<Product> existingProducts = context.Products.Where(product => product.IdRestaurant == context.Restaurants.FirstOrDefault(restaurant => restaurant.RestaurantName == name).Id);
            return existingProducts;
        }

        bool IProductRepository.Update(int id, Product product)
        {
            Product productUpdate = context.Products.FirstOrDefault(p => p.Id == id);
            if (productUpdate != null)
            {
                productUpdate.Name = product.Name;
                productUpdate.Price = product.Price;
                productUpdate.Description = product.Description;

                context.SaveChanges();
                return true;
            }
            return false;
        }

        bool IProductRepository.VerifyExistence(Product product)
        {
            Product existingProduct = context.Products.Where(p => p.Name == product.Name && p.IdRestaurant == product.IdRestaurant).FirstOrDefault();
            return existingProduct == null;
        }
    }
}
