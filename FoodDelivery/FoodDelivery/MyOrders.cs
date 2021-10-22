using Android.App;
using Android.Content;
using Android.OS;
using AndroidX.RecyclerView.Widget;
using FoodDelivery.Adapters;
using FoodDelivery.Model;
using FoodDelivery.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDelivery
{
    [Activity(Label = "MyOrders")]
    public class MyOrders : Activity
    {
        private RecyclerView orderRecyclerView;
        private RecyclerView.LayoutManager orderLayoutManager;
        private OrdersAdapter orderAdapter;
        private OrderRepository orderRepository;
        private RestaurantRepository restaurantRepository;
        private IEnumerable<Order> ordersList;
        private List<string> senderStrings = new List<string>();

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.MyOrders);
            orderRepository = new OrderRepository();
            restaurantRepository = new RestaurantRepository();
            ordersList = await LoadDataAsync();
            await LoadDataNamesAsync(ordersList);


            orderRecyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerViewMyOrders);
            orderLayoutManager = new LinearLayoutManager(this);
            orderRecyclerView.SetLayoutManager(orderLayoutManager);
            orderAdapter = new OrdersAdapter(ordersList.ToList(), senderStrings);
            orderRecyclerView.SetAdapter(orderAdapter);
            orderAdapter.ItemClick += OrdersAdapter_ItemClick;

            // Create your application here
        }

        private void OrdersAdapter_ItemClick(object sender, int e)
        {
            var intent = new Intent();
            intent.SetClass(this, typeof(OrderDetail));
            intent.PutExtra("orderId", e);
            StartActivity(intent);
        }

        private async Task<IEnumerable<Order>> LoadDataAsync()
        {
            IEnumerable<Order> orders = await orderRepository.GetOrders();
            return orders;
        }

        private async Task LoadDataNamesAsync(IEnumerable<Order> orders)
        {
            foreach (var item in orders)
            {
                string reader = await restaurantRepository.GetRestaurant(item.IdRestaurant);
                senderStrings.Add(reader);
            }
        }


    }
}