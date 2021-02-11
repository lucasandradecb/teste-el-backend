﻿using System.Diagnostics.CodeAnalysis;
using Teste.El.Backend.Domain.Enums;

namespace Teste.El.Backend.Application.Models
{
    [ExcludeFromCodeCoverage]
    /// <summary>
    /// Modelo de dados saída de agendamento
    /// </summary>
    public class AgendamentoOutputModel : SimulacaoAgendamentoModel
    {        
        /// <summary>
        /// Categoria do veiculo
        /// </summary>
        public ECategoriaVeiculo Categoria { get; set; }
        /// <summary>
        /// Codigo da reserva
        /// </summary>
        public string CodigoReserva { get; set; }
    }
}
