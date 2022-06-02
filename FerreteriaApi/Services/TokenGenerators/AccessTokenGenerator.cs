using FerreteriaApi.DTOs;
using FerreteriaApi.DTOs.user_sys;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FerreteriaApi.Services.TokenGenerators
{
    public class AccessTokenGenerator
    {

        private readonly IConfiguration _configuration;

        public AccessTokenGenerator(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public string GenerateToken(ResponseAuthentication responseAuthentication)
        {
            SecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


            List<Claim> claims = new List<Claim>() 
            { 
                new Claim(ClaimTypes.NameIdentifier, responseAuthentication.Username),
                new Claim(ClaimTypes.Role, responseAuthentication.RolId),
                //new Claim(ClaimTypes.Email, responseAuthentication.Email),
            };

            JwtSecurityToken token = new JwtSecurityToken(
                null,
                null,
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials
             ); 

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
