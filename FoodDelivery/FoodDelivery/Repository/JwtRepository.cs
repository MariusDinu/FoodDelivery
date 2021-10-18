using Plugin.SecureStorage;

namespace FoodDelivery.Repository
{
    public static class JwtRepository
    {
        public static void SaveJWT(string code)
        {
            CrossSecureStorage.Current.SetValue("JWT", code);
        }

        public static string GetJWT()
        {
            return CrossSecureStorage.Current.GetValue("JWT");
        }

        public static void DeleteJWT()
        {
            CrossSecureStorage.Current.DeleteKey("JWT");
        }

        public static bool CheckJWT()
        {
            return CrossSecureStorage.Current.HasKey("JWT");
        }
    }
}