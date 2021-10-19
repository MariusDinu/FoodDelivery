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
    public class ShoppingChartRepository
    {
        public List<ShoppingChartItem> repository { get; set; }
        public ShoppingChartRepository()
        {
            repository = new List<ShoppingChartItem>();
        }
        public void AddToShoppingCart(Product p, int quantity)
        {
            var ShoppingChartItem = new ShoppingChartItem()
            {
                Product = p,
                Quantity = quantity
            };
            repository.Add(ShoppingChartItem);
        }
        public void AddToShoppingCart(ShoppingChartItem s)
        {
            repository.Add(s);
        }

        public List<ShoppingChartItem> GetAllProducts()
        {
            return repository;
        }

        

        public ShoppingChartItem GetProductById(int id)
        {
            return repository.FirstOrDefault(p => p.Product.Id == id);
        }
    }
}