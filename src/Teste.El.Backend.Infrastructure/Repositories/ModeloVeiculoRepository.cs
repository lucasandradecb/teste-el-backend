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
    /// Repositório de modelo do veiculo
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ModeloVeiculoRepository : RedisRepository<ModeloVeiculo>, IModeloVeiculoRepository
    {
        private TimeSpan REDIS_TEMPO_EXPIRACAO = new TimeSpan(10, 0, 0, 0);

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="config"></param>
        public ModeloVeiculoRepository(RedisConfiguration config) : base(config)
        {
            
        }

        /// <summary>
        /// Cria uma chave de acesso ao redis
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        protected override string CreateRedisKey(ModeloVeiculo model) => ObterChave(model.Id);

        /// <summary>
        /// Obtém chave de acesso do redis
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string ObterChave(Guid id) => $"modelo:veiculo:{id}";

        /// <summary>
        /// Armazena o modelo do veiculo no banco de dados
        /// </summary>
        /// <param name="modelo"></param>
        /// <param name="ctx"></param>
        /// <returns></returns>
        public async Task Salvar(ModeloVeiculo modelo, CancellationToken ctx)
        {
            await Add(modelo, ctx, REDIS_TEMPO_EXPIRACAO);
        }

        /// <summary>
        /// Obtém o modelo pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ctx"></param>
        /// <returns></returns>
        public async Task<ModeloVeiculo> ObterPorId(Guid id, CancellationToken ctx)
        {
            return await GetByKey(ObterChave(id), ctx);
        }
    }    
}