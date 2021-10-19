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
    class ShoppingChartAdapter : RecyclerView.Adapter
    {
        public List<ShoppingChartItem> ShoppingChart;
        public override int ItemCount => ShoppingChart.Count;

        public Action ItemClick { get; internal set; }

        public ShoppingChartAdapter()
        {
            ShoppingChart = new List<ShoppingChartItem>();
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            if (holder is ShoppingChartViewHolder shoppingChartViewHolder)
            {
                shoppingChartViewHolder.ProductName.Text = ShoppingChart[position].Product.Name;
                shoppingChartViewHolder.Quantity.Text = ShoppingChart[position].Quantity.ToString();

            }
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.ShoppingChartViewHolder, parent, false);
            ShoppingChartViewHolder restaurantViewHolder = new ShoppingChartViewHolder(itemView);
            return restaurantViewHolder;
        }
    }
}