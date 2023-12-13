using DapperStudy.Domain.Interfaces.Repositories;
using DapperStudy.Infra.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DapperStudy.Infra.Persistence.Extensions
{
    public static class PersistenceExtension
    {
        public static IServiceCollection AddPersistenceExtensions(this IServiceCollection services)
        {
            services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();

            return services;
        }
    }
}