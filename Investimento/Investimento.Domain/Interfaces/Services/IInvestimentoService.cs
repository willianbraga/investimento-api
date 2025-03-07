namespace Investimento.Domain.Interfaces.Services
{
    public interface IInvestimentoService
    {
        Task AdicionarInvestimentoAsync(CrossHelpers.Entities.Investimento investimento);
        Task<List<CrossHelpers.Entities.Investimento>> BuscarInvestimentosAsync(string agencia, string conta, string dac);
    }
}
