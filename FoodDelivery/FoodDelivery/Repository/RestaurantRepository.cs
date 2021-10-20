using Android.Content;
using FoodDelivery.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodDelivery.Repository
{
    public class RestaurantRepository
    {
        private readonly Config config;
        private HttpRepository httpRepository;
        ISharedPreferences pref;
        public async Task<IEnumerable<Product>> GetProducts(int id)
        {
            var response = await httpRepository.client.GetAsync(config.Products + id);
            IEnumerable<Product> list = JsonConvert.DeserializeObject<IEnumerable<Product>>(response.Content.ReadAsStringAsync().Result);

            return list;
        }

        public RestaurantRepository()
        {
            this.httpRepository = new HttpRepository();
            pref = Android.App.Application.Context.GetSharedPreferences("PathInfo", FileCreationMode.Private);
            string paths = pref.GetString("Paths", String.Empty);
            this.config = JsonConvert.DeserializeObject<Config>(paths);
        }
    }
}