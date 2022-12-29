using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CoreWebApp.Controllers
{
    public class SecurityController : Controller
    {
        public IActionResult Index()
        {
            string token = GenerateJSONWebToken("abdulkhadar");
            return View(token);
        }

        private string GenerateJSONWebToken(string username)
        {
            var SecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ABKABKdshshdkhke234567"));
            var Credentials= new SigningCredentials(SecurityKey,SecurityAlgorithms.HmacSha256);
            var claims = new[] { 
                new Claim("Issuer","Abdul"),
                new Claim("Admin","true"),
                new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.UniqueName,username),
            
            };

            var token= new JwtSecurityToken("issuer","audience",claims,expires: DateTime.Now.AddMinutes(60),signingCredentials:Credentials);
            return new JwtSecurityTokenHandler().WriteToken(token); 
        }
    }
}
