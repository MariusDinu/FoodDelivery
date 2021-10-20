using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using FoodDelivery.Model;
using FoodDelivery.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery
{
    [Activity(Label = "ProductDetail")]
    public class ProductDetail : Activity
    {
        private Button btnAddToChart;
        //private Button btnRemovefromChart;
        private ProductRepository productRepository;
        private Product selectedProduct;
        private TextView _productNameTextView;
        private TextView _productDescriptionTextView;
        private TextView _productPriceTextView;
        private EditText _productQuantityEditText;
        //private ImageView _productInageTextView;
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ProductDetail);
            productRepository = new ProductRepository();//repo with all products
            //_chartRepository = new ShoppingChartRepository(); //repo with chart items
            selectedProduct = await LoadDataAsync();           
            FindViews();
            BinData();
          //  btnAddToChart.Click += BtnAddToChart_Click;
          
        }

        private async Task<Product> LoadDataAsync()
        {
            Product product = await productRepository.GetProduct(Intent.Extras.GetInt("productId"));
            return product;
        }

        private void BinData()
        {
            _productNameTextView.Text = selectedProduct.Name;
            _productDescriptionTextView.Text = selectedProduct.Description;
            _productPriceTextView.Text = selectedProduct.Price+" Ron";
        }

       

        private void FindViews()
        {
            _productNameTextView = FindViewById<TextView>(Resource.Id.productNametextView2);
            _productDescriptionTextView = FindViewById<TextView>(Resource.Id.ProductDescriptionTextView);
            _productPriceTextView = FindViewById<TextView>(Resource.Id.productPricetextView);
            _productQuantityEditText = FindViewById<EditText>(Resource.Id.productQuantityEditText);
            btnAddToChart = FindViewById<Button>(Resource.Id.btnAdd);
           
           
        }

        /*private void BtnAddToChart_Click(object sender, EventArgs e)
        {
            var quantity = int.Parse(_productQuantityEditText.Text);
            _selectedProduct.Quantity = quantity;
            _chartRepository.AddToShoppingCart(_selectedProduct);
            this.Finish();
        }*/
    }
}