using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using FoodDelivery.ViewHolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FoodDelivery.Model;




namespace FoodDelivery.Adapters
{
    public class ProductAdapter : RecyclerView.Adapter
    {
        private List<Product> _products;
        public ProductAdapter()
        {
            _products = new List<Product>();           
        }
        public override int ItemCount => _products.Count;
        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            if (holder is ProductViewHolder productViewHolder)
            {
                productViewHolder.ProductTextView.Text = _products[position].Name;
                productViewHolder.ProductTextView.Text = _products[position].Description;
                productViewHolder.ProductTextView.Text = _products[position].Price;

                // var image to get the image min 9.45 / 5.4

            }
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.ProductViewHolder, parent, false);
            ProductViewHolder productViewHolder = new ProductViewHolder(itemView);
            return productViewHolder;
        }
    }
}