using Investimento.Domain.Interfaces.Repositories;
using Investimento.Repository;
using Investimento.Repository.Data;
using Microsoft.EntityFrameworkCore;

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

        }

        private static void RegisterServices(IServiceCollection services)
        {

        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<IInvestimentoRepository, InvestimentoRepository>();
        }
    }
}
