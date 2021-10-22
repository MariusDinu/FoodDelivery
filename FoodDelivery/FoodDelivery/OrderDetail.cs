using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using FoodDelivery.Adapters;
using FoodDelivery.Model;
using FoodDelivery.Repository;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodDelivery
{
    [Activity(Label = "OrderDetail")]
    public class OrderDetail : Activity
    {

        private OrderRepository orderRepository;
        private RestaurantRepository restaurantRepository;
        private Order order;
        List<Product> products = new List<Product>();
        List<ItemList> list = new List<ItemList>();
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
            List<Product> products = await ReadProductsAsync(order.Products);
            list = JsonConvert.DeserializeObject<List<ItemList>>(order.Products);
            name = await GetRestaurantName(order.IdRestaurant);
            // Create your application here
            FindViews();
            orderProductsRecyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerViewOrderProducts);
            orderProductsLayoutManager = new LinearLayoutManager(this);
            orderProductsRecyclerView.SetLayoutManager(orderProductsLayoutManager);
            orderProductsAdapter = new OrderProductsAdapter(products, list);
            orderProductsRecyclerView.SetAdapter(orderProductsAdapter);

            BindData();
        }

        private async Task<string> GetRestaurantName(int idRestaurant)
        {
            var response = await restaurantRepository.GetRestaurant(idRestaurant);
            return response;
        }

        private async Task<List<Product>> ReadProductsAsync(string productsString)
        {
            products = await orderRepository.ReadStringAsync(productsString);
            return products;
        }

        private async Task<Order> LoadDataAsync()
        {
            Order order = await orderRepository.GetOrder(Intent.Extras.GetInt("orderId"));
            return order;
        }

        private void BindData()
        {
            restaurant.Text = name;
            date.Text = order.CreatedAt.ToString();
            price.Text = order.Price + " Ron";
            status.Text = order.Status;
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