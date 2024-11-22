using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Group_Project_Chat_app.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Principal;
using Group_Project_Chat_app.Data;
using Azure.Identity;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Group_Project_Chat_app.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        private AppDbContext _appDbContext;

        public AuthController(IConfiguration configuration, AppDbContext appDbContext)
        {
            _configuration = configuration;
            _appDbContext = appDbContext;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            if (ModelState.IsValid)
            {
                _appDbContext.Users.Add(user);
                await _appDbContext.SaveChangesAsync();
                return Login(user);
            }
            return BadRequest();
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] User user)
        {
            var userCredential = _appDbContext.Users.FirstOrDefault(m => m.Username.Equals(user.Username));
            if (user.Password == userCredential.Password)
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
