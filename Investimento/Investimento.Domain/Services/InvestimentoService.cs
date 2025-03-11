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

        public async Task<List<CrossHelpers.Entities.Investimento>> ListarInvestimentosAsync(int contaId)
        {
            return await _investimentoRepository.ListarInvestimentosAsync(contaId);
        }

        public async Task<CrossHelpers.Entities.Investimento?> BuscarInvestimentoAsync(string codigoProduto, int contaId)
        {
            return await _investimentoRepository.BuscarInvestimentoAsync(codigoProduto, contaId);
        }

        public async Task AtualizarSaldoAsync(CrossHelpers.Entities.Investimento investimento)
        {
            await _investimentoRepository.AtualizarSaldoAsync(investimento);
        }
    }
}
