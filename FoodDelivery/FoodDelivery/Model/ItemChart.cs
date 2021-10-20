namespace FoodDelivery.Model
{
    public class ItemChart
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public ItemChart(Product productToAdd, int quantity)
        {
            this.Product = productToAdd;
            this.Quantity = quantity;
        }




    }
}