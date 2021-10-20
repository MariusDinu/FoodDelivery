using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using FoodDelivery.Repository;

namespace FoodDelivery
{
    [Activity(Label = "Profile")]
    public class Profile : Activity
    {
        private Button btnToRestaurants;
        private ApiRepository apiRepository;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.UserProfile);

            btnToRestaurants = FindViewById<Button>(Resource.Id.showResturantsButton);
            btnToRestaurants.Click += BtnToRestaurants_Click;
            apiRepository = new ApiRepository();
            LoadDataAsync();
            // Create your application here
        }

        private void BtnToRestaurants_Click(object sender, System.EventArgs e)
        {
            var intent = new Intent();
            intent.SetClass(this, typeof(RestaurantList));
            StartActivity(intent);
        }

        private async void LoadDataAsync()
        {
            var response = await apiRepository.GetProfile();
            //set data 
        }
    }
}