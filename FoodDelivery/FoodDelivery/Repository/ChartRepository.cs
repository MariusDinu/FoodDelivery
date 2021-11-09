using FoodDelivery.Model;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDelivery.Repository
{
    public class ChartRepository
    {
        ProductRepository productRepository;

        public static double GetMoney()
        {
            double sum = 0;
            foreach (var item in ListProducts.listProducts)
            {
                sum += double.Parse(item.Product.Price) * item.Quantity;
            }
            return sum;
        }
        public async Task<string> AddProductAsync(int id, int quantity)
        {

            Product productToAdd = await productRepository.GetProduct(id);
            if (ListProducts.list.Count == 0 || ListProducts.listProducts.Count == 0)
            {
                ListProducts.IdRestaurant = productToAdd.IdRestaurant;
            }
            if (productToAdd.IdRestaurant == ListProducts.IdRestaurant || ListProducts.IdRestaurant == 0)
            {
                var Lambda = ListProducts.list.Where(x => x.Id == id).ToList();
                if (Lambda.Count == 0)
                {
                    ListProducts.list.Add(new ItemList(id, quantity));
                    ListProducts.listProducts.Add(new ItemChart(productToAdd, quantity));
                    return "Ok";
                }
                return "Exist";
            }
            else { return "New"; }
        }
        public void ChangeQuantity(int id, int quantity)
        {
            foreach (var item in ListProducts.listProducts)
            {
                if (item.Product.Id == id)
                {
                    item.Quantity = quantity;
                }
            }
            foreach (var item in ListProducts.list)
            {
                if (item.Id == id)
                {
                    item.Quantity = quantity;
                }
            }


        }
        public void ChangeRestaurant()
        {
            ListProducts.list.Clear();
            ListProducts.listProducts.Clear();
            ListProducts.IdRestaurant = 0;
        }

        public bool DeleteProduct(int id)
        {
            if (ListProducts.list.Count == 0 || ListProducts.listProducts.Count == 0)
            {
                ListProducts.IdRestaurant = 0;
                return true;
            }
            ListProducts.list.RemoveAll(x => x.Id == id);
            ListProducts.listProducts.RemoveAll(x => x.Product.Id == id);
            return true;
        }
        public ChartRepository()
        {
            productRepository = new ProductRepository();
        }
    }
}