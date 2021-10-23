using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Util;
using Android.Widget;
using FoodDelivery.Model;
using FoodDelivery.Repository;
using System;


namespace FoodDelivery
{
    [Activity(Label = "Profile", MainLauncher = false)]
    public class Profile : Activity
    {
        private Button btnToRestaurants;
        private Button btnToOrder;
        private Button btntoMyOrders;
        private Button btnLogOut;
        private ImageView image;
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
            btntoMyOrders = FindViewById<Button>(Resource.Id.btnMyOrders);
            btnLogOut = FindViewById<Button>(Resource.Id.btnLogOut);
            image = FindViewById<ImageView>(Resource.Id.UserimageView);
            btnToRestaurants.Click += BtnToRestaurants_Click;
            btnToOrder.Click += BtnToOrder_Click;
            btntoMyOrders.Click += BtntoMyOrders_Click;
            btnLogOut.Click += BtnLogOut_Click;
            apiRepository = new ApiRepository();
            LoadDataAsync();

            name = FindViewById<TextView>(Resource.Id.textViewProfileName);
            email = FindViewById<TextView>(Resource.Id.textViewProfileEmail);


            // Create your application here
        }

        private void BtnLogOut_Click(object sender, EventArgs e)
        {
            JwtRepository.DeleteJWT();
            Finish();
            var intent = new Intent();
            intent.SetClass(this, typeof(MainActivity));
            StartActivity(intent);
        }

        private void BtntoMyOrders_Click(object sender, EventArgs e)
        {
            var intent = new Intent();
            intent.SetClass(this, typeof(MyOrders));
            StartActivity(intent);
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
            byte[] bytes = Base64.Decode(response.Path, Base64Flags.Default);
            // Initialize bitmap
            Bitmap bitmap = BitmapFactory.DecodeByteArray(bytes, 0, bytes.Length);

            image.SetImageBitmap(bitmap);

        }

    }
}