using System.Threading;
using System.Threading.Tasks;
using Teste.El.Backend.Application.Models;
using Teste.El.Backend.Domain.Entities;

namespace Teste.El.Backend.Application.Interfaces
{
    /// <summary>
    /// Interface de ClienteApplication
    /// </summary>
    public interface IClienteApplication
    {
        /// <summary>
        /// Realiza o cadastro de um cliente
        /// </summary>
        /// <param name="clienteModel"></param>
        /// <param name="ctx"></param>
        /// <returns></returns>
        Task<Result<Cliente>> CadastrarCliente(ClienteModel clienteModel, CancellationToken ctx);
    }
}