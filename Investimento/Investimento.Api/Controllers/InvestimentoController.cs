using Investimento.App.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Investimento.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvestimentoController : ControllerBase
    {
        private readonly IInvestimentoApp _investimentoApp;

        public InvestimentoController(IInvestimentoApp investimentoApp)
        {
            _investimentoApp = investimentoApp;
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarInvestimento([FromBody] CrossHelpers.Entities.Investimento investimento)
        {
            await _investimentoApp.AdicionarInvestimentoAsync(investimento);
            return CreatedAtAction(nameof(BuscarInvestimentos), new { agencia = investimento.Agencia, conta = investimento.Conta, dac = investimento.DAC }, investimento);
        }

        [HttpGet]
        public async Task<IActionResult> BuscarInvestimentos([FromQuery] string agencia, [FromQuery] string conta, [FromQuery] string dac)
        {
            var investimentos = await _investimentoApp.BuscarInvestimentosAsync(agencia, conta, dac);

            if (investimentos == null || investimentos.Count == 0)
                return NotFound("Nenhum investimento encontrado para essa conta.");

            return Ok(investimentos);
        }
    }
}
