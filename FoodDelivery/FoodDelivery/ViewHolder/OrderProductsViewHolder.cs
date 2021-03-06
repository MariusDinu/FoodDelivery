using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;

namespace FoodDelivery.ViewHolder
{
    public class OrderProductsViewHolder : RecyclerView.ViewHolder
    {
        public ImageView Image { get; set; }
        public TextView Name { get; set; }
        public TextView Quantity { get; set; }
        public OrderProductsViewHolder(View itemView) : base(itemView)
        {
            Image = itemView.FindViewById<ImageView>(Resource.Id.imageViewHolderOrderProducts);
            Name = itemView.FindViewById<TextView>(Resource.Id.nameViewHolderOrderProducts);
            Quantity = itemView.FindViewById<TextView>(Resource.Id.quantityViewHolderOrderProducts);

        }
    }
}