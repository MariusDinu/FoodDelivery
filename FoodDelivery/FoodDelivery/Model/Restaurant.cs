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
    public class Restaurant
    {
        public int Id { get; set; }
        
        public string RestaurantName { get; set; }
        
        public string Street { get; set; }
       
        public string StreetNumber { get; set; }
       
        public string Building { get; set; }
    }
}