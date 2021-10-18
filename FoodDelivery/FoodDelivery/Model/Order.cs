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
    public class Order
    {
        public int Id { get; set; }
       
        public int IdUser { get; set; }
      
        public int IdRestaurant { get; set; }
       
        public string Products { get; set; }
       
        public string Price { get; set; }
        
        public string Location { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public string Status { get; set; }
    }
}