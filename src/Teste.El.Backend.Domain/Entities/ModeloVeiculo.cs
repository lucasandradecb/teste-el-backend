using Flunt.Validations;
using System;
using Teste.El.Backend.Domain.Entities.Core;

namespace Teste.El.Backend.Domain.Entities
{
    /// <summary>
    /// Classe da entidade de modelo do veiculo
    /// </summary>
    public class ModeloVeiculo : Entity
    {
        /// <summary>
        /// Construtor padrão 
        /// </summary>
        public ModeloVeiculo() { }

        /// <summary>
        /// Construtor 
        /// </summary>
        /// <param name="codigo"></param>
        /// <param name="descricao"></param>
        public ModeloVeiculo(string codigo, string descricao)
        {
            Codigo = codigo;
            Descricao = descricao;
            DataCriacao = DateTime.UtcNow;            

            AddNotifications(new Contract()
                .Requires()
                .IsNotNull(Codigo, nameof(Codigo), "Codigo não pode ser nulo")
                .IsNotNull(Descricao, nameof(Descricao), "Descricao não pode ser nula"));
        }

        /// <summary>
        /// Codigo da marca do veiculo
        /// </summary>
        public string Codigo { get; set; }
        /// <summary>
        /// Descrição do modelo
        /// </summary>
        public string Descricao { get; set; }    
        /// <summary>
        /// Data de criação do registro
        /// </summary>
        public DateTime DataCriacao { get; set; }        
    }
}
