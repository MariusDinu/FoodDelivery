using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using FoodDelivery.Adapters;
using FoodDelivery.Model;
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
        private Button plus;
        private Button minus;

        private TextView quantity;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ShoppingChart);
            chartRecyclerView = FindViewById<RecyclerView>(Resource.Id.shoppingChartRecyclerView);
            order = FindViewById<Button>(Resource.Id.buttonOrderFinal);
            plus = FindViewById<Button>(Resource.Id.buttonPlus);
            minus = FindViewById<Button>(Resource.Id.buttonMinus);
            quantity = FindViewById<TextView>(Resource.Id.ProductQuantityOrder);
            chartLayoutManager = new LinearLayoutManager(this);
            chartRecyclerView.SetLayoutManager(chartLayoutManager);
            chartAdapter = new ShoppingChartAdapter(ListProducts.listProducts);
            chartRecyclerView.SetAdapter(chartAdapter);
            chartAdapter.ItemClick += ShoppingChartAdapter_ItemClick;
            //minus.Click += (sender, e) => MinusQuantity(id);
            //plus.Click += (sender, e) => PlusQuantity(id);
            LinkEventHandler();
            // Create your application here
        }

        private void LinkEventHandler()
        {
            order.Click += Order_Click; 
        }

        




        private void Order_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        


        private void ShoppingChartAdapter_ItemClick(object sender, int id)
        {
            
        }

        private void PlusQuantity(int id)
        {
            var count = int.Parse(quantity.Text);
            count++;
            quantity.Text = count.ToString();
        }

        private void MinusQuantity(int id)
        {
            var count = int.Parse(quantity.Text);
            count--;
            quantity.Text = count.ToString();
        }
    }
}