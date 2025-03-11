using Investimento.App.Interfaces;
using Investimento.Domain.Interfaces.Services;

namespace Investimento.App
{
    public class InvestimentoApp : IInvestimentoApp
    {
        private readonly IInvestimentoService _investimentoService;
        public InvestimentoApp(IInvestimentoService investimentoService)
        {
            _investimentoService = investimentoService;
        }
        public async Task AdicionarInvestimentoAsync(CrossHelpers.Entities.Investimento investimento)
        {
            await _investimentoService.AdicionarInvestimentoAsync(investimento);
        }

        public async Task<List<CrossHelpers.Entities.Investimento>> BuscarInvestimentosAsync(string agencia, string conta, string dac)
        {
            return await _investimentoService.BuscarInvestimentosAsync(agencia, conta, dac);
        }
    }
}
