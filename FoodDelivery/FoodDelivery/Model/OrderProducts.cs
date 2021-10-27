namespace FoodDelivery.Model
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

        public int IdOrder { get; set; }
        public int IdProduct { get; set; }
        public int Quantity { get; set; }
    }
}