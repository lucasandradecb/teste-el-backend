using System;
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
    }
}
