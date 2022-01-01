using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using VehicleTracker.Authentication.Interface;
using VehicleTracker.Models;

namespace VehicleTracker.Authentication.Service
{
    public class TokenService : IToken
    {
        private readonly SymmetricSecurityKey _jwtkey;

        public TokenService(IConfiguration config)
        {
            _jwtkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JwtKey"]));
        }

        public string CreateToken(ApplicationUser user, bool isAdmin = false)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.GivenName, user.Username),
                //check if the user is an admin so we can add that to the list of claims
                isAdmin == true ? new Claim("Admin", "admin") : new Claim(JwtRegisteredClaimNames.Sub, null)
            };

            var credentials = new SigningCredentials(_jwtkey, SecurityAlgorithms.HmacSha256);

            SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = credentials,
                Expires = DateTime.Now.AddHours(5)
            };

            var handler = new JwtSecurityTokenHandler();

            return handler.WriteToken(handler.CreateToken(descriptor));
        }
    }
}
