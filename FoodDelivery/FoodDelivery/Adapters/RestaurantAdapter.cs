using Android.Views;
using AndroidX.RecyclerView.Widget;
using FoodDelivery.Model;
using FoodDelivery.ViewHolder;
using System;
using System.Collections.Generic;

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
        public Action<object, int> ItemClick { get; internal set; }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            if (holder is RestaurantViewHolder restaurantViewHolder)
            {
                restaurantViewHolder.RestaurantNameView.Text = _restaurants[position].RestaurantName;

                //add image
                
            }
        }


        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.RestaurantViewHolder, parent, false);
            RestaurantViewHolder restaurantViewHolder = new RestaurantViewHolder(itemView, OnClick);
            return restaurantViewHolder;
        }

        private void OnClick(int position)
        {
            var productId = _restaurants[position].Id;
            ItemClick?.Invoke(this, productId);
        }
    }
}