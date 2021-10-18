using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;

namespace FoodDelivery
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private Button btnRegister;
        private Button btnLogin;

       
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            FindViews();
            LinkEventHandler();
        }

        private void LinkEventHandler()
        {
            btnRegister.Click += btnRegister_Click; ;
            btnLogin.Click += btnLogin_Click; ;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(Registration));
            StartActivity(intent);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(Profile));
            StartActivity(intent);
        }

        private void FindViews()
        {
            btnRegister = FindViewById<Button>(Resource.Id.btnRegister);
            btnLogin = FindViewById<Button>(Resource.Id.btnLogin);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}