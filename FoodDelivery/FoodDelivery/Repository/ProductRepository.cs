using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using FoodDelivery.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.Repository
{
   public class ProductRepository
    {
        public async Task<Product> GetProduct(int id)
        {
            //add in stirngs
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://192.168.100.37:5000");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JwtRepository.GetJWT());
            /*call api from FoodDeliveryApi*/
            var response = await client.GetAsync("/product/get/" + id);

            /*if the call fail response still have message and succes*/
            Product product = JsonConvert.DeserializeObject<Product>(response.Content.ReadAsStringAsync().Result);

            return product;
        }

        public ProductRepository() { }
    }
}