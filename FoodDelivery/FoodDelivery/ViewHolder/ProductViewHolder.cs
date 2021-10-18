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
    public class ProductViewHolder:RecyclerView.ViewHolder
    {
        public ImageView ProductImageView { get; set; }

        public TextView ProductTextView { get; set; }

        public ProductViewHolder(View itemView):base(itemView)
        {
           // ProductImageView = itemView.FindViewById<ImageView>(Resource.Id.productImageView);
            //ProductTextView = itemView.FindViewById<TextView>(Resource.Id.productNameTextView);
        }
    
    }
}