using BLL.Config;
using BLL.Services.Contracts;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Auth
{
    public class JwtService : IJwtService
    {
        private readonly SecuritySettings _configuration;

        public JwtService(IOptions<SecuritySettings> configuration)
        {
            _configuration = configuration.Value;
        }

        public string CreateAccessToken(User user, IList<string> roles)
        {
            var token = CreateJwtToken(
                CreateClaims(user, roles),
                CreateSigningCredentials(),
                DateTime.UtcNow.AddMinutes(_configuration.AccessTokenExpirationMinutes)
            );

            var tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.WriteToken(token);
        }

        private JwtSecurityToken CreateJwtToken(List<Claim> claims, SigningCredentials credentials, DateTime expiration) =>
            new JwtSecurityToken(
                _configuration.Issuer,
                _configuration.Audience,
                claims,
                expires: expiration,
                signingCredentials: credentials
            );

        private static List<Claim> CreateClaims(IdentityUser user, IList<string> roles)
        {
            var claims = new List<Claim> {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email)
            };
            foreach (var role in roles)
                claims.Add(new Claim(ClaimTypes.Role, role));
            return claims;
        }


        private SigningCredentials CreateSigningCredentials() =>
            new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_configuration.Key)
                ),
                SecurityAlgorithms.HmacSha256
            );

        public string CreateRefreshToken()
        {
            const int length = 64;
            var randomNumber = new byte[length];
            var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
    }
}
