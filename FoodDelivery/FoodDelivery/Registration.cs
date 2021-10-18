using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FoodDelivery
{
    [Activity(Label = "Registration")]
    public class Registration : Activity
    {
        private Button btnRegister;
        private string Email;
        private string password;
        private string password2;
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Registration);
            // Create your application here
            btnRegister.Click += btnRegister_Click;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(RestaurantList));
            StartActivity(intent);
        }
    }
}