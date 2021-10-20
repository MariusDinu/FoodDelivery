using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using AndroidX.Core.View;
using AndroidX.DrawerLayout.Widget;
using FoodDelivery.Model;
using FoodDelivery.Repository;
using Google.Android.Material.FloatingActionButton;
using Google.Android.Material.Navigation;
using Google.Android.Material.Snackbar;
using Google.Android.Material.Tabs.AppCompat.App;
using System;

namespace FoodDelivery
{
    [Activity(Label = "Profile", Theme = "@style/AppTheme.NoActionBar", MainLauncher = false)]
    public class Profile : Activity
    {
        private Button btnToRestaurants;
        private Button btnToOrder;
        private TextView name;
        private TextView email;
        private ApiRepository apiRepository;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.UserProfile);

            btnToRestaurants = FindViewById<Button>(Resource.Id.showResturantsButton);
            btnToOrder = FindViewById<Button>(Resource.Id.btnOrder);
            btnToRestaurants.Click += BtnToRestaurants_Click;
            btnToOrder.Click += BtnToOrder_Click;
            apiRepository = new ApiRepository();
            LoadDataAsync();

            name = FindViewById<TextView>(Resource.Id.textViewProfileName);
            email = FindViewById<TextView>(Resource.Id.textViewProfileEmail);


            // Create your application here
        }

        private void BtnToOrder_Click(object sender, EventArgs e)
        {
            var intent = new Intent();
            intent.SetClass(this, typeof(ShoppingChart));
            StartActivity(intent);
        }

        private void BtnToRestaurants_Click(object sender, System.EventArgs e)
        {
            var intent = new Intent();
            intent.SetClass(this, typeof(RestaurantList));
            StartActivity(intent);
        }

        private async void LoadDataAsync()
        {
            User response = await apiRepository.GetProfile();
            name.Text = response.UserName;
            email.Text = response.Email;
        }
        
    }
}