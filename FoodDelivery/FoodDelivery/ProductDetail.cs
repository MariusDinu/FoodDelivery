using Android.App;
using Android.Content;
using Android.OS;
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
        //private Button btnRemovefromChart;
        private ProductRepository productRepository;
        private ChartRepository chartRepository;
        private Product selectedProduct;
        private TextView productNameTextView;
        private TextView productDescriptionTextView;
        private TextView productPriceTextView;
        private EditText productQuantityEditText;
        //private ImageView _productInageTextView;
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ProductDetail);
            productRepository = new ProductRepository();
            chartRepository = new ChartRepository();//repo with all products
            //_chartRepository = new ShoppingChartRepository(); //repo with chart items
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
            bool response = await chartRepository.AddProductAsync(Intent.GetIntExtra("productId", 0), quantity);
            if (!response)
            {
                ShowAlert();
            }
            else { Finish(); }

        }
        private void ShowAlert()
        {
            AlertDialog.Builder dialog = new AlertDialog.Builder(this);
            AlertDialog alert = dialog.Create();
            string message = "You want to add a product from another restaurant. If you want to continue your shopping cart, it will empty. Press ok if you agree or cancel if you want to keep the current products.";
            alert.SetTitle("Info");
            alert.SetMessage(message);
            //alert.SetIcon(Resource.Drawable.info);
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

        private async Task<Product> LoadDataAsync()
        {
            Product product = await productRepository.GetProduct(Intent.Extras.GetInt("productId"));
            return product;
        }

        private void BinData()
        {
            productNameTextView.Text = selectedProduct.Name;
            productDescriptionTextView.Text = selectedProduct.Description;
            productPriceTextView.Text = selectedProduct.Price + " Ron";
        }



        private void FindViews()
        {
            productNameTextView = FindViewById<TextView>(Resource.Id.productNametextView2);
            productDescriptionTextView = FindViewById<TextView>(Resource.Id.ProductDescriptionTextView);
            productPriceTextView = FindViewById<TextView>(Resource.Id.productPricetextView);
            productQuantityEditText = FindViewById<EditText>(Resource.Id.productQuantityEditText);
            btnAddToChart = FindViewById<Button>(Resource.Id.buttonAddChart);
            btnAddQuantity = FindViewById<Button>(Resource.Id.buttonAddQuantity);


        }
    }
}