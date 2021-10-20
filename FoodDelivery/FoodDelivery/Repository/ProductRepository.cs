using Android.App;
using Android.Content;
using FoodDelivery.Model;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace FoodDelivery.Repository
{
    public class ProductRepository
    {
        private readonly Config config;
        private HttpRepository httpRepository;
        ISharedPreferences pref;

        public async Task<Product> GetProduct(int id)
        {
            var response = await httpRepository.client.GetAsync(config.Product + id);
            Product product = JsonConvert.DeserializeObject<Product>(response.Content.ReadAsStringAsync().Result);

            return product;
        }

        public ProductRepository()
        {
            this.httpRepository = new HttpRepository();
            pref = Application.Context.GetSharedPreferences("PathInfo", FileCreationMode.Private);
            string paths = pref.GetString("Paths", String.Empty);
            this.config = JsonConvert.DeserializeObject<Config>(paths);
        }
    }
}