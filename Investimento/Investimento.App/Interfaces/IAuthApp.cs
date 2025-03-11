namespace Investimento.App.Interfaces
{
    public interface IAuthApp
    {
        Task<(bool Sucesso, string Token, string Mensagem)> AutenticarAsync(string username, string password);
    }
}
