using Android.App;
using Android.OS;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using FoodDelivery.Adapters;
using FoodDelivery.Model;
using FoodDelivery.Repository;

namespace FoodDelivery
{
    [Activity(Label = "ShoppingChart")]
    public class ShoppingChart : Activity
    {
        private RecyclerView chartRecyclerView;
        private RecyclerView.LayoutManager chartLayoutManager;
        private ShoppingChartAdapter chartAdapter;
        private Button order;
        private TextView price;
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
            chartAdapter.ItemClick += ShoppingChartAdapter_ItemClick;
            chart = new ChartRepository();
            orderRepository = new OrderRepository();
            price.Text = chart.GetMoney().ToString();
            LinkEventHandler();
            // Create your application here
        }

        private void LinkEventHandler()
        {
            order.Click += Order_Click;
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




        private void ShoppingChartAdapter_ItemClick(object sender, int id)
        {

        }


    }
}