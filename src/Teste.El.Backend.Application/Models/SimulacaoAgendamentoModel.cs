using Teste.El.Backend.Domain.Enums;

namespace Teste.El.Backend.Application.Models
{
    /// <summary>
    /// Modelo de dados de simulação de agendamento
    /// </summary>
    public class SimulacaoAgendamentoModel
    {
        /// <summary>
        /// Placa do veiculo
        /// </summary>
        public string Placa { get; set; }
        /// <summary>
        /// Valor da hora de aluguel do veiculo
        /// </summary>
        public double ValorHora { get; set; }
        /// <summary>
        /// Total de horas de aluguel do veiculo
        /// </summary>
        public double TotalHoras { get; set; }
        /// <summary>
        /// Valor da hora de aluguel do veiculo
        /// </summary>
        public double ValorTotal { get; set; }
    }
}
