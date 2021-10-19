using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using FoodDelivery.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FoodDelivery
{
    [Activity(Label = "ProductDetail")]
    public class ProductDetail : Activity
    {
        private Button btnAddToChart;
        private Button btnRemovefromChart;
        private ShoppingChartItem _selectedProduct;
        private ShoppingChartRepository _itemrepository;
        private TextView _productNameTextView;
        private TextView _productDescriptionTextView;
        private TextView _productPriceTextView;
        private EditText _productQuantityEditText;
        //private ImageView _productInageTextView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ProductDetail);
            _itemrepository = new ShoppingChartRepository();
            var selectedItem = Intent.Extras.GetInt("selectedItemId");
            _selectedProduct = _itemrepository.GetProductById(selectedItem);
            
            FindViews();
            BinData();
            btnAddToChart.Click += BtnAddToChart_Click;
            // Create your application here
        }

        private void BinData()
        {
            _productNameTextView.Text = _selectedProduct.Product.Name;
            _productDescriptionTextView.Text = _selectedProduct.Product.Description;
            _productPriceTextView.Text = _selectedProduct.Product.Price;
        }

       

        private void FindViews()
        {
            _productNameTextView = FindViewById<TextView>(Resource.Id.productNametextView2);
            _productDescriptionTextView = FindViewById<TextView>(Resource.Id.ProductDescriptionTextView);
            _productPriceTextView = FindViewById<TextView>(Resource.Id.productPricetextView);
            _productQuantityEditText = FindViewById<EditText>(Resource.Id.productQuantityEditText);
            btnAddToChart = FindViewById<Button>(Resource.Id.btnAdd);
           
           
        }

        private void BtnAddToChart_Click(object sender, EventArgs e)
        {
            var quantity = int.Parse(_productQuantityEditText.Text);
            ShoppingChartRepository repository = new ShoppingChartRepository();
            repository.AddToShoppingCart(_selectedProduct);
            this.Finish();
        }
    }
}