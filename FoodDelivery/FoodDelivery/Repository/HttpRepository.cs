using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace FoodDelivery.Repository
{
    public class HttpRepository
    {
        public HttpClient client;
        public HttpRepository() {
            this.client = new HttpClient
            {
                BaseAddress = new Uri("http://192.168.100.37:5000")
            };
            this.client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
       

        }
    }
}