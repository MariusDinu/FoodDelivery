using FoodDelivery.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace FoodDelivery.Repository
{
    public class RestaurantRepository
    {
        public async Task<IEnumerable<Product>> GetProducts(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://192.168.100.37:5000");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JwtRepository.GetJWT());
            /*call api from FoodDeliveryApi*/
            var response = await client.GetAsync("/product/get/" + id);

            /*if the call fail response still have message and succes*/
            IEnumerable<Product> list = JsonConvert.DeserializeObject<IEnumerable<Product>>(response.Content.ReadAsStringAsync().Result);

            return list;
        }

        public RestaurantRepository() { }
    }
}