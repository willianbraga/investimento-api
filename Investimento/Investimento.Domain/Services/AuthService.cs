using Investimento.Domain.Interfaces.Services;

namespace Investimento.Domain.Services
{
    public class AuthService : IAuthService
    {
        public async Task<bool> ValidarCredenciaisAsync(string username, string password)
        {
            return await Task.FromResult(username == "teste" && password == "1234");
        }
    }
}
