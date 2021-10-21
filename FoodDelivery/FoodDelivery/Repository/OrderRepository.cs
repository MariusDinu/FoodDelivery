using Android.App;
using Android.Content;
using FoodDelivery.Model;
using Newtonsoft.Json;
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

        public string CreateStringForProducts() {

            string com1 = "{";
            string com2 = "}";
            string array = "";
            int count = 0;
            foreach(var item in ListProducts.list)
            {
                
                array += '"' + item.Id +'"'+':'+'"' + item.Quantity + '"';
                if (count > 0 &&count<ListProducts.list.Count) { array += ','; }

            }
            return com1 + array + com2;
        
        }
    }
}