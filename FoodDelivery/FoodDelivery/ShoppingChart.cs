using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using FoodDelivery.Adapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FoodDelivery
{
    [Activity(Label = "ShoppingChart")]
    public class ShoppingChart : Activity
    {
        private RecyclerView chartRecyclerView;
        private RecyclerView.LayoutManager chartLayoutManager;
        private ShoppingChartAdapter chartAdapter;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
             chartRecyclerView = FindViewById<RecyclerView>(Resource.Id.shoppingChartRecyclerView);
            chartLayoutManager = new LinearLayoutManager(this);
            chartRecyclerView.SetLayoutManager(chartLayoutManager);
            chartAdapter = new ShoppingChartAdapter();
            chartAdapter.ItemClick += ShoppingChartAdapter_ItemClick;
            // Create your application here
        }

        private void ShoppingChartAdapter_ItemClick()
        {
            var intent = new Intent();
            intent.SetClass(this, typeof(RestaurantMenu));
            StartActivity(intent);
        }
    }
}