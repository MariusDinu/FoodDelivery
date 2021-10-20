using FoodDelivery.Model;
using System.Threading.Tasks;

namespace FoodDelivery.Repository
{
    public class ChartRepository
    {
        ProductRepository productRepository;

        public async Task<bool> AddProductAsync(int id, int quantity)
        {

            Product productToAdd = await productRepository.GetProduct(id);
            if (ListProducts.list.Count == 0 || ListProducts.listProducts.Count == 0) {
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
        public void DeleteProduct(int id) { }
        public ChartRepository()
        {
            productRepository = new ProductRepository();
        }
    }
}