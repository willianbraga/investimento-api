namespace Investimento.App.Interfaces
{
    public interface IInvestimentoApp
    {
        Task AdicionarInvestimentoAsync(CrossHelpers.Entities.Investimento investimento);
        Task<List<CrossHelpers.Entities.Investimento>> BuscarInvestimentosAsync(string agencia, string conta, string dac);
    }
}
