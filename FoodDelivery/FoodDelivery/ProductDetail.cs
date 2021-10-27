using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Util;
using Android.Widget;
using FoodDelivery.Model;
using FoodDelivery.Repository;
using System;
using System.Threading.Tasks;

namespace FoodDelivery
{
    [Activity(Label = "ProductDetail")]
    public class ProductDetail : Activity
    {
        private Button btnAddToChart;
        private Button btnAddQuantity;
        private ImageView image;
        private ProductRepository productRepository;
        private ChartRepository chartRepository;
        private Product selectedProduct;
        private TextView productNameTextView;
        private TextView productDescriptionTextView;
        private TextView productPriceTextView;
        private EditText productQuantityEditText;
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ProductDetail);

            productRepository = new ProductRepository();
            chartRepository = new ChartRepository();
            selectedProduct = await LoadDataAsync();

            FindViews();
            BinData();
            LinkEventHandler();


        }

        private void LinkEventHandler()
        {
            btnAddToChart.Click += BtnAddToChart_Click;
            btnAddQuantity.Click += BtnAddQuantity_Click;
        }

        private void BtnAddQuantity_Click(object sender, EventArgs e)
        {
            var count = int.Parse(productQuantityEditText.Text);
            count++;
            productQuantityEditText.Text = count.ToString();
        }

        private void BtnAddToChart_Click(object sender, EventArgs e)
        {
            AddProducts();
        }

        private async void AddProducts()
        {
            int quantity = int.Parse(productQuantityEditText.Text);
            string response = await chartRepository.AddProductAsync(Intent.GetIntExtra("productId", 0), quantity);
            if (response.Equals("New"))
            {
                ShowAlert();
            }
            else if (response.Equals("Exist"))
            {
                ShowAlertDuplicate();
            }
            else
            {
                Finish();
            }

        }
        private void ShowAlert()
        {
            AlertDialog.Builder dialog = new AlertDialog.Builder(this);
            AlertDialog alert = dialog.Create();
            string message = GetString(Resource.String.Error1);
            alert.SetTitle("Info");
            alert.SetMessage(message);
            alert.SetButton("OK", (c, ev) =>
            {
                chartRepository.ChangeRestaurant();
                AddProducts();
                Finish();
            });
            alert.SetButton2("Cancel", (c, ev) =>
            {
            });
            alert.Show();
        }
        private void ShowAlertDuplicate()
        {
            AlertDialog.Builder dialog = new AlertDialog.Builder(this);
            AlertDialog alert = dialog.Create();
            string message = GetString(Resource.String.Error2);
            alert.SetMessage(message);
            alert.SetButton("OK", (c, ev) =>
            {
                Finish();
            });
            alert.SetButton2("Cancel", (c, ev) =>
            {
            });
            alert.Show();
        }

        private async Task<Product> LoadDataAsync()
        {
            Product product = await productRepository.GetProduct(Intent.Extras.GetInt("productId"));
            return product;
        }

        private void BinData()
        {
            productNameTextView.Text = selectedProduct.Name;
            productDescriptionTextView.Text = selectedProduct.Description;
            productPriceTextView.Text = selectedProduct.Price + GetString(Resource.String.priceCurrency);
            byte[] bytes = Base64.Decode(selectedProduct.ImageData, Base64Flags.Default);
            Bitmap bitmap = BitmapFactory.DecodeByteArray(bytes, 0, bytes.Length);
            image.SetImageBitmap(bitmap);
        }



        private void FindViews()
        {
            productNameTextView = FindViewById<TextView>(Resource.Id.productNametextView2);
            productDescriptionTextView = FindViewById<TextView>(Resource.Id.ProductDescriptionTextView);
            productPriceTextView = FindViewById<TextView>(Resource.Id.productPricetextView);
            productQuantityEditText = FindViewById<EditText>(Resource.Id.productQuantityEditText);
            image = FindViewById<ImageView>(Resource.Id.imageViewProductDetail);
            btnAddToChart = FindViewById<Button>(Resource.Id.buttonAddChart);
            btnAddQuantity = FindViewById<Button>(Resource.Id.buttonAddQuantity);
        }
    }
}