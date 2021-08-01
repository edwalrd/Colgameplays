using Colgameplays.Contract;
using Colgameplays.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Colgameplays.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ColgameplaysContext _context;
        private readonly IConfiguration _configuration;

        public AuthRepository(IConfiguration configuration,  ColgameplaysContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        public async Task<User> UserID(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User> LoginUser(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<User> RegistrarUser(User user)
        {
            _context.Users.Add(user);

           await _context.SaveChangesAsync();

            return user;
        }

        public string GenerateToken(User user)
        {
            //Header
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:SecretKey"]));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(signingCredentials);

            var claims = new[]
            {
                new Claim("UserID", user.Id.ToString()),
                new Claim("Email", user.Email.ToString()),
                new Claim(ClaimTypes.Role,  user.Role.ToString()),
            };

            //Payload

            var payload = new JwtPayload
                  (
                    _configuration["JwtSettings:Issuer"],
                    _configuration["JwtSettings:Audience"],
                    claims,
                    DateTime.Now,
                    DateTime.UtcNow.AddHours(12)
                  );

            var token = new JwtSecurityToken(header, payload);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
