using Android.App;
using Android.Content;
using Android.OS;
using AndroidX.RecyclerView.Widget;
using FoodDelivery.Adapters;
using FoodDelivery.Model;
using FoodDelivery.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodDelivery
{
    [Activity(Label = "RestaurantList")]
    public class RestaurantList : Activity
    {

        private RecyclerView _restaurantRecyclerView;
        private RecyclerView.LayoutManager _restaurantLayoutManager;
        private RestaurantAdapter _restaurantAdapter;
        private ApiRepository apiRepository;
        private List<Restaurant> restaurantsList;
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.RestaurantList);


            apiRepository = new ApiRepository();
            restaurantsList = await LoadDataAsync();


            _restaurantRecyclerView = FindViewById<RecyclerView>(Resource.Id.restaurantListRecyclerView);
            _restaurantLayoutManager = new LinearLayoutManager(this);
            _restaurantRecyclerView.SetLayoutManager(_restaurantLayoutManager);
            _restaurantAdapter = new RestaurantAdapter(restaurantsList);
            _restaurantRecyclerView.SetAdapter(_restaurantAdapter);
            _restaurantAdapter.ItemClick += RestaurantAdapter_ItemClick;
            // Create your application here
        }



        private async Task<List<Restaurant>> LoadDataAsync()
        {
            List<Restaurant> restaurants = await apiRepository.GetRestaurants();
            return restaurants;
        }

        private void RestaurantAdapter_ItemClick(object sender, int e)
        {
            var intent = new Intent();
            intent.SetClass(this, typeof(RestaurantMenu));
            intent.PutExtra("id", e);
            StartActivity(intent);
        }
    }
}