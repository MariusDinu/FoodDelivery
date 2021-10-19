using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FoodDelivery.ViewHolder
{
    public class ShoppingChartViewHolder:RecyclerView.ViewHolder
    {

        public ImageView ProductImage { get; set; }
        public TextView ProductName { get; set; }

        public TextView Quantity { get; set; }

        public ShoppingChartViewHolder(View itemView) : base(itemView)
        {
            ProductImage = itemView.FindViewById<ImageView>(Resource.Id.productImageView);
            ProductName = itemView.FindViewById<TextView>(Resource.Id.productNameTextView);
            Quantity = itemView.FindViewById<TextView>(Resource.Id.QuantityTextView);
        }
    }
}