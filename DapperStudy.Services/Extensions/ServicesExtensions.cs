using DapperStudy.Domain.Interfaces.Services;
using DapperStudy.Services.Funcionario;
using Microsoft.Extensions.DependencyInjection;

namespace DapperStudy.Services.Extensions
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddServicesExtensions(this IServiceCollection services)
        {
            services.AddScoped<IFuncionarioService, FuncionarioService>();

            return services;
        }
    }
}