using Investimento.App.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Investimento.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class InvestimentoController : ControllerBase
    {
        private readonly IInvestimentoApp _investimentoApp;

        public InvestimentoController(IInvestimentoApp investimentoApp)
        {
            _investimentoApp = investimentoApp;
        }

        [HttpPost]
        [Route("novo")]
        public async Task<IActionResult> CriarInvestimentoAsync([FromQuery] string codproduto, [FromQuery] string nomeProduto, [FromQuery] string agencia, [FromQuery] string conta, [FromQuery] string dac, [FromQuery] decimal valor)
        {
            var resultado = await _investimentoApp.CriarInvestimentoAsync(codproduto, nomeProduto, agencia, conta, dac, valor);
            if (!resultado.Sucesso)
                return BadRequest(resultado.Mensagem);
            return Ok(resultado.Mensagem);
        }

        [HttpGet]
        [Route("buscar")]
        public async Task<IActionResult> BuscarInvestimentoAsync([FromQuery] string codproduto, [FromQuery] string agencia, [FromQuery] string conta, [FromQuery] string dac)
        {
            var resultado = await _investimentoApp.BuscarInvestimentoAsync(codproduto, agencia, conta, dac);

            if (resultado.Investimento == null)
                return NotFound(resultado.Mensagem);

            return Ok(resultado.Investimento);
        }

        [HttpGet]
        [Route("listar")]
        public async Task<IActionResult> ListarInvestimentosAsync([FromQuery] string agencia, [FromQuery] string conta, [FromQuery] string dac)
        {
            var resultado = await _investimentoApp.ListarInvestimentosAsync(agencia, conta, dac);

            if (resultado.Investimentos == null || resultado.Investimentos.Count == 0)
                return NotFound(resultado.Mensagem);

            return Ok(resultado.Investimentos);
        }

        [HttpPut]
        [Route("atualizar")]
        public async Task<IActionResult> AtualizarSaldo([FromQuery] string codproduto, [FromQuery] string agencia, [FromQuery] string conta, [FromQuery] string dac, [FromQuery] decimal valor)
        {
            var resultado = await _investimentoApp.AtualizarSaldoAsync(codproduto, agencia, conta, dac, valor);
            if (!resultado.Sucesso)
                return BadRequest(resultado.Mensagem);

            return Ok(resultado.Mensagem);
        }
    }
}
