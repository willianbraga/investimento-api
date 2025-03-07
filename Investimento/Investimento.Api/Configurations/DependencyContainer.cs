using Investimento.App;
using Investimento.App.Interfaces;
using Investimento.Domain.Interfaces.Repositories;
using Investimento.Domain.Interfaces.Services;
using Investimento.Domain.Services;
using Investimento.Repository;

namespace Investimento.Api.Configurations
{
    public static class DependencyContainer
    {
        public static IServiceCollection SetDependencyInjection(this IServiceCollection services)
        {
            RegisterApps(services);

            RegisterServices(services);

            RegisterRepositories(services);

            return services;
        }

        private static void RegisterApps(IServiceCollection services)
        {
            services.AddScoped<IInvestimentoApp, InvestimentoApp>();
        }

        private static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IInvestimentoService, InvestimentoService>();
        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<IInvestimentoRepository, InvestimentoRepository>();
        }
    }
}
