using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using FoodDelivery.Model;
using Newtonsoft.Json;
using Plugin.SecureStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Message = FoodDelivery.Model;

namespace FoodDelivery.Repository
{
    public class ApiRepository
    {
        private Response mess;

        public async Task<string> Registration(User user)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://192.168.100.37:5000");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //call api from FoodDeliveryApi
            var response = await client.PostAsync("/user/add", new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json"));

            //convert to response 
            mess = JsonConvert.DeserializeObject<Response>(response.Content.ReadAsStringAsync().Result);

            //if the call fail response still have message and succes
            if (!response.IsSuccessStatusCode) return mess.Message;

            //save the token in secure storage
            JwtRepository.SaveJWT(mess.Token);
            return mess.Succes.ToString();
        }

        public async Task<string> Login(User user)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://192.168.100.37:5000");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            /*call api from FoodDeliveryApi*/
            var response = await client.PostAsync("/user/auth", new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json"));

            /*if the call fail response still have message and succes*/
            mess = JsonConvert.DeserializeObject<Response>(response.Content.ReadAsStringAsync().Result);

            /*save the token in secure storage*/
            if (!response.IsSuccessStatusCode) return mess.Message;

            /*save the token in secure storage*/
            JwtRepository.SaveJWT(mess.Token);
            return mess.Succes.ToString();
        }

        public async Task<User> GetProfile() {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://192.168.100.37:5000");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JwtRepository.GetJWT());
            /*call api from FoodDeliveryApi*/
            var response = await client.GetAsync("/user/profile");

            /*if the call fail response still have message and succes*/
            User user= JsonConvert.DeserializeObject<User>(response.Content.ReadAsStringAsync().Result);

            return user;
        }
        public async Task<IEnumerable<Restaurant>> GetRestaurants() {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://192.168.100.37:5000");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JwtRepository.GetJWT());
            /*call api from FoodDeliveryApi*/
            var response = await client.GetAsync("/restaurant/get");

            /*if the call fail response still have message and succes*/
            IEnumerable<Restaurant> listRestaurants = JsonConvert.DeserializeObject<IEnumerable<Restaurant>>(response.Content.ReadAsStringAsync().Result);

            return listRestaurants;

      
        }
        public User CreateUser(string username, string email, string password)
        {
            User user = new User(username, email, password);
            return user;
        }
        public User CreateUser(string username, string password)
        {
            User user = new User(username, password);
            return user;
        }
        public ApiRepository() { }


    }
}