using Teste.El.Backend.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Teste.El.Backend.Domain.Repositories
{
    /// <summary>
    /// Interface do repositório de modelo de veiculos
    /// </summary>
    public interface IModeloVeiculoRepository
    {
        /// <summary>
        /// Armazena o modelo de um veiculo no banco de dados
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="ctx"></param>
        /// <returns></returns>
        Task Salvar(ModeloVeiculo marca, CancellationToken ctx);
        /// <summary>
        /// Obtém o modelo do veiculo por id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ctx"></param>
        /// <returns></returns>
        Task<ModeloVeiculo> ObterPorId(Guid id, CancellationToken ctx);
    }
}
