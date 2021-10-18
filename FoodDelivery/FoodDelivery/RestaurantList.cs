using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using FoodDelivery.Model;
using FoodDelivery.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FoodDelivery
{
    [Activity(Label = "RestaurantList")]
    public class RestaurantList : Activity
    {
        private ApiRepository apiRepository;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.RestaurantMenu);
            apiRepository = new ApiRepository();
            LoadDataAsync();
            // Create your application here
        }

        private async void LoadDataAsync()
        {
            IEnumerable<Restaurant> list = (IEnumerable<Restaurant>)apiRepository.GetRestaurants();
            //add list in adapter
            //i.PutExtra("id", sender.id); de adaugat la on click
        }
    }
}