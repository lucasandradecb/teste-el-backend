using Flunt.Validations;
using System;
using Teste.El.Backend.Domain.Entities.Core;

namespace Teste.El.Backend.Domain.Entities
{
    /// <summary>
    /// Classe da entidade de marca do veiculo
    /// </summary>
    public class MarcaVeiculo : Entity
    {
        /// <summary>
        /// Construtor padrão 
        /// </summary>
        public MarcaVeiculo() { }

        /// <summary>
        /// Construtor 
        /// </summary>
        /// <param name="descricao"></param>
        public MarcaVeiculo(string descricao)
        {
            Descricao = descricao;
            DataCriacao = DateTime.UtcNow;            

            AddNotifications(new Contract()
                .Requires()
                .IsNotNull(Descricao, nameof(Descricao), "Descricao não pode ser nula"));
        }

        /// <summary>
        /// Descrição da marca
        /// </summary>
        public string Descricao { get; set; }    
        /// <summary>
        /// Data de criação do registro
        /// </summary>
        public DateTime DataCriacao { get; set; }        
    }
}
