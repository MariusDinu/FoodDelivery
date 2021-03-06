using Android.Graphics;
using Android.Util;
using Android.Views;
using AndroidX.RecyclerView.Widget;
using FoodDelivery.Model;
using FoodDelivery.ViewHolder;
using System.Collections.Generic;

namespace FoodDelivery.Adapters
{
    public class OrderProductsAdapter : RecyclerView.Adapter
    {
        readonly List<Product> products = new List<Product>();
        readonly List<OrderProducts> quantity = new List<OrderProducts>();
        public OrderProductsAdapter(List<Product> products, List<OrderProducts> list)
        {
            this.products = products;
            this.quantity = list;
        }
        public override int ItemCount => products.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            if (holder is OrderProductsViewHolder orderProductsViewHolder)
            {
                orderProductsViewHolder.Name.Text = products[position].Name;
                orderProductsViewHolder.Quantity.Text = quantity[position].Quantity.ToString();
                byte[] bytes = Base64.Decode(products[position].ImageData, Base64Flags.Default);
                // Initialize bitmap
                Bitmap bitmap = BitmapFactory.DecodeByteArray(bytes, 0, bytes.Length);
                orderProductsViewHolder.Image.SetImageBitmap(bitmap);
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