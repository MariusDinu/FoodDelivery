using System.ComponentModel.DataAnnotations;

namespace FoodDeliveryApi.Models
{
    public class OrderProducts
    {
        public OrderProducts(int idOrder, int idProduct, int quantity)
        {
            IdOrder = idOrder;
            IdProduct = idProduct;
            Quantity = quantity;
        }
        public OrderProducts(int idProduct, int quantity)
        {

            IdProduct = idProduct;
            Quantity = quantity;
        }
        public OrderProducts() { }
        [Required]

        public int IdOrder { get; set; }
        [Required]

        public int IdProduct { get; set; }
        [Required]

        public int Quantity { get; set; }
    }
}
