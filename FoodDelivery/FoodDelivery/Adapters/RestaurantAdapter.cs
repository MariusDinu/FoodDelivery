using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using FoodDelivery.Model;
using FoodDelivery.ViewHolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FoodDelivery.Adapters
{
    class RestaurantAdapter : RecyclerView.Adapter
    {
        private List<Restaurant> _restaurants;
        public RestaurantAdapter()
        {
            _restaurants = new List<Restaurant>();

        }
        public override int ItemCount => _restaurants.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            if (holder is RestaurantViewHolder restaurantViewHolder)
            {
                restaurantViewHolder.RestaurantNameView.Text = _restaurants[position].RestaurantName;
                //productViewHolder.RestaurantNameView.Text = _products[position].Description;
                //productViewHolder.ProductTextView.Text = _products[position].Price;
            }
        }


        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.RestaurantViewHolder, parent, false);
            RestaurantViewHolder restaurantViewHolder = new RestaurantViewHolder(itemView);
            return restaurantViewHolder;
        }
    }
}