using Infosys.TravelAwayDAL.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Infosys.TravelAwayWebServices.Services
{
    public class TokenService
    {
        private readonly IConfiguration _config;
        private readonly string _key;
        private readonly string _issuer;
        private readonly string _audience;
        private readonly int _lifetimeMinutes;

        public TokenService(IConfiguration config)
        {
            _config = config;
            _key = _config["Jwt:Key"] ?? throw new ArgumentNullException("Jwt:Key");
            _issuer = _config["Jwt:Issuer"] ?? "TravelAwayApi";
            _audience = _config["Jwt:Audience"] ?? "TravelAwayClient";
            _lifetimeMinutes = int.TryParse(_config["Jwt:TokenLifetimeMinutes"], out var m) ? m : 60;
        }

        public string CreateToken(Customer user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.EmailId ?? string.Empty),
                new Claim("roleId", user.RoleId.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: _issuer,
                audience: _audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_lifetimeMinutes),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}