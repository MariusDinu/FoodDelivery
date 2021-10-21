using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using FoodDelivery.Repository;
using System;

namespace FoodDelivery.ViewHolder
{
    public class ShoppingChartViewHolder : RecyclerView.ViewHolder
    {
        ChartRepository chart = new ChartRepository();
        public ImageView ProductImage { get; set; }
        public TextView ProductName { get; set; }
        public int id;
        public TextView Quantity { get; set; }

        public Button AddQuantity { get; set; }
        public Button MinusQuantity { get; set; }

        public ShoppingChartViewHolder(View itemView, Action<int> listener) : base(itemView)
        {

            ProductImage = itemView.FindViewById<ImageView>(Resource.Id.productImageView);
            ProductName = itemView.FindViewById<TextView>(Resource.Id.ProductNameOrder);
            Quantity = itemView.FindViewById<TextView>(Resource.Id.ProductQuantityOrder);
            AddQuantity = itemView.FindViewById<Button>(Resource.Id.buttonPlus);
            MinusQuantity = itemView.FindViewById<Button>(Resource.Id.buttonMinus);
            AddQuantity.Click += AddQuantity_Click;
            MinusQuantity.Click += MinusQuantity_Click;
            itemView.Click += (sender, e) => listener(base.LayoutPosition);
        }

        private void MinusQuantity_Click(object sender, EventArgs e)
        {
            var count = int.Parse(Quantity.Text);
            count--;
            Quantity.Text = count.ToString();
            DeleteProducts();
        }

        private void AddQuantity_Click(object sender, EventArgs e)
        {
            var count = int.Parse(Quantity.Text);
            count++;
            Quantity.Text = count.ToString();
            AddProducts();
        }

        private async void AddProducts()
        {
            int quantity = int.Parse(Quantity.Text);
            bool response = await chart.AddProductAsync(base.LayoutPosition, quantity);
        }

        private void DeleteProducts()
        {
            int quantity = int.Parse(Quantity.Text);
            if (quantity == 0)
            { bool response = chart.DeleteProduct(base.LayoutPosition); }

        }
    }
}