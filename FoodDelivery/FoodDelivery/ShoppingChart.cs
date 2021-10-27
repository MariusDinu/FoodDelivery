using Android.App;
using Android.OS;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using FoodDelivery.Adapters;
using FoodDelivery.Model;
using FoodDelivery.Repository;
using System;
using System.Collections.Generic;

namespace FoodDelivery
{
    [Activity(Label = "ShoppingChart")]
    public class ShoppingChart : Activity
    {
        private RecyclerView chartRecyclerView;
        private RecyclerView.LayoutManager chartLayoutManager;
        private ShoppingChartAdapter chartAdapter;
        private Button order;
        public static TextView price;
        private OrderRepository orderRepository;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ShoppingChart);
            chartRecyclerView = FindViewById<RecyclerView>(Resource.Id.shoppingChartRecyclerView);
            order = FindViewById<Button>(Resource.Id.buttonOrderFinal);
            price = FindViewById<TextView>(Resource.Id.shoppingChartPriceInput);
            chartLayoutManager = new LinearLayoutManager(this);
            chartRecyclerView.SetLayoutManager(chartLayoutManager);
            chartAdapter = new ShoppingChartAdapter(ListProducts.listProducts);
            chartRecyclerView.SetAdapter(chartAdapter);
            orderRepository = new OrderRepository();

            price.Text = ChartRepository.GetMoney().ToString();
            LinkEventHandler();
        }

        public static void RefreshPage()
        {
            price.Text = ChartRepository.GetMoney().ToString();
        }
        private void LinkEventHandler()
        {
            order.Click += Order_Click;
        }


        private async void Order_Click(object sender, System.EventArgs e)
        {
            Order order = orderRepository.CreateOrder(price.Text);
            List<OrderProducts> orderProducts = orderRepository.CreateOrderProducts();
            FullOrder fullOrder = new FullOrder(order, orderProducts);
            var response = await orderRepository.AddOrder(fullOrder);
            try
            {
                if (response.Equals("True"))
                {
                    ListProducts.list.Clear();
                    ListProducts.listProducts.Clear();
                    ListProducts.IdRestaurant = 0;
                    Toast.MakeText(Application.Context, GetString(Resource.String.SuccesMsg), ToastLength.Long).Show();
                    Finish();
                }
                else
                {
                    Toast.MakeText(Application.Context, GetString(Resource.String.FailedMsg), ToastLength.Long).Show();
                }
            }
            catch (Exception) { Toast.MakeText(Application.Context, GetString(Resource.String.FailedAgainMsg), ToastLength.Long).Show(); }
        }
    }
}