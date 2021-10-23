using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using FoodDelivery.Model;
using FoodDelivery.Repository;
using System;
using System.Text.RegularExpressions;

namespace FoodDelivery
{
    [Activity(Label = "@string/app_name", MainLauncher = false)]
    public class Login : Activity
    {
        private Button btnLogin;
        private EditText username;
        private EditText password;
        private ApiRepository apiRepository;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Login);
            FindViews();
            apiRepository = new ApiRepository();
            LinkEventHandler();


        }

        private void LinkEventHandler()
        {
            btnLogin.Click += btnLogin_Click; ;
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                User user = apiRepository.CreateUser(username.Text, password.Text);
                var response = await apiRepository.Login(user);
                if (response.Equals("True"))
                {
                    Toast.MakeText(Application.Context, "Login successfully!", ToastLength.Long).Show();
                    Intent intent = new Intent(this, typeof(Profile));
                    StartActivity(intent);
                }
                else
                {
                    Toast.MakeText(Application.Context, response, ToastLength.Long).Show();
                }

            }
        }

        private bool CheckData()
        {
            if (!Regex.Match(username.Text, @"^[a-z0-9_-]{3,15}$").Success)
            {
                Toast.MakeText(Application.Context, "Username doesn't match requirements!", ToastLength.Short).Show();
                return false;
            }
            if (!Regex.Match(password.Text, @"^(?=.*\d)(?=.*[A-Z])(?=.*[a-z])(?=.*[^\w\d\s:])([^\s]){8,16}$").Success ||
                password.Text.Contains(" ") || password.Text.Length < 10)
            {
                Toast.MakeText(Application.Context, "Password doesn't match requirements!", ToastLength.Short).Show();
                return false;
            }
            return true;
        }

        private void FindViews()
        {
            btnLogin = FindViewById<Button>(Resource.Id.btnLogin);
            username = FindViewById<EditText>(Resource.Id.usernameEditText);
            password = FindViewById<EditText>(Resource.Id.passwordEditText);

        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

    }
}