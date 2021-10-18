using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;

namespace FoodDelivery.ViewHolder
{
    public class RestaurantViewHolder : RecyclerView.ViewHolder
    {
        public ImageView RestaurantImageView { get; set; }

        public TextView RestaurantNameView { get; set; }

        public RestaurantViewHolder(View itemView) : base(itemView)
        {
            RestaurantImageView = itemView.FindViewById<ImageView>(Resource.Id.restaurantImageView);
            RestaurantNameView = itemView.FindViewById<TextView>(Resource.Id.restaurantNameTextView);
        }

    }
}