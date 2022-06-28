using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ShoppingList.Application.Abstractions.Token;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Identity.Token
{
    public class TokenHandler : ITokenHandler
    {

        readonly IConfiguration _configuration;

        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public Application.DTOs.Token CreateAccessToken()
        {
            Application.DTOs.Token token = new();

            //Security Key'in simetriğini alıyoruz.

            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["Token:SigningKey"]));
            
            //Şifrelenmiş kimliği oluşturuyoruz.
            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            //Oluşturulacak token ayarlarını veriyoruz.

            token.Expiration = DateTime.UtcNow.AddMinutes(10);

            JwtSecurityToken securityToken = new(
                audience: _configuration["Token:Audience"],
                issuer: _configuration["Token:Issuer"],
                expires: token.Expiration,
                notBefore: DateTime.UtcNow,
                signingCredentials: signingCredentials
                );

            //Token oluşturucu sınıfından bir örnek alalım.

            JwtSecurityTokenHandler tokenHandler = new();

            token.AccessToken = tokenHandler.WriteToken(securityToken);

            return token;
        }
    }
}
