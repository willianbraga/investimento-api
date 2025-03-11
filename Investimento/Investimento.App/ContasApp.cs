using Investimento.App.Interfaces;
using Investimento.CrossHelpers.Entities;
using Investimento.Domain.Interfaces.Services;

namespace Investimento.App
{
    public class ContasApp : IContasApp
    {
        private readonly IContasService _contasService;

        public ContasApp(IContasService contasService)
        {
            _contasService = contasService;
        }

        public async Task<List<Conta>> ListarContas()
        {
            return await _contasService.ListarContas();
        }
    }
}
