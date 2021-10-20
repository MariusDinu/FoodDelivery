
using Android.Content;
using FoodDelivery.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.Repository
{
    public class ApiRepository
    {
        private Response mess;
        private readonly Config config;
        private HttpRepository httpRepository;
        ISharedPreferences pref;
        public async Task<string> Registration(User user)
        {

            //call api from FoodDeliveryApi
            var response = await httpRepository.client.PostAsync(config.Register, new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json"));

            //convert to response 
            mess = JsonConvert.DeserializeObject<Response>(response.Content.ReadAsStringAsync().Result);

            //if the call fail response still have message and succes
            if (!response.IsSuccessStatusCode) return mess.Message;

            //save the token in secure storage
            //delete token*
            JwtRepository.SaveJWT(mess.Token);
            return mess.Succes.ToString();
        }

        public async Task<string> Login(User user)
        {



            /*call api from FoodDeliveryApi*/
            var response = await httpRepository.client.PostAsync(config.Login, new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json"));

            /*if the call fail response still have message and succes*/
            mess = JsonConvert.DeserializeObject<Response>(response.Content.ReadAsStringAsync().Result);

            /*save the token in secure storage*/
            if (!response.IsSuccessStatusCode) return mess.Message;

            /*save the token in secure storage*/
            JwtRepository.SaveJWT(mess.Token);
            return mess.Succes.ToString();
        }

        public async Task<User> GetProfile()
        {
            /*call api from FoodDeliveryApi*/
            var response = await httpRepository.client.GetAsync(config.Profile);

            /*if the call fail response still have message and succes*/
            User user = JsonConvert.DeserializeObject<User>(response.Content.ReadAsStringAsync().Result);

            return user;
        }
        public async Task<IEnumerable<Restaurant>> GetRestaurants()
        {
            /*call api from FoodDeliveryApi*/
            var response = await httpRepository.client.GetAsync(config.Restaurants);

            /*if the call fail response still have message and succes*/
            IEnumerable<Restaurant> listRestaurants = JsonConvert.DeserializeObject<IEnumerable<Restaurant>>(response.Content.ReadAsStringAsync().Result);

            return listRestaurants;


        }

        //rework email=null;
        public User CreateUser(string username, string email, string password)
        {
            User user = new User(username, email, password);
            return user;
        }
        public ApiRepository()
        {

            httpRepository = new HttpRepository();
            pref = Android.App.Application.Context.GetSharedPreferences("PathInfo", FileCreationMode.Private);
            string paths = pref.GetString("Paths", string.Empty);
            config = JsonConvert.DeserializeObject<Config>(paths);
        }
    }
}