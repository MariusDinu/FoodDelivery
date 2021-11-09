using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using FoodDelivery.Adapters;
using FoodDelivery.Model;
using FoodDelivery.Repository;
using Serilog;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodDelivery
{
    [Activity(Label = "RestaurantMenu")]
    public class RestaurantMenu : Activity
    {
        private RecyclerView _productRecyclerView;
        private RecyclerView.LayoutManager _productLayoutManager;
        private ProductAdapter _productAdapter;
        private RestaurantRepository restaurantRepository;
        private List<Product> productsList;
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.RestaurantMenu);

            restaurantRepository = new RestaurantRepository();
            productsList = await LoadDataAsync();

            _productRecyclerView = FindViewById<RecyclerView>(Resource.Id.restaurantMenuRecyclerView);
            _productLayoutManager = new LinearLayoutManager(this);
            _productRecyclerView.SetLayoutManager(_productLayoutManager);
            _productAdapter = new ProductAdapter(productsList);
            _productRecyclerView.SetAdapter(_productAdapter);
            _productAdapter.ItemClick += ProductAdapter_ItemClick;
        }

        private async Task<List<Product>> LoadDataAsync()
        {
            try
            {
                var response = await restaurantRepository.GetProducts(Intent.GetIntExtra("id", 0));
                return response;
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString()); Toast.MakeText(Application.Context, GetString(Resource.String.FailedMsg), ToastLength.Long).Show(); return null;
            }

        }

        private void ProductAdapter_ItemClick(object sender, int e)
        {
            var intent = new Intent();
            intent.SetClass(this, typeof(ProductDetail));
            intent.PutExtra("productId", e);
            StartActivity(intent);
        }
    }
}