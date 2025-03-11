namespace Investimento.App.Interfaces
{
    public interface IContasApp
    {
        Task<List<CrossHelpers.Entities.Conta>> ListarContas();

    }
}
