using System;
using Teste.El.Backend.Domain.Enums;

namespace Teste.El.Backend.Application.Models
{
    /// <summary>
    /// Modelo de dados de saida de veículo
    /// </summary>
    public class VeiculoCompletoOutputModel : VeiculoModel
    {
        /// <summary>
        /// Descição da Marca do veiculo
        /// </summary>
        public string DescricaoMarca { get; set; }
        /// <summary>
        /// Descrição do modelo de um veiculo
        /// </summary>
        public string DescricaoModelo { get; set; }        
    }
}
