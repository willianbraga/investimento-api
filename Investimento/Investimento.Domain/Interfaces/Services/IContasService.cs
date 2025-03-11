
namespace Investimento.Domain.Interfaces.Services
{
    public interface IContasService
    {
        Task<List<CrossHelpers.Entities.Conta>> ListarContas();
        Task<CrossHelpers.Entities.Conta?> BuscarContaAsync(string agencia, string conta, string dac);
    }
}
