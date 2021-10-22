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
    public class OrderProductsAdapter : RecyclerView.Adapter
    {
        List<Product> products=new List<Product>();
        List<ItemList> quantity=new List<ItemList>();
        public OrderProductsAdapter(List<Product> products, List<ItemList> quantity) {
            this.products = products;
            this.quantity = quantity;
        }
        public override int ItemCount => products.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            if (holder is OrderProductsViewHolder orderProductsViewHolder)
            {
                orderProductsViewHolder.Name.Text = products[position].Name;
                orderProductsViewHolder.Quantity.Text = quantity[position].Quantity.ToString();
            }
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.OrderProductsViewHolder, parent, false);
            OrderProductsViewHolder orderProductsViewHolder = new OrderProductsViewHolder(itemView);
            return orderProductsViewHolder;
        }
    }


}