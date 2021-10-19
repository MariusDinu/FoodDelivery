using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using System;

namespace FoodDelivery.ViewHolder
{
    public class ProductViewHolder : RecyclerView.ViewHolder
    {
        public ImageView ProductImageView { get; set; }

        public TextView ProductTextView { get; set; }

        public TextView ProductPriceTextView { get; set; }

        public ProductViewHolder(View itemView, Action<int> listener) : base(itemView)
        {
             ProductImageView = itemView.FindViewById<ImageView>(Resource.Id.productImageView);
             ProductTextView = itemView.FindViewById<TextView>(Resource.Id.productNameTextView);
            ProductPriceTextView = itemView.FindViewById<TextView>(Resource.Id.productPriceTextView);

            itemView.Click += (sender, e) => listener(base.LayoutPosition);
        }

    }
}