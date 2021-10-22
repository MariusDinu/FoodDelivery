using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using FoodDelivery.Model;
using FoodDelivery.Repository;
using FoodDelivery.ViewHolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FoodDelivery.Adapters
{
    public class OrdersAdapter : RecyclerView.Adapter
    {
        private List<Order> orders;
        private List<string> Names;
 
        public override int ItemCount => orders.Count;
        public Action<object, int> ItemClick { get; internal set; }

        public OrdersAdapter(List<Order> orders,List<string> names) {
            this.orders = orders;
            this.Names = names;
        }

       
        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            if (holder is OrderViewHolder orderViewHolder)
            {

                
                orderViewHolder.Restaurant.Text =Names[position];
                orderViewHolder.Date.Text = orders[position].CreatedAt.ToString();
                orderViewHolder.Price.Text = orders[position].Price;
                orderViewHolder.Status.Text = orders[position].Status;
                //add image

            }
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.MyOrderViewHolder, parent, false);
            OrderViewHolder orderViewHolder = new OrderViewHolder(itemView, OnClick);
            return orderViewHolder;
        }

        private void OnClick(int position)
        {
            var orderId = orders[position].Id;
            ItemClick?.Invoke(this, orderId);
        }
    }


}