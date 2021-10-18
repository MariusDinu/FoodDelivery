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
    public class RestaurantViewHolder: RecyclerView.ViewHolder
    {
        public ImageView RestaurantImageView { get; set; }

        public TextView RestaurantNameView { get; set; }

        public RestaurantViewHolder(View itemView) : base(itemView)
        {
            RestaurantImageView = itemView.FindViewById<ImageView>(Resource.Id.restaurantImageView);
            RestaurantNameView = itemView.FindViewById<TextView>(Resource.Id.restaurantNameTextView);
        }

    }
}