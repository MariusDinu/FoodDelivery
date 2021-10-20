using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using FoodDelivery.Model;
using FoodDelivery.Repository;
using System;
using System.Text.RegularExpressions;

namespace FoodDelivery
{
    [Activity(Label = "Registration",MainLauncher =true)]
    public class Registration : Activity
    {
        private Button btnRegister;
        private EditText email;
        private EditText username;
        private EditText password;
        private EditText passwordConfirm;
        private ApiRepository apiRepository;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Registration);
            // Create your application here
            FindViews();
            apiRepository = new ApiRepository();
            btnRegister.Click += btnRegister_Click;
        }

        private void FindViews()
        {
            btnRegister = FindViewById<Button>(Resource.Id.btnRegister);
            email = FindViewById<EditText>(Resource.Id.editTextEmail);
            username = FindViewById<EditText>(Resource.Id.editTextUserName);
            password = FindViewById<EditText>(Resource.Id.editTextPassword);
            passwordConfirm = FindViewById<EditText>(Resource.Id.editTextPassword2);
        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                User user = apiRepository.CreateUser(username.Text,email.Text, password.Text);
                var response = await apiRepository.Registration(user);
                if (response.Equals("True"))
                {
                    Toast.MakeText(Application.Context, "Register successfully!", ToastLength.Long).Show();
                    Intent intent = new Intent(this, typeof(MainActivity));
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

            if (!Regex.Match(email.Text, @"^([\w]+)@([\w]+)((\.(\w){2,3})+)$").Success)
            {
                Toast.MakeText(Application.Context, "Email doesn't match requirements!", ToastLength.Short).Show();
                return false;
            }
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
            if (!password.Text.Equals(passwordConfirm.Text))
            {
                Toast.MakeText(Application.Context, "Passwords doesn't match!", ToastLength.Short).Show();
                return false;
            }
            return true;
        }
    }
}