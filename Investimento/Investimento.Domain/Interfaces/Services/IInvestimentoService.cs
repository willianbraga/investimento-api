namespace Investimento.Domain.Interfaces.Services
{
    public interface IInvestimentoService
    {
        Task AdicionarInvestimentoAsync(CrossHelpers.Entities.Investimento investimento);
        Task<List<CrossHelpers.Entities.Investimento>> ListarInvestimentosAsync(int ContaId);
        Task<CrossHelpers.Entities.Investimento?> BuscarInvestimentoAsync(string codigoProduto, int contaId);
        Task AtualizarSaldoAsync(CrossHelpers.Entities.Investimento investimento);
    }
}
