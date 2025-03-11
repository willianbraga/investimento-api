
namespace Investimento.Domain.Interfaces.Repositories
{
    public interface IContaRepository
    {
        Task<List<CrossHelpers.Entities.Conta>> ListarContas();
        Task<CrossHelpers.Entities.Conta?> BuscarContaAsync(string agencia, string conta, string dac);
    }
}
