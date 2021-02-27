using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using HotelListing.Models;
using HotelListing.ViewModels.Return;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace HotelListing.Services
{
    public class AuthManager: IAuthManager
    {
        private readonly UserManager<ApiUser> _userManager;
        private readonly IConfiguration _config;

        public AuthManager(UserManager<ApiUser> userManager, IConfiguration config)
        {
            _userManager = userManager;
            _config = config;
        }
        public async Task<bool> ValidateUser(LoginUserDto user)
        {
            var userFromRepo = await _userManager.FindByEmailAsync(user.Email);
            return (userFromRepo != null && await _userManager.CheckPasswordAsync(userFromRepo, user.Password));
        }

        public async Task<string> CreateToken(LoginUserDto user)
        {
            var userFromRepo = await _userManager.FindByEmailAsync(user.Email);
            var claims = new List<Claim>()
            {
                new (ClaimTypes.Email, userFromRepo.Email),
                new (ClaimTypes.Name, userFromRepo.FirstName),
                new (ClaimTypes.GivenName, userFromRepo.LastName)
            };
            var roles = await _userManager.GetRolesAsync(userFromRepo);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:KEY"]));
            var creeds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creeds,
                Issuer = _config["Jwt:Issuer"]
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
