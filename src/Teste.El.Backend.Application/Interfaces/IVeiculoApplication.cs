using System.Threading;
using System.Threading.Tasks;
using Teste.El.Backend.Application.Models;
using Teste.El.Backend.Domain.Entities;

namespace Teste.El.Backend.Application.Interfaces
{
    /// <summary>
    /// Interface de VeiculoApplication
    /// </summary>
    public interface IVeiculoApplication
    {
        /// <summary>
        /// Realiza o cadastro de um veículo
        /// </summary>
        /// <param name="veiculoModel"></param>
        /// <param name="ctx"></param>
        /// <returns></returns>
        Task<Result<Veiculo>> CadastrarVeiculo(VeiculoModel veiculoModel, CancellationToken ctx);
        /// <summary>
        /// Realiza o cadastro de uma marca de veículo
        /// </summary>
        /// <param name="marcaVeiculoModel"></param>
        /// <param name="ctx"></param>
        /// <returns></returns>
        Task<Result<MarcaVeiculo>> CadastrarMarcaVeiculo(MarcaVeiculoModel marcaVeiculoModel, CancellationToken ctx);
        /// <summary>
        /// Realiza o cadastro de um modelo de veículo
        /// </summary>
        /// <param name="modeloVeiculoModel"></param>
        /// <param name="ctx"></param>
        /// <returns></returns>
        Task<Result<ModeloVeiculo>> CadastrarModeloVeiculo(ModeloVeiculoModel modeloVeiculoModel, CancellationToken ctx);
        /// <summary>
        /// Realiza a simulação de um agendamento
        /// </summary>
        /// <param name="agendamentoInput"></param>
        /// <param name="ctx"></param>
        /// <returns></returns>
        Task<Result<SimulacaoAgendamentoModel>> SimularAluguelVeiculo(AgendamentoInputModel agendamentoInput, CancellationToken ctx);
        /// <summary>
        /// Realiza o agendamento de um aluguel de veiculo
        /// </summary>
        /// <param name="agendamentoInput"></param>
        /// <param name="ctx"></param>
        /// <returns></returns>
        Task<Result<AgendamentoOutputModel>> AgendarAluguelVeiculo(AgendamentoInputModel agendamentoInput, CancellationToken ctx);
    }
}