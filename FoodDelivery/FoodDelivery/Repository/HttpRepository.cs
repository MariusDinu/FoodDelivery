using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace FoodDelivery.Repository
{
    public class HttpRepository
    {
        public HttpClient client;
        public HttpRepository()
        {
            this.client = new HttpClient
            {
                BaseAddress = new Uri("http://192.168.100.37:5000")
            };
            this.client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            if (JwtRepository.CheckJWT())
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JwtRepository.GetJWT());


        }
    }
}