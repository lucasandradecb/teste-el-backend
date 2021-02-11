using System;
using Teste.El.Backend.Application.Models;
using Teste.El.Backend.Domain.Entities;
using Teste.El.Backend.Domain.Enums;

namespace Teste.El.Backend.Tests.Fixtures
{
    public class VeiculoFixture
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public VeiculoFixture() { }

        public Veiculo CriarVeiculo()
        {
            return new Veiculo
            {
                Ano = 2021,
                Categoria = ECategoriaVeiculo.Basico,
                CodigoMarca = "1234",
                CodigoModelo = "1234",
                Combustivel = ETipoCombustivel.Gasolina,
                DataCriacao = DateTime.Now,
                LimitePortaMalas = 80,
                Placa = "AAA1234",
                ValorHora = 10
            };  
        }

        public VeiculoModel CriarVeiculoModel()
        {
            return new VeiculoModel
            {
                Ano = 2021,
                Categoria = ECategoriaVeiculo.Basico,
                Marca = "1234",
                Modelo = "1234",
                Combustivel = ETipoCombustivel.Gasolina,
                LimitePortaMalas = 80,
                Placa = "AAA1234",
                ValorHora = 10
            };
        }

        public MarcaVeiculoModel CriarMarcaVeiculoModel()
        {
            return new MarcaVeiculoModel
            {
                Codigo = "1234",
                Descricao = "Fiat"
            };
        }

        public ModeloVeiculoModel CriarModeloVeiculoModel()
        {
            return new ModeloVeiculoModel
            {
                Codigo = "1234",
                Descricao = "Palio 1.0"
            };
        }

        public AgendamentoInputModel CriarAgendamentoInputModel()
        {
            return new AgendamentoInputModel
            { 
                DataDevolucao = DateTime.Now.AddDays(3),
                DataRetirada = DateTime.Now,
                Placa = "AAA1234"
            };
        }
    }
}
