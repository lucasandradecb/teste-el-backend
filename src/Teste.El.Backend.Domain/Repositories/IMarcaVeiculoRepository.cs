using Teste.El.Backend.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Teste.El.Backend.Domain.Repositories
{
    /// <summary>
    /// Interface do repositório de marca veiculos
    /// </summary>
    public interface IMarcaVeiculoRepository
    {
        /// <summary>
        /// Armazena a marca de um veiculo no banco de dados
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="ctx"></param>
        /// <returns></returns>
        Task Salvar(MarcaVeiculo marca, CancellationToken ctx);
        /// <summary>
        /// Obtém a marca do veiculo por id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ctx"></param>
        /// <returns></returns>
        Task<MarcaVeiculo> ObterPorId(Guid id, CancellationToken ctx);
    }
}
