using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace beautyTechAPI.Service
{
    public class TokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;

            // Log para verificar se as configurações estão corretas
            Console.WriteLine($"Jwt:Key = {_configuration["Jwt:Key"]}");
            Console.WriteLine($"Jwt:Issuer = {_configuration["Jwt:Issuer"]}");
            Console.WriteLine($"Jwt:Audience = {_configuration["Jwt:Audience"]}");
            Console.WriteLine($"Jwt:ExpireMinutes = {_configuration["Jwt:ExpireMinutes"]}");
        }

        public string GenerateToken(string username)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            string expireMinutesStr = _configuration["Jwt:ExpireMinutes"];
            if (string.IsNullOrEmpty(expireMinutesStr))
            {
                throw new ArgumentNullException(nameof(expireMinutesStr), "ExpireMinutes não pode ser nulo ou vazio.");
            }

            double expireMinutes = double.Parse(expireMinutesStr);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(expireMinutes),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
