using Teste.El.Backend.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Teste.El.Backend.Domain.Repositories
{
    /// <summary>
    /// Interface do repositório de operadores
    /// </summary>
    public interface IOperadorRepository
    {
        /// <summary>
        /// Armazena um operador no banco de dados
        /// </summary>
        /// <param name="operador"></param>
        /// <param name="ctx"></param>
        /// <returns></returns>
        Task Salvar(Operador operador, CancellationToken ctx);
        /// <summary>
        /// Obtém o operador por id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ctx"></param>
        /// <returns></returns>
        Task<Operador> ObterPorId(Guid id, CancellationToken ctx);
    }
}
