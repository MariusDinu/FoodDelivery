using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using System;

namespace FoodDelivery.ViewHolder
{
    public class ShoppingChartViewHolder : RecyclerView.ViewHolder
    {

        public ImageView ProductImage { get; set; }
        public TextView ProductName { get; set; }

        public TextView Quantity { get; set; }

        public ShoppingChartViewHolder(View itemView, Action<int> listener) : base(itemView)
        {
            ProductImage = itemView.FindViewById<ImageView>(Resource.Id.productImageView);
            ProductName = itemView.FindViewById<TextView>(Resource.Id.ProductNameOrder);
            Quantity = itemView.FindViewById<TextView>(Resource.Id.ProductQuantityOrder);
            itemView.Click += (sender, e) => listener(base.LayoutPosition);
        }
    }
}