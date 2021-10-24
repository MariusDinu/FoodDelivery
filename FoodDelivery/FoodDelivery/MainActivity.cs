using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Widget;
using AndroidX.AppCompat.App;
using FoodDelivery.Repository;
using System;


namespace FoodDelivery
{

    [Activity(Label = "asdasddase", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private Button login;
        private Button register;
        private TextView welcome;
        private ConfigRepository config;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            if (!JwtRepository.ExpireJWT())
            {
                config = new ConfigRepository();
                FindViews();
                LinkEventHandler();

            }
            else
            {
                var intent = new Intent();
                intent.SetClass(this, typeof(Profile));
                StartActivity(intent);
            }
        }

        private void LinkEventHandler()
        {
            login.Click += Login_Click;
            register.Click += Register_Click;
        }

        private void Register_Click(object sender, EventArgs e)
        {
            var intent = new Intent();
            intent.SetClass(this, typeof(Registration));
            StartActivity(intent);
        }

        private void Login_Click(object sender, EventArgs e)
        {
            var intent = new Intent();
            intent.SetClass(this, typeof(Login));
            StartActivity(intent);
        }

        private void FindViews()
        {
            login = FindViewById<Button>(Resource.Id.buttonLoginStart);
            register = FindViewById<Button>(Resource.Id.buttonRegisterStart);
            welcome = FindViewById<TextView>(Resource.Id.textTitleStart);
            Color startColor = Color.ParseColor("#f3ae1b");
            Color endColor = Color.ParseColor("#6a3ab2");
            TextPaint paint = welcome.Paint;
            float width = paint.MeasureText("Tianjin, China");
            welcome.SetTextColor(startColor);
            Shader textShader = new LinearGradient(0, 0, width, paint.TextSize,
                            new int[] { startColor, endColor },
                            new float[] { 0, 1 }, Shader.TileMode.Clamp);
            paint.SetShader(textShader);

        }


        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

    }

}