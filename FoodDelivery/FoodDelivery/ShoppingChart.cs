using Android.App;
using Android.OS;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using FoodDelivery.Adapters;
using FoodDelivery.Model;
using FoodDelivery.Repository;
using Java.Lang;
using System;

namespace FoodDelivery
{
    [Activity(Label = "ShoppingChart")]
    public class ShoppingChart : Activity
    {
        private RecyclerView chartRecyclerView;
        private RecyclerView.LayoutManager chartLayoutManager;
        private ShoppingChartAdapter chartAdapter;
        private Button order;
        public TextView price;
        private ChartRepository chart;
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
            chart = new ChartRepository();
            orderRepository = new OrderRepository();
            price.Text = ChartRepository.GetMoney().ToString();
            LinkEventHandler();

        }
        public override void OnContentChanged()
        {
            price = FindViewById<TextView>(Resource.Id.shoppingChartPriceInput);
            price.Text = ChartRepository.GetMoney().ToString();
        }
        private void LinkEventHandler()
        {
            order.Click += Order_Click;
        }

        public void RefreshContent() {
            price = FindViewById<TextView>(Resource.Id.shoppingChartPriceInput);
            price.Text = ChartRepository.GetMoney().ToString();
        }
   


        private async void Order_Click(object sender, System.EventArgs e)
        {
            Order order = orderRepository.CreateOrder(price.Text);
            var response = await orderRepository.AddOrder(order);
            if (response.Equals("True"))
            {
                Toast.MakeText(Application.Context, "Succes!", ToastLength.Long).Show();
                Finish();
            }
            else
            {
                Toast.MakeText(Application.Context, "Failed!", ToastLength.Long).Show();
            }
        }

    


    }
}