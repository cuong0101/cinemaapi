using CinemaManagement.DTOs;
using CinemaManagement.Entities;
using CinemaManagement.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace CinemaManagement.Services
{
    public class TokenService : ITokenService
    {
        private readonly SymmetricSecurityKey _key;
        public TokenService(IConfiguration config)
        {
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));
        }

        public string CreateToken(MstCustomer cus)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId, cus.Email)
            };
            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddMinutes(20),
                SigningCredentials = creds
            };
            var tokenHander = new JwtSecurityTokenHandler();
            var token = tokenHander.CreateToken(tokenDescription);
            return tokenHander.WriteToken(token);
        }

        public string GenerateAccessToken(IEnumerable<Claim> claims)
        {
            var signinCredentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);
            var tokeOptions = new JwtSecurityToken(
                //issuer: "https://localhost:5001",
                //audience: "https://localhost:5001",
                claims: claims,
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: signinCredentials
            );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            return tokenString;
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[256];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token) // Lấy người dùng đã hết hạn token
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false, 
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = _key,
                ValidateLifetime = false
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;

            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");
            return principal;
        }
    }
}
