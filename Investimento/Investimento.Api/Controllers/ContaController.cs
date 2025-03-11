using Investimento.App.Interfaces;
using Investimento.Repository.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Investimento.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaController : ControllerBase
    {
        private readonly IContasApp _contasApp;

        public ContaController(IContasApp contasApp)
        {
            _contasApp = contasApp;
        }

        [HttpGet]
        [Route("listar")]
        [Authorize]
        public async Task<IActionResult> ListarContas()
        {
            var contas = await _contasApp.ListarContas();
            return Ok(contas);
        }
    }
}
