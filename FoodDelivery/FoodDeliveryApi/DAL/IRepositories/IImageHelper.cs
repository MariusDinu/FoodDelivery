namespace FoodDeliveryApi.DAL.IRepositories
{
    public interface IImageHelper
    {
        string AddImage(string Data, string Email);
        string ReadImage(string Path);
        string AddImageRestaurant(string imageData, string restaurantName);
        string AddImageProduct(string imageData, int id, string name);
    }
}
