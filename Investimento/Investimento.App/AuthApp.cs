using Investimento.App.Interfaces;
using Investimento.Domain.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Investimento.App
{
    public class AuthApp : IAuthApp
    {
        private readonly IAuthService _authService;
        private readonly IConfiguration _configuration;

        public AuthApp(IAuthService authService, IConfiguration configuration)
        {
            _authService = authService;
            _configuration = configuration;
        }

        public async Task<(bool Sucesso, string Token, string Mensagem)> AutenticarAsync(string username, string password)
        {
            var usuarioValido = await _authService.ValidarCredenciaisAsync(username, password);

            if (!usuarioValido)
                return (false, string.Empty, "Usuário ou senha inválidos.");

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, username)
            };

            var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Secret"]));
            var credenciais = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            var tokenJWT = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:Issuer"],
                audience: _configuration["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(5),
                signingCredentials: credenciais
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenJWT);

            return (true, tokenString, "Login realizado com sucesso.");
        }
    }
}
