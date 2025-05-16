using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RentAcar.Persistence.Services
{
    public class AuthServices : IAuthServices //userid ve role göndereceğiz.
    {
        private readonly IConfiguration _configuration;


        public AuthServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GenerateToken(string id, string role)
        {
            // Token generation logic here
            // This is a placeholder implementation
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            //oluşturudğumuz keyi kullanarak token şifreliyoruz aslında oluşturuyoruz
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var calims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, id),//buraya "userId ataaması yapılıcak" kullanıcı adı şifre dopruysa ıd yi göndercez 
                //new Claim(ClaimTypes.Role,role),
                new Claim("role", role), 
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()) // benzersizguid oluşturma  //jti benzsersiz idden ne kadar oldunu kontrolü 
            };
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],// Token’ı kim verdi? (Senin API)
                audience: _configuration["Jwt:Audience"], //Token’ı kim kullanacak ?
                claims: calims, // Kullanıcıya dair bilgiler
                expires: DateTime.UtcNow.AddHours(1), // Token expiration time
                signingCredentials: credentials //İmzalama bilgisi
            );
            return new JwtSecurityTokenHandler().WriteToken(token); // Token’ı oluşturma
        }
    }
}
