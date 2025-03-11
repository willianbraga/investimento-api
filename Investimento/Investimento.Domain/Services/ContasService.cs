using Investimento.Domain.Interfaces.Repositories;
using Investimento.Domain.Interfaces.Services;

namespace Investimento.Domain.Services
{
    public class ContasService : IContasService
    {
        private readonly IContaRepository _contaRepository;

        public ContasService(IContaRepository contaRepository)
        {
            _contaRepository = contaRepository;
        }

        public async Task<List<CrossHelpers.Entities.Conta>> ListarContas()
        {
            return await _contaRepository.ListarContas();
        }

        public async Task<CrossHelpers.Entities.Conta?> BuscarContaAsync(string agencia, string conta, string dac)
        {
            return await _contaRepository.BuscarContaAsync(agencia, conta, dac);
        }
    }
}
