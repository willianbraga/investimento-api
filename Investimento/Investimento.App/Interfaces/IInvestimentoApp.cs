namespace Investimento.App.Interfaces
{
    public interface IInvestimentoApp
    {
        Task<(bool Sucesso, string Mensagem)> CriarInvestimentoAsync(string codigoProduto, string nomeProduto, string agencia, string conta, string dac, decimal valor);
        Task<(CrossHelpers.Entities.Investimento? Investimento, string Mensagem)> BuscarInvestimentoAsync(string codigoProduto, string agencia, string conta, string dac);
        Task<(List<CrossHelpers.Entities.Investimento> Investimentos, string Mensagem)> ListarInvestimentosAsync(string agencia, string conta, string dac);
        Task<(bool Sucesso, string Mensagem)> AtualizarSaldoAsync(string codigoProduto, string agencia, string conta, string dac, decimal valor);
    }
}
