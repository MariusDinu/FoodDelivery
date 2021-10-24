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
        private readonly IImageHelper imageHelper;
        public ProductRepository(FoodDeliveryContext context)
        {
            this.context = context;
            this.imageHelper = new ImageHelper();
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

        ProductToAdd IProductRepository.GetById(int id)
        {
            Product existingProduct = context.Products.Where(product => product.Id == id).FirstOrDefault();
            ProductToAdd product = new ProductToAdd(existingProduct.Id, existingProduct.IdRestaurant, existingProduct.Name, existingProduct.Price, existingProduct.Description, imageHelper.ReadImage(existingProduct.Path));
            return product;
        }

        List<ProductToAdd> IProductRepository.GetByRestaurantId(int id)
        {
            List<ProductToAdd> products = new List<ProductToAdd>();
            IEnumerable<Product> existingProducts = context.Products.Where(product => product.IdRestaurant == id);
            foreach (var item in existingProducts)
            {

                products.Add(new ProductToAdd(item.Id, item.IdRestaurant, item.Name, item.Price, item.Description, imageHelper.ReadImage(item.Path)));
            }
            return products;
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
