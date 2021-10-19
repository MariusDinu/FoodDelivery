using Android.Views;
using AndroidX.RecyclerView.Widget;
using FoodDelivery.Model;
using FoodDelivery.ViewHolder;
using System;
using System.Collections.Generic;




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

        public Action<object, int> ItemClick { get; internal set; }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            if (holder is ProductViewHolder productViewHolder)
            {
                productViewHolder.ProductTextView.Text = _products[position].Name;
                productViewHolder.ProductTextView.Text = _products[position].Description;
                productViewHolder.ProductTextView.Text = _products[position].Price;
            }
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.RestaurantViewHolder, parent, false);
            ProductViewHolder productViewHolder = new ProductViewHolder(itemView, OnClick);
            return productViewHolder;
        }


        private void OnClick(int position)
        {
            var productId = _products[position].Id;
            ItemClick?.Invoke(this, productId);
        }
    }
}