using Android.App;
using Android.OS;
using FoodDelivery.Model;
using FoodDelivery.Repository;
using System.Collections.Generic;

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
            IEnumerable<Restaurant> list = await apiRepository.GetRestaurants();
            //add list in adapter
            //i.PutExtra("id", object.id); de adaugat la on click
        }
    }
}