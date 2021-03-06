using Android.Graphics;
using Android.Util;
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
        public ProductAdapter(List<Product> list)
        {
            _products = list;
        }
        public override int ItemCount => _products.Count;

        public Action<object, int> ItemClick { get; internal set; }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            if (holder is ProductViewHolder productViewHolder)
            {
                productViewHolder.ProductTextView.Text = _products[position].Name;
                // productViewHolder.ProductTextView.Text = _products[position].Description;
                productViewHolder.ProductPriceTextView.Text = _products[position].Price + " Ron";
                byte[] bytes = Base64.Decode(_products[position].ImageData, Base64Flags.Default);
                // Initialize bitmap
                Bitmap bitmap = BitmapFactory.DecodeByteArray(bytes, 0, bytes.Length);
                productViewHolder.ProductImageView.SetImageBitmap(bitmap);
            }
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.ProductViewHolder, parent, false);
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