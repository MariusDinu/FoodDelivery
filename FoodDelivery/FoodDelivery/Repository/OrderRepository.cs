using Android.App;
using Android.Content;
using FoodDelivery.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.Repository
{
    public class OrderRepository
    {
        private Response mess;
        private readonly Config config;
        private HttpRepository httpRepository;
        private ProductRepository productRepository=new ProductRepository();
        ISharedPreferences pref;
        public async Task<string> AddOrder(Order order)
        {

            //call api from FoodDeliveryApi
            var response = await httpRepository.client.PostAsync(config.Command, new StringContent(JsonConvert.SerializeObject(order), Encoding.UTF8, "application/json"));
            //convert to response 
            mess = JsonConvert.DeserializeObject<Response>(response.Content.ReadAsStringAsync().Result);
            //if the call fail response still have message and succes
            if (!response.IsSuccessStatusCode) return mess.Message;

            return mess.Succes.ToString();
        }

        public async Task<IEnumerable<Order>> GetOrders()
        {

            //call api from FoodDeliveryApi
            var response = await httpRepository.client.GetAsync(config.Orders);

            //convert to response 
            IEnumerable<Order>  list = JsonConvert.DeserializeObject<IEnumerable<Order>>(response.Content.ReadAsStringAsync().Result);

            //if the call fail response still have message and succes
            return list;
        }

        public async Task<Order> GetOrder(int id)
        {

            //call api from FoodDeliveryApi
            var response = await httpRepository.client.GetAsync(config.Order+id);

            //convert to response 
            Order order = JsonConvert.DeserializeObject<Order>(response.Content.ReadAsStringAsync().Result);

            //if the call fail response still have message and succes
            return order;
        }
        public Order CreateOrder(string price)
        {

           // {"2":"2","1":"3" }
            Order order = new Order(ListProducts.IdRestaurant,CreateStringForProducts(), price.ToString(), "Piata Unirii", "Delivering");
            return order;
        }
        public OrderRepository()
        {
            httpRepository = new HttpRepository();
            pref = Application.Context.GetSharedPreferences("PathInfo", FileCreationMode.Private);
            string paths = pref.GetString("Paths", string.Empty);
            config = JsonConvert.DeserializeObject<Config>(paths);
        }

        public async Task<List<Product>> ReadStringAsync(string path) {
            List<Product> products = new List<Product>();
            List<ItemList> list = JsonConvert.DeserializeObject < List<ItemList>>(path);
            foreach (var item in list) {

                Product product = await productRepository.GetProduct(item.Id);
                products.Add(product);
            }
            return products;
        }

        public string CreateStringForProducts() {


            string com1 = "{";
            string com2 = "}";
            string com3 = "[";
            string com4 = "]";
            string array = "";
            int count = 0;
            foreach(var item in ListProducts.list)
            {
                
                array =array+com1+ '"'+"id"+'"'+":"+'"' + item.Id +'"'+','+ '"'+ "quantity"+ '"'+":" + '"' + item.Quantity + '"'+com2;
                if (count >= 0 &&count<=ListProducts.list.Count) { array += ','; }
                count++;
            }
            return com3 + array + com4;
        
        }
    }
}