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
    public class Product
    {
        public int Id { get; set; }
        
        public int IdRestaurant { get; set; }
       
        public string Name { get; set; }
      
        public string Price { get; set; }
        public string Description { get; set; }
    }
}