using System.Security.Claims;
using System.Text;
using System.Linq;
using System;
using System.Collections.Generic;
using ManageUsers.API.Interfaces;
using ManageUsers.API.Models;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace ManageUsers.API.Services
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly AppSettings _appSettigns;
        public AuthenticateService(
            IOptions<AppSettings> appSettings)
        {
            _appSettigns = appSettings.Value;
        }
        private List<User> users = new List<User>()
        {
            new User {
                UserId = 1,
                FirstName = "Eghosa",
                LastName = "Gabriel",
                UserName = "Virifortissimi",
                Password = "DEV@12345",
            }
        };

        public User Authenticate(string userName, string password)
        {
            var user = users.SingleOrDefault(x => x.UserName == userName && x.Password == password);

            //return null if user is not found
            if (user is null) return null;

            //if user is found
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettigns.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, user.UserId.ToString()),
                    new Claim(ClaimTypes.Role, "Admin"),
                    new Claim(ClaimTypes.Version, "V1.0"),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            user.Password = null;

            return user;
        }
    }
}