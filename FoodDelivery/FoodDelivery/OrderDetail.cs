using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using FoodDelivery.Adapters;
using FoodDelivery.Model;
using FoodDelivery.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodDelivery
{
    [Activity(Label = "OrderDetail")]
    public class OrderDetail : Activity
    {

        private OrderRepository orderRepository;
        private RestaurantRepository restaurantRepository;
        private FullOrder order;
        List<Product> products = new List<Product>();
        readonly List<ItemList> list = new List<ItemList>();
        private TextView restaurant;
        private TextView date;
        private TextView price;
        private TextView status;
        private string name;
        private RecyclerView orderProductsRecyclerView;
        private RecyclerView.LayoutManager orderProductsLayoutManager;
        private OrderProductsAdapter orderProductsAdapter;
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.OrderDetail);
            orderRepository = new OrderRepository();
            restaurantRepository = new RestaurantRepository();
            order = await LoadDataAsync();
            products = await orderRepository.ReadStringAsync(order.orderProducts);

            name = await GetRestaurantName(order.order.IdRestaurant);

            FindViews();
            orderProductsRecyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerViewOrderProducts);
            orderProductsLayoutManager = new LinearLayoutManager(this);
            orderProductsRecyclerView.SetLayoutManager(orderProductsLayoutManager);
            orderProductsAdapter = new OrderProductsAdapter(products, order.orderProducts);
            orderProductsRecyclerView.SetAdapter(orderProductsAdapter);
            BindData();
        }



        private async Task<string> GetRestaurantName(int idRestaurant)
        {
            var response = await restaurantRepository.GetRestaurant(idRestaurant);
            return response;
        }



        private async Task<FullOrder> LoadDataAsync()
        {
            try
            {
                FullOrder order = await orderRepository.GetOrder(Intent.Extras.GetInt("orderId"));
                return order;
            }
            catch (Exception) { Toast.MakeText(Application.Context, GetString(Resource.String.FailedAgainMsg), ToastLength.Long).Show(); return null; }
        }

        private void BindData()
        {
            restaurant.Text = name;
            date.Text = order.order.CreatedAt.ToString();
            price.Text = order.order.Price + GetString(Resource.String.priceCurrency);
            status.Text = order.order.Status;
        }

        private void FindViews()
        {
            restaurant = FindViewById<TextView>(Resource.Id.textViewOrderDetailRestaurant);
            date = FindViewById<TextView>(Resource.Id.textViewOrderDetailDate);
            price = FindViewById<TextView>(Resource.Id.textViewOrderDetailPrice);
            status = FindViewById<TextView>(Resource.Id.textViewOrderDetailStatus);
        }

    }
}