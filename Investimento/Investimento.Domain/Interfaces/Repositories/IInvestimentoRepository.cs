namespace Investimento.Domain.Interfaces.Repositories
{
    public interface IInvestimentoRepository
    {
        Task<List<CrossHelpers.Entities.Investimento>> BuscarInvestimentosAsync(string agencia, string conta, string dac);
        Task AdicionarInvestimentoAsync(CrossHelpers.Entities.Investimento investimento);
    }
}
