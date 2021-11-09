using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using FoodDelivery.Model;
using FoodDelivery.Repository;
using Serilog;
using System;
using System.IO;
using System.Text.RegularExpressions;
using Xamarin.Essentials;

namespace FoodDelivery
{
    [Activity(Label = "Registration")]
    public class Registration : Activity
    {
        private Button btnRegister;
        private Button btnAdd;
        private EditText email;
        private EditText username;
        private EditText password;
        private EditText passwordConfirm;
        private TextView addFiles;
        private ApiRepository apiRepository;
        FileResult file;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Registration);
            FindViews();

            apiRepository = new ApiRepository();
            btnRegister.Click += btnRegister_Click;
            btnAdd.Click += AddFilesAsync;
        }

        private void FindViews()
        {
            btnRegister = FindViewById<Button>(Resource.Id.btnRegister);
            btnAdd = FindViewById<Button>(Resource.Id.buttonAddFiles);
            email = FindViewById<EditText>(Resource.Id.editTextEmail);
            username = FindViewById<EditText>(Resource.Id.editTextUserName);
            password = FindViewById<EditText>(Resource.Id.editTextPassword);
            passwordConfirm = FindViewById<EditText>(Resource.Id.editTextPassword2);
            addFiles = FindViewById<TextView>(Resource.Id.textViewAddFiles);
        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            byte[] code;
            try
            {
                if (CheckData() && file != null)
                {
                    code = File.ReadAllBytes(file.FullPath);
                    var stream = new MemoryStream(code);
                    string base64String = Convert.ToBase64String(stream.ToArray());
                    UserToSend user = apiRepository.CreateUser(username.Text, email.Text, password.Text, base64String);
                    var response = await apiRepository.Registration(user);
                    if (response.Equals("True"))
                    {
                        Toast.MakeText(Application.Context, GetString(Resource.String.RegisterSucces), ToastLength.Long).Show();
                        Intent intent = new Intent(this, typeof(Login));
                        StartActivity(intent);
                    }
                    else
                    {
                        Toast.MakeText(Application.Context, GetString(Resource.String.FailedAgainMsg), ToastLength.Long).Show();
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex.ToString());
                Toast.MakeText(Application.Context, GetString(Resource.String.FailedMsg), ToastLength.Long).Show();
            }
        }

        private async void AddFilesAsync(object sender, EventArgs e)
        {
            try
            {
                file = await FilePicker.PickAsync();
                if (file == null) { return; }
            }
            catch (Exception ex) { Log.Error(ex.ToString()); Toast.MakeText(Application.Context, GetString(Resource.String.FailedAgainMsg), ToastLength.Long).Show(); }
            addFiles.Text = file.FileName;
        }
        private bool CheckData()
        {
            if (!Regex.Match(email.Text, @"^([\w]+)@([\w]+)((\.(\w){2,3})+)$").Success)
            {
                Toast.MakeText(Application.Context, GetString(Resource.String.EmailMatch), ToastLength.Short).Show();
                return false;
            }
            if (!Regex.Match(username.Text, @"^[a-z0-9_-]{3,15}$").Success)
            {
                Toast.MakeText(Application.Context, GetString(Resource.String.UserNameMatch), ToastLength.Short).Show();
                return false;
            }
            if (!Regex.Match(password.Text, @"^(?=.*\d)(?=.*[A-Z])(?=.*[a-z])(?=.*[^\w\d\s:])([^\s]){8,16}$").Success ||
                password.Text.Contains(" ") || password.Text.Length < 10)
            {
                Toast.MakeText(Application.Context, GetString(Resource.String.PasswordMatch), ToastLength.Short).Show();
                return false;
            }
            if (!password.Text.Equals(passwordConfirm.Text))
            {
                Toast.MakeText(Application.Context, GetString(Resource.String.PasswordEq), ToastLength.Short).Show();
                return false;
            }
            if (file.FileName == null)
            {
                Toast.MakeText(Application.Context, GetString(Resource.String.PictureMatch), ToastLength.Short).Show();
                return false;
            }
            return true;
        }
    }
}