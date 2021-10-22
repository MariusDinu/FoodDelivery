using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using System;

namespace FoodDelivery.ViewHolder
{
    public class OrderViewHolder : RecyclerView.ViewHolder
    {
        public TextView Restaurant { get; set; }
        public TextView Date { get; set; }
        public TextView Status { get; set; }
        public TextView Price { get; set; }

        public OrderViewHolder(View itemView, Action<int> listener) : base(itemView)
        {
            Restaurant = itemView.FindViewById<TextView>(Resource.Id.textViewHolderNameOrders);
            Date = itemView.FindViewById<TextView>(Resource.Id.textViewHolderDateOrders);
            Status = itemView.FindViewById<TextView>(Resource.Id.textViewHolderStatusOrders);
            Price = itemView.FindViewById<TextView>(Resource.Id.textViewHolderPriceOrders);

            itemView.Click += (sender, e) => listener(base.LayoutPosition);
        }
    }
}