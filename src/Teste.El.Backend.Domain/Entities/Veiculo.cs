using Flunt.Validations;
using Teste.El.Backend.Domain.ValueObjects;
using System;
using Teste.El.Backend.Domain.Entities.Core;
using Teste.El.Backend.Domain.Enums;

namespace Teste.El.Backend.Domain.Entities
{
    /// <summary>
    /// Classe da entidade de veiculo
    /// </summary>
    public class Veiculo : Entity
    {
        /// <summary>
        /// Construtor padrão de veiculo
        /// </summary>
        public Veiculo() { }

        /// <summary>
        /// Construtor de veiculo
        /// </summary>
        /// <param name="placa"></param>
        /// <param name="marca"></param>
        /// <param name="modelo"></param>
        /// <param name="ano"></param>
        /// <param name="valorHora"></param>
        /// <param name="combustivel"></param>
        /// <param name="limitePortaMalas"></param>
        /// <param name="categoria"></param>
        public Veiculo(string placa, string marca, string modelo, int ano, double valorHora, ETipoCombustivel combustivel, double limitePortaMalas, ECategoriaVeiculo categoria)
        {
            Placa = placa;
            CodigoMarca = marca;
            CodigoModelo = modelo;
            Ano = ano;
            ValorHora = valorHora;
            Combustivel = combustivel;
            LimitePortaMalas = limitePortaMalas;
            Categoria = categoria;
            DataCriacao = DateTime.UtcNow;            

            AddNotifications(new Contract()
                .Requires()
                .IsNotNull(Placa, nameof(Placa), "Placa não pode ser nula")
                .IsNotNull(ValorHora, nameof(ValorHora), "ValorHora não pode ser nulo"));
        }

        /// <summary>
        /// Placa do veiculo
        /// </summary>
        public string Placa { get; set; }
        /// <summary>
        /// Marca do veiculo
        /// </summary>
        public string CodigoMarca { get; set; }
        /// <summary>
        /// MOdelo do veiculo
        /// </summary>
        public string CodigoModelo { get; set; }
        /// <summary>
        /// Ano do veiculo
        /// </summary>
        public int Ano { get; set; }
        /// <summary>
        /// Valor da hora de aluguel do veiculo
        /// </summary>
        public double ValorHora { get; set; }
        /// <summary>
        /// Tipo de combustivel do veiculo
        /// </summary>
        public ETipoCombustivel Combustivel { get; set; }
        /// <summary>
        /// Limite do porta malas do veiculo
        /// </summary>
        public double LimitePortaMalas { get; set; }
        /// <summary>
        /// Categoria do veiculo
        /// </summary>
        public ECategoriaVeiculo Categoria { get; set; }
        /// <summary>
        /// Data de criação do registro
        /// </summary>
        public DateTime DataCriacao { get; set; }        
    }
}
