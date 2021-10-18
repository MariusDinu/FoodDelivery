using Android.App;
using Android.Content;
using Android.OS;
using AndroidX.RecyclerView.Widget;
using FoodDelivery.Adapters;
using FoodDelivery.Repository;

namespace FoodDelivery
{
    [Activity(Label = "RestaurantMenu")]
    public class RestaurantMenu : Activity

    {
        private RecyclerView _productRecyclerView;
        private RecyclerView.LayoutManager _productLayoutManager;
        private ProductAdapter _productAdapter;
        private RestaurantRepository restaurantRepository;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            _productRecyclerView = FindViewById<RecyclerView>(Resource.Id.restaurantMenuRecyclerView);
            _productLayoutManager = new LinearLayoutManager(this);
            _productRecyclerView.SetLayoutManager(_productLayoutManager);
            _productAdapter = new ProductAdapter();
            _productAdapter.ItemClick += ProductAdapter_ItemClick;
            // Create your application here

            restaurantRepository = new RestaurantRepository();
            LoadDataAsync();


        }

        private async void LoadDataAsync()
        {
            var response = await restaurantRepository.GetProducts(Intent.GetIntExtra("id", 0));
        }

        private void ProductAdapter_ItemClick(object sender, int e)
        {
            //var intent = new Intent();
            //intent.SetClass(this, typeof());
            //intent.PutExtra("selectedPieId", e);
            //StartActivity(intent);
        }

        private void FindViews()
        {
            //productimageview = FindViewById<ImageView>(Resource.Id.pieImageView);
            //producttextview = FindViewById<TextView>(Resource.Id.pieNameTextView).Text;
            //properties to get values and show on the view

        }
        private void BinData()
        {
            //_pieNameTextView = _selectedPie.Name;
            //do it for all properties
        }
    }
}