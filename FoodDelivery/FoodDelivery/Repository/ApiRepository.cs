
using Android.Content;
using FoodDelivery.Model;
using Newtonsoft.Json;
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
            var response = await httpRepository.client.PostAsync(config.Register, new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json"));
            mess = JsonConvert.DeserializeObject<Response>(response.Content.ReadAsStringAsync().Result);

            if (!response.IsSuccessStatusCode) return mess.Message;
            return mess.Succes.ToString();
        }

        public async Task<string> Login(User user)
        {
            var response = await httpRepository.client.PostAsync(config.Login, new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json"));
            mess = JsonConvert.DeserializeObject<Response>(response.Content.ReadAsStringAsync().Result);


            if (!response.IsSuccessStatusCode) return mess.Message;
            JwtRepository.SaveJWT(mess.Token);
            return mess.Succes.ToString();
        }

        public async Task<User> GetProfile()
        {
            var response = await httpRepository.client.GetAsync(config.Profile);
            User user = JsonConvert.DeserializeObject<User>(response.Content.ReadAsStringAsync().Result);
            return user;
        }
        public async Task<IEnumerable<Restaurant>> GetRestaurants()
        {
            var response = await httpRepository.client.GetAsync(config.Restaurants);
            IEnumerable<Restaurant> listRestaurants = JsonConvert.DeserializeObject<IEnumerable<Restaurant>>(response.Content.ReadAsStringAsync().Result);
            return listRestaurants;
        }

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