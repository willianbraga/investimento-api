using Investimento.App.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Investimento.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthApp _authApp;

        public AuthController(IAuthApp authApp)
        {
            _authApp = authApp;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] CrossHelpers.Entities.Login dados)
        {
            var resultado = await _authApp.AutenticarAsync(dados.Username, dados.Password);

            if (resultado.Sucesso)
                return Ok(resultado.Token);

            return Unauthorized(resultado.Mensagem);
        }
    }
}
