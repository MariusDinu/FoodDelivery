namespace FoodDelivery.Model
{
    public class ItemList
    {
        public ItemList(int id, int quantity)
        {
            Id = id;
            Quantity = quantity;
        }

        public int Id { get; set; }
        public int Quantity { get; set; }
    }
}