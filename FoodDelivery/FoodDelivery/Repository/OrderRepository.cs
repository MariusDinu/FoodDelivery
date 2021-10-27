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
        readonly private HttpRepository httpRepository;
        readonly private ProductRepository productRepository = new ProductRepository();
        readonly ISharedPreferences pref;
        public async Task<string> AddOrder(FullOrder order)
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

        public async Task<FullOrder> GetOrder(int id)
        {
            var response = await httpRepository.client.GetAsync(config.Order + id);
            FullOrder order = JsonConvert.DeserializeObject<FullOrder>(response.Content.ReadAsStringAsync().Result);

            return order;
        }
        public Order CreateOrder(string price)
        {
            Order order = new Order(ListProducts.IdRestaurant, price.ToString(), "Piata Unirii", "Delivering");
            return order;
        }

        public List<OrderProducts> CreateOrderProducts()
        {
            List<OrderProducts> list = new List<OrderProducts>();
            foreach (var item in ListProducts.list)
                list.Add(new OrderProducts(item.Id, item.Quantity));
            return list;
        }
        public OrderRepository()
        {
            httpRepository = new HttpRepository();
            pref = Application.Context.GetSharedPreferences("PathInfo", FileCreationMode.Private);
            string paths = pref.GetString("Paths", string.Empty);
            config = JsonConvert.DeserializeObject<Config>(paths);
        }

        public async Task<List<Product>> ReadStringAsync(List<OrderProducts> list)
        {
            List<Product> products = new List<Product>();

            foreach (var item in list)
            {
                Product product = await productRepository.GetProduct(item.IdProduct);
                products.Add(product);
            }
            return products;
        }


    }
}