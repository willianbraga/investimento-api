namespace Investimento.Domain.Interfaces.Repositories
{
    public interface IInvestimentoRepository
    {
        Task AdicionarInvestimentoAsync(CrossHelpers.Entities.Investimento investimento);
        Task<List<CrossHelpers.Entities.Investimento>> ListarInvestimentosAsync(int contaId);
        Task<CrossHelpers.Entities.Investimento?> BuscarInvestimentoAsync(string codigoProduto, int contaId);
        Task AtualizarSaldoAsync(CrossHelpers.Entities.Investimento investimento);
    }
}
