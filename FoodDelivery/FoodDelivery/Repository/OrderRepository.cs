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
        private ProductRepository productRepository = new ProductRepository();
        ISharedPreferences pref;
        public async Task<string> AddOrder(Order order)
        {
            var response = await httpRepository.client.PostAsync(config.Command, new StringContent(JsonConvert.SerializeObject(order), Encoding.UTF8, "application/json"));
            mess = JsonConvert.DeserializeObject<Response>(response.Content.ReadAsStringAsync().Result);

            if (!response.IsSuccessStatusCode) return mess.Message;
            return mess.Succes.ToString();
        }

        public async Task<IEnumerable<Order>> GetOrders()
        {
            var response = await httpRepository.client.GetAsync(config.Orders);
            IEnumerable<Order> list = JsonConvert.DeserializeObject<IEnumerable<Order>>(response.Content.ReadAsStringAsync().Result);

            return list;
        }

        public async Task<Order> GetOrder(int id)
        {
            var response = await httpRepository.client.GetAsync(config.Order + id);
            Order order = JsonConvert.DeserializeObject<Order>(response.Content.ReadAsStringAsync().Result);

            return order;
        }
        public Order CreateOrder(string price)
        {
            Order order = new Order(ListProducts.IdRestaurant, CreateStringForProducts(), price.ToString(), "Piata Unirii", "Delivering");
            return order;
        }
        public OrderRepository()
        {
            httpRepository = new HttpRepository();
            pref = Application.Context.GetSharedPreferences("PathInfo", FileCreationMode.Private);
            string paths = pref.GetString("Paths", string.Empty);
            config = JsonConvert.DeserializeObject<Config>(paths);
        }

        public async Task<List<Product>> ReadStringAsync(string path)
        {
            List<Product> products = new List<Product>();
            List<ItemList> list = JsonConvert.DeserializeObject<List<ItemList>>(path);
            foreach (var item in list)
            {
                Product product = await productRepository.GetProduct(item.Id);
                products.Add(product);
            }
            return products;
        }

        public string CreateStringForProducts()
        {
            string com1 = "{";
            string com2 = "}";
            string com3 = "[";
            string com4 = "]";
            string array = "";
            int count = 0;
            foreach (var item in ListProducts.list)
            {
                count++;
                array = array + com1 + '"' + "id" + '"' + ":" + '"' + item.Id + '"' + ',' + '"' + "quantity" + '"' + ":" + '"' + item.Quantity + '"' + com2;
                if (ListProducts.list.Count != 1 && count < ListProducts.list.Count)
                {
                    array += ',';
                }
            }
            return com3 + array + com4;

        }
    }
}