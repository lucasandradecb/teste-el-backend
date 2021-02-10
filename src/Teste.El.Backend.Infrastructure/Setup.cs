using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using Teste.El.Backend.Domain.Repositories;
using Teste.El.Backend.Infrastructure.Repositories;

namespace Teste.El.Backend.Infrastructure
{
    /// <summary>
    /// Setup Infrastructure
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class Setup
    {
        /// <summary>
        /// Serviços de Domínio da Infrastructure
        /// </summary>
        public static IServiceCollection AddInfraServices(this IServiceCollection services)
        {
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IMarcaVeiculoRepository, MarcaVeiculoRepository>();
            services.AddScoped<IModeloVeiculoRepository, ModeloVeiculoRepository>();
            services.AddScoped<IOperadorRepository, OperadorRepository>();
            services.AddScoped<IVeiculoRepository, VeiculoRepository>();
            services.AddScoped<IAgendamentoRepository, AgendamentoRepository>();
            return services;
        }
    }
}
