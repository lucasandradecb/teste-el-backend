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
    /// Repositório de marca do veiculo
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class MarcaVeiculoRepository : RedisRepository<MarcaVeiculo>, IMarcaVeiculoRepository
    {
        private TimeSpan REDIS_TEMPO_EXPIRACAO = new TimeSpan(10, 0, 0, 0);

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="config"></param>
        public MarcaVeiculoRepository(RedisConfiguration config) : base(config)
        {
            
        }

        /// <summary>
        /// Cria uma chave de acesso ao redis
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        protected override string CreateRedisKey(MarcaVeiculo model) => ObterChave(model.Id);

        /// <summary>
        /// Obtém chave de acesso do redis
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string ObterChave(Guid id) => $"marca:veiculo:{id}";

        /// <summary>
        /// Armazena a marca do veiculo no banco de dados
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="ctx"></param>
        /// <returns></returns>
        public async Task Salvar(MarcaVeiculo marca, CancellationToken ctx)
        {
            await Add(marca, ctx, REDIS_TEMPO_EXPIRACAO);
        }

        /// <summary>
        /// Obtém a marca pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ctx"></param>
        /// <returns></returns>
        public async Task<MarcaVeiculo> ObterPorId(Guid id, CancellationToken ctx)
        {
            return await GetByKey(ObterChave(id), ctx);
        }
    }    
}