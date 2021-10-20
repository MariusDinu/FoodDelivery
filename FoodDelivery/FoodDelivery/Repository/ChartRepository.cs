using FoodDelivery.Model;
using System.Threading.Tasks;

namespace FoodDelivery.Repository
{
    public class ChartRepository
    {
        ProductRepository productRepository;

        public double GetMoney()
        {
            double sum = 0;
            foreach (var item in ListProducts.listProducts)
            {
                sum += double.Parse(item.Product.Price) * item.Quantity;
            }
            return sum;
        }
        public async Task<bool> AddProductAsync(int id, int quantity)
        {

            Product productToAdd = await productRepository.GetProduct(id);
            if (ListProducts.list.Count == 0 || ListProducts.listProducts.Count == 0)
            {
                ListProducts.IdRestaurant = productToAdd.IdRestaurant;
            }
            if (productToAdd.IdRestaurant == ListProducts.IdRestaurant || ListProducts.IdRestaurant == 0)
            {
                ListProducts.list.Add(new ItemList(id, quantity));
                ListProducts.listProducts.Add(new ItemChart(productToAdd, quantity));
                return true;
            }
            else { return false; }
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
            ListProducts.list.RemoveAt(id);
            ListProducts.listProducts.RemoveAt(id);
            return true;
        }
        public ChartRepository()
        {
            productRepository = new ProductRepository();
        }
    }
}