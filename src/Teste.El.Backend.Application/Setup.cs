using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using Teste.El.Backend.Application.Interfaces;

namespace Teste.El.Backend.Application
{
    /// <summary>
    /// Setup da Application
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class Setup
    {
        /// <summary>
        /// Serviços de Domínio da Application
        /// </summary>
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IClienteApplication, ClienteApplication>();
            return services;
        }
    }
}
