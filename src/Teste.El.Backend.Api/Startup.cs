using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Teste.El.Backend.Api.Filters;
using Teste.El.Backend.Api.Logging;
using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using Teste.El.Backend.Infrastructure;
using Teste.El.Backend.Application;
using Teste.El.Backend.Domain.Repositories;
using Teste.El.Backend.Infrastructure.Repositories;
using System.Text.Json.Serialization;

namespace Teste.El.Backend.Api
{
    [ExcludeFromCodeCoverage]
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting(options => options.LowercaseUrls = true);

            services.AddControllers();

            services.AddMvc(options => options.Filters.Add(new DefaultExceptionFilterAttribute()));

            services.AddRedis()
                .WithEnviroments(Configuration)
                .Add<IClienteRepository, ClienteRepository>()
                .Add<IMarcaVeiculoRepository, MarcaVeiculoRepository>()
                .Add<IModeloVeiculoRepository, ModeloVeiculoRepository>()
                .Add<IOperadorRepository, OperadorRepository>()
                .Add<IVeiculoRepository, VeiculoRepository>();

            services.AddAutoMapper(typeof(UsuarioApplication));
            services.AddAutoMapper(typeof(VeiculoApplication));

            services.AddInfraServices();

            services.AddApplicationServices();

            services.AddLoggingSerilog();

            services.AddHealthChecks();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Teste.El.Backend",
                    Description = "API - Teste.El.Backend",
                    Version = "v1"
                });

                var apiPath = Path.Combine(AppContext.BaseDirectory, "Teste.El.Backend.Api.xml");
                var applicationPath = Path.Combine(AppContext.BaseDirectory, "Teste.El.Backend.Application.xml");

                c.IncludeXmlComments(apiPath);
                c.IncludeXmlComments(applicationPath);
            });

            services.AddControllersWithViews()
                    .AddJsonOptions(options =>
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UsePathBase("/Teste.El.Backend");
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/Teste.El.Backend/swagger/v1/swagger.json", "API Teste.El.Backend");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health");
            });
        }
    }
}
