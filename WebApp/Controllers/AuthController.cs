using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("login")]
        public string Login([FromBody] UserLogin userLogin)
        {
            // Validate user credentials (use real validation in production)
            if (userLogin.Username == "test" && userLogin.Password == "password")
            {
                var token = GenerateJwtToken(userLogin.Username);
                return token;
            }

            return null;
        }

        private string GenerateJwtToken(string username)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("+jv/sZJzr9UcE5xD6h10FjhKSPX9Kf8P4z5TeprnL7w="));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, username),
            };

            var token = new JwtSecurityToken(
                issuer: "yourdomain.com",
                audience: "yourdomain.com",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

    public class UserLogin
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
