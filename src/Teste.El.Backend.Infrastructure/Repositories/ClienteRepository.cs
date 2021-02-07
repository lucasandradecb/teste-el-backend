using AutoMapper;
using Teste.El.Backend.Domain.Entities;
using Teste.El.Backend.Domain.Repositories;
using Teste.El.Backend.Infrastructure.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using Localiza.BuildingBlocks.Redis;
using System.Threading.Tasks;
using System.Threading;

namespace Teste.El.Backend.Infrastructure.Repositories
{
    public class ClienteRepository : RedisRepository<Cliente>, IClienteRepository
    {
        private readonly IMapper _mapper;
        private TimeSpan REDIS_TEMPO_EXPIRACAO = new TimeSpan(5, 0, 0, 0);

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="config"></param>
        public ClienteRepository(IMapper mapper, RedisConfiguration config) : base(config)
        {
            _mapper = mapper;
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

        public IEnumerable<Cliente> ListarTodos()
        {
            var clientes = RepoFake.Clientes; // Recuperar do banco

            return _mapper.Map<IEnumerable<ClienteDbModel>, IEnumerable<Cliente>>(clientes);
        }

        public async Task<Cliente> ObterPorId(Guid id, CancellationToken ctx)
        {
            var cliente = await GetByKey(ObterChave(id), ctx); // Recuperar item do banco

            if (cliente != default)
                return cliente;

            return cliente;
        }

        private class RepoFake
        {
            public static IEnumerable<ClienteDbModel> Clientes
            {
                get
                {
                    return new ClienteDbModel[]
                    {
                        new ClienteDbModel()
                        {
                            Id = Guid.Parse("b5d028d5-1c11-40de-88df-832c0c0f36b9"),
                            Nome = "João",
                            Sobrenome = "Silva",
                            Email = "joaosilva@gmail.com",
                            Cpf = "12345678910",
                            Segmento = "abc123",
                            DataCriacao = new DateTime(2011, 2, 2)
                        },

                        new ClienteDbModel()
                        {
                            Id = Guid.Parse("340eefcb-c0b2-4c66-aa45-3a594e349dac"),
                            Nome = "Maria",
                            Sobrenome = "Silva",
                            Email = "mariasilva@gmail.com",
                            Cpf = "01987654321",
                            Ddd = 21,
                            Telefone = "999881122",
                            Segmento = $"xpz789",
                            DataCriacao = new DateTime(2010, 1, 1)
                        }
                    };
                }
            }
        }
    }    
}