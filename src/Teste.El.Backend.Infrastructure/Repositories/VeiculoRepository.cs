using Teste.El.Backend.Domain.Entities;
using Teste.El.Backend.Domain.Repositories;
using System;
using Localiza.BuildingBlocks.Redis;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics.CodeAnalysis;

namespace Teste.El.Backend.Infrastructure.Repositories
{
    /// <summary>
    /// Repositório de veiculos
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class VeiculoRepository : RedisRepository<Veiculo>, IVeiculoRepository
    {
        private TimeSpan REDIS_TEMPO_EXPIRACAO = new TimeSpan(10, 0, 0, 0);

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="config"></param>
        public VeiculoRepository(RedisConfiguration config) : base(config)
        {
            
        }

        /// <summary>
        /// Cria uma chave de acesso ao redis
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        protected override string CreateRedisKey(Veiculo model) => ObterChave(model.Id);

        /// <summary>
        /// Obtém chave de acesso do redis
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string ObterChave(Guid id) => $"veiculo:{id}";

        /// <summary>
        /// Armazena o veiculo no banco de dados
        /// </summary>
        /// <param name="veiculo"></param>
        /// <param name="ctx"></param>
        /// <returns></returns>
        public async Task Salvar(Veiculo veiculo, CancellationToken ctx)
        {
            await Add(veiculo, ctx, REDIS_TEMPO_EXPIRACAO);
        }

        /// <summary>
        /// Obtém o veiculo pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ctx"></param>
        /// <returns></returns>
        public async Task<Veiculo> ObterPorId(Guid id, CancellationToken ctx)
        {
            return await GetByKey(ObterChave(id), ctx); 
        }
    }    
}