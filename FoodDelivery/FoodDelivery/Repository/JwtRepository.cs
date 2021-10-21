using Plugin.SecureStorage;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

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
        public static bool ExpireJWT()
        {
            if (CheckJWT())
            {
                var token = CrossSecureStorage.Current.GetValue("JWT");
                var handler = new JwtSecurityTokenHandler();
                try
                {
                    var jsonToken = handler.ReadToken(token);
                    var tokenS = jsonToken as JwtSecurityToken;
                    var expDate = tokenS.ValidTo;
                    if (expDate < DateTime.UtcNow.AddMinutes(1))
                    {
                        DeleteJWT();
                        return false;
                    }
                }
                catch (ArgumentException)
                {
                    return false;
                }
                return true;

            }
            return false;
        }
    }
}