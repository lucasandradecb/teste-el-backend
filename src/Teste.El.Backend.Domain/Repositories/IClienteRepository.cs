using Teste.El.Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Teste.El.Backend.Domain.Repositories
{
    /// <summary>
    /// Interface do repositório de clientes
    /// </summary>
    public interface IClienteRepository
    {
        /// <summary>
        /// Armazena um cliente no banco de dados
        /// </summary>
        /// <param name="cliente"></param>
        /// <param name="ctx"></param>
        /// <returns></returns>
        Task Salvar(Cliente cliente, CancellationToken ctx);
        /// <summary>
        /// Obtém o cliente por id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ctx"></param>
        /// <returns></returns>
        Task<Cliente> ObterPorId(Guid id, CancellationToken ctx);
        /// <summary>
        /// Lista dos os clientes
        /// </summary>
        /// <returns></returns>
        IEnumerable<Cliente> ListarTodos();
    }
}
