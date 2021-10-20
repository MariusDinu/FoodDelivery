using Android.Views;
using AndroidX.RecyclerView.Widget;
using FoodDelivery.Model;
using FoodDelivery.ViewHolder;
using System;
using System.Collections.Generic;

namespace FoodDelivery.Adapters
{
    class ShoppingChartAdapter : RecyclerView.Adapter
    {
        List<ItemChart> list;
        public override int ItemCount => list.Count;

        public Action<object, int> ItemClick { get; internal set; }

        public ShoppingChartAdapter(List<ItemChart> list)
        {
            this.list = list;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            if (holder is ShoppingChartViewHolder shoppingChartViewHolder)
            {

                var product = list[position].Product.Name;
                shoppingChartViewHolder.ProductName.Text = product;
                shoppingChartViewHolder.Quantity.Text = list[position].Quantity.ToString();

            }
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.ShoppingChartViewHolder, parent, false);
            ShoppingChartViewHolder restaurantViewHolder = new ShoppingChartViewHolder(itemView, OnClick);
            return restaurantViewHolder;
        }

        private void OnClick(int position)
        {
            var productId = list[position].Product.Id;
            ItemClick?.Invoke(this, productId);
        }
    }
}