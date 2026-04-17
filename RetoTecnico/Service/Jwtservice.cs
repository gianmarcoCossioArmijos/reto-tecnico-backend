using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RetoTecnico.Data;
using RetoTecnico.Model;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using static System.Net.Mime.MediaTypeNames;

namespace RetoTecnico.Service
{
    public class Jwtservice
    {
        private readonly AppDbContext cont;
        private readonly IConfiguration config;

        public Jwtservice(AppDbContext context, IConfiguration configutation)
        {
            cont = context;
            config = configutation;
        }

        public async Task<UserLoginResponse> Authenticate(UserLoginRequest request) {
            if (string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
            {
                return null;
            }

            var user = await cont.Users.FirstOrDefaultAsync(u => u.Username == request.Username);
            if (user is null || user.Password != request.Password)
            {
                return null;
            }

            var issuer = config["JwtConfig:Issuer"];
            var audience = config["JwtConfig:Audience"];
            var key = config["JwtConfig:Key"];
            var tokenValidityMins = config.GetValue<int>("JwtConfig:TokenValidityMins");
            var tokemExpiry = DateTime.UtcNow.AddMinutes(tokenValidityMins);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Name, request.Username)
                }),
                Expires = tokemExpiry,
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
                SecurityAlgorithms.HmacSha512Signature),
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var accessToken = tokenHandler.WriteToken(securityToken);

            return new UserLoginResponse
            {
                AccessToken = accessToken,
                Username = request.Username,
                Expiration = (int)tokemExpiry.Subtract(DateTime.UtcNow).TotalSeconds
            };
        }
    }
}