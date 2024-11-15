using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Group_Project_Chat_app.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Principal;

namespace Group_Project_Chat_app.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] User user)
        {
            return Ok("Placeholder function");
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] User user)
        {
            // Todo: Get user from database
            if (user.Username == "placeholder" && user.Password == "placeholder")
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.Name,user.Username)
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(30),
                    Issuer = _configuration["Jwt:Issuer"],
                    Audience = _configuration["Jwt:Audience"],
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);
                return Ok(new {Token = tokenString}); 
            }
            return Unauthorized("Invalid Credentials");
        }

        [HttpGet("protected")]
        public IActionResult ProtectedResource()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {


                return Ok("You have accessed a protected resource!");
            }
            return Unauthorized("You are not able to access this resource");
        }
    }
}
