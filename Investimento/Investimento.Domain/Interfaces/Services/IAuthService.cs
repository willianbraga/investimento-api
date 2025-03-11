namespace Investimento.Domain.Interfaces.Services
{
    public interface IAuthService
    {
        Task<bool> ValidarCredenciaisAsync(string username, string password);
    }
}
