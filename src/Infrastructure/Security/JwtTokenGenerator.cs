using Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Security
{
    public class JwtTokenGenerator(IConfiguration config) : IJwtTokenGenerator
    {
        private readonly IConfiguration _config = config;

        public string GenerateToken(int personelId, string sicilNo, string ad, string soyad, string rol)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, personelId.ToString()),
                new Claim("sicilNo", sicilNo),
                new Claim("ad", ad),
                new Claim("soyad", soyad),
                new Claim("rol",rol )
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
