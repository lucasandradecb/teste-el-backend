﻿using Teste.El.Backend.Domain.Entities;
using Teste.El.Backend.Domain.Repositories;
using System;
using Localiza.BuildingBlocks.Redis;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics.CodeAnalysis;

namespace Teste.El.Backend.Infrastructure.Repositories
{
    /// <summary>
    /// Repositório de clientes
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ClienteRepository : RedisRepository<Cliente>, IClienteRepository
    {
        private TimeSpan REDIS_TEMPO_EXPIRACAO = new TimeSpan(10, 0, 0, 0);

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="config"></param>
        public ClienteRepository(RedisConfiguration config) : base(config)
        {
            
        }

        /// <summary>
        /// Cria uma chave de acesso ao redis
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        protected override string CreateRedisKey(Cliente model) => ObterChave(model.Id);

        /// <summary>
        /// Obtém chave de acesso do redis
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string ObterChave(Guid id) => $"cliente:{id}";

        /// <summary>
        /// Armazena o cliente no banco de dados
        /// </summary>
        /// <param name="cliente"></param>
        /// <param name="ctx"></param>
        /// <returns></returns>
        public async Task Salvar(Cliente cliente, CancellationToken ctx)
        {
            await Add(cliente, ctx, REDIS_TEMPO_EXPIRACAO);
        }

        /// <summary>
        /// Obtém o cliente pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ctx"></param>
        /// <returns></returns>
        public async Task<Cliente> ObterPorId(Guid id, CancellationToken ctx)
        {
            return await GetByKey(ObterChave(id), ctx);
        }
    }    
}