using FoodDeliveryApi.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace FoodDeliveryApi.Config
{
    public static class JwtUser
    {
        public static string Encode(User user, JwtConfig jwtConfig)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(jwtConfig.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim("id",user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName,user.UserName)
                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };


            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = jwtTokenHandler.WriteToken(token);

            return jwtToken;
        }
        public static User Decode(string token)
        {

            var handler = new JwtSecurityTokenHandler();
            try
            {
                var jsonToken = handler.ReadToken(token);
                var tokenS = jsonToken as JwtSecurityToken;
                var id = tokenS.Claims.First(claim => claim.Type == "id").Value;
                var username = tokenS.Claims.First(claim => claim.Type == "given_name").Value;
                return new User(int.Parse(id), username);

            }
            catch (ArgumentException)
            {
                return null;
            }

        }
    }
}
