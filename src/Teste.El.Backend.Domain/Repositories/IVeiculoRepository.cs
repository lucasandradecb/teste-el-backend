using Teste.El.Backend.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Teste.El.Backend.Domain.Repositories
{
    /// <summary>
    /// Interface do repositório de veiculos
    /// </summary>
    public interface IVeiculoRepository
    {
        /// <summary>
        /// Armazena um veiculo no banco de dados
        /// </summary>
        /// <param name="veiculo"></param>
        /// <param name="ctx"></param>
        /// <returns></returns>
        Task Salvar(Veiculo veiculo, CancellationToken ctx);
        /// <summary>
        /// Obtém o veiculo por id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ctx"></param>
        /// <returns></returns>
        Task<Veiculo> ObterPorId(Guid id, CancellationToken ctx);
    }
}
