using Teste.El.Backend.Domain.Entities;
using System;
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
        /// Obtém o cliente por cpf
        /// </summary>
        /// <param name="cpf"></param>
        /// <param name="ctx"></param>
        /// <returns></returns>
        Task<Cliente> ObterPorCpf(string cpf, CancellationToken ctx);
        /// <summary>
        /// Verifica se o cliente já existe no banco
        /// </summary>
        /// <param name="cliente"></param>
        /// <param name="ctx"></param>
        /// <returns></returns>
        Task<bool> VerificarSeExiste(Cliente cliente, CancellationToken ctx);
    }
}
