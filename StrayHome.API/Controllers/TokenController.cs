using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

using StrayHome.Application.Contracts.Persistence;
using StrayHome.Domain.DTO;
using StrayHome.Domain.Entities;
using StrayHome.Infrastructure.Authorization;
using StrayHome.Infrastructure.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StrayHome.API.Controllers
{
    [Route("api/token")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly IPasswordHasher _passwordHasher;
        private readonly StrayHomeContext _context;

        public TokenController(IConfiguration config, StrayHomeContext context , IPasswordHasher passwordHasher)
        {
            _configuration = config;
            _context = context;
            _passwordHasher = passwordHasher;
        }

        [HttpPost]
        public async Task<IActionResult> Post(UserDTO _userData)
        {
            if (_userData != null && _userData.Email != null && _userData.Password != null)
            {
                var user = await GetUser(_userData.Email, _userData.Password);

                if (user != null)
                {
                    //create claims details based on the user information
                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserId", user.ID.ToString()),                        
                        new Claim("UserName", user.Username),
                        new Claim("Email", user.Email),
                        new Claim(CustomClaimTypes.IS_ADMIN, user.Role.ToString())
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: signIn);

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }

        private async Task<User> GetUser(string email, string password)
        {
            var user = await _context.Users
       .Where(u => u.Email == email)
       .Select(u => new { u.Password, u.Salt })
       .FirstOrDefaultAsync();

            if (user != null)
            {
                byte[] salt = Convert.FromBase64String(user.Salt);
                var verify = _passwordHasher.Verify(password, user.Password ,salt);

                if (verify)
                {
                    return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
                }
            }

            return default;

        }
    }
}
