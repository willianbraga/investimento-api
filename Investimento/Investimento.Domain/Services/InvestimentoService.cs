using Investimento.Domain.Interfaces.Repositories;
using Investimento.Domain.Interfaces.Services;

namespace Investimento.Domain.Services
{
    public class InvestimentoService : IInvestimentoService
    {
        private readonly IInvestimentoRepository _investimentoRepository;
        public InvestimentoService(IInvestimentoRepository investimentoRepository)
        {
            _investimentoRepository = investimentoRepository;
        }

        public async Task AdicionarInvestimentoAsync(CrossHelpers.Entities.Investimento investimento)
        {
            await _investimentoRepository.AdicionarInvestimentoAsync(investimento);
        }

        public async Task<List<CrossHelpers.Entities.Investimento>> BuscarInvestimentosAsync(string agencia, string conta, string dac)
        {
            return await _investimentoRepository.BuscarInvestimentosAsync(agencia, conta, dac);
        }
    }
}
