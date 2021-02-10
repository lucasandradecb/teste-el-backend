using System.Threading;
using System.Threading.Tasks;
using Teste.El.Backend.Application.Models;
using Teste.El.Backend.Domain.Entities;

namespace Teste.El.Backend.Application.Interfaces
{
    /// <summary>
    /// Interface de AgendamentoApplication
    /// </summary>
    public interface IAgendamentoApplication
    {
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