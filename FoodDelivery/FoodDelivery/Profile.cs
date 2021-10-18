using Android.App;
using Android.OS;
using FoodDelivery.Repository;

namespace FoodDelivery
{
    [Activity(Label = "Profile")]
    public class Profile : Activity
    {
        private ApiRepository apiRepository;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.UserProfile);
            apiRepository = new ApiRepository();
            LoadDataAsync();
            // Create your application here
        }

        private async void LoadDataAsync()
        {
            var response = await apiRepository.GetProfile();
            //set data 
        }
    }
}