using Microsoft.AspNetCore.Mvc;
using Teste.El.Backend.Api.Controllers.v1;
using Teste.El.Backend.Application;
using Teste.El.Backend.Application.Models;
using Teste.El.Backend.Tests.Fixtures;
using Teste.El.Backend.Tests.Mocks;
using System;
using Xunit;
using System.Threading;

namespace Teste.El.Backend.Tests.Controllers
{
    [Collection("Mapper")]
    public class VeiculosControllerTest
    {
        private readonly MapperFixture _mapperFixture;

        public VeiculosControllerTest(MapperFixture mapperFixture)
        {
            _mapperFixture = mapperFixture;
        }

        #region Veiculo

        /// <summary>
        /// Dado que:
        ///    seja solicitado o cadastro de um veiculo
        /// Eu preciso 
        ///    validar se os dados informados são válidos e se não existem no banco
        /// Para 
        ///    Armazenar as informações no banco
        /// </summary>
        [Fact]
        public async void CadastrarVeiculo_Sucesso()
        {
            //Prepare           
            var ctx = CancellationToken.None;
            var controller = CriarUsuarioController(true, true, true, true, false);

            var input = new VeiculoFixture().CriarVeiculoModel();

            //Act
            var result = await controller.CadastrarVeiculo(input, ctx);

            //Assert
            Assert.IsType<CreatedResult>(result);
        }

        /// <summary>
        /// Dado que:
        ///    seja solicitado o cadastro de um veiculo
        /// Eu preciso 
        ///    validar se os dados informados são válidos e se não existem no banco
        /// Para 
        ///    informar os motivos de não ser possivel cadastrar
        /// </summary>
        [Theory]
        [InlineData(false, true)]
        public async void CadastrarVeiculo_Erro(bool veiculoValido, bool veiculoExiste)
        {
            //Prepare           
            var ctx = CancellationToken.None;
            var controller = CriarUsuarioController(veiculoValido, true, true, true, veiculoExiste);

            var input = new VeiculoFixture().CriarVeiculoModel();

            //Act
            var result = await controller.CadastrarVeiculo(input, ctx);

            //Assert
            Assert.IsType<UnprocessableEntityObjectResult>(result);
        }

        #endregion

        #region Marca

        /// <summary>
        /// Dado que:
        ///    seja solicitado o cadastro de uma marca
        /// Eu preciso 
        ///    validar se os dados informados são válidos e se não existem no banco
        /// Para 
        ///    Armazenar as informações no banco
        /// </summary>
        [Fact]
        public async void CadastrarMarca_Sucesso()
        {
            //Prepare           
            var ctx = CancellationToken.None;
            var controller = CriarUsuarioController(true, true, true, true, true, false);

            var input = new VeiculoFixture().CriarMarcaVeiculoModel();

            //Act
            var result = await controller.CadastrarMarcaVeiculo(input, ctx);

            //Assert
            Assert.IsType<CreatedResult>(result);
        }

        /// <summary>
        /// Dado que:
        ///    seja solicitado o cadastro de uma marca
        /// Eu preciso 
        ///    validar se os dados informados são válidos e se não existem no banco
        /// Para 
        ///    Informar os motivos da marca nao ter sido cadastrada
        /// </summary>
        [Fact]
        public async void CadastrarMarca_Erro()
        {
            //Prepare           
            var ctx = CancellationToken.None;
            var controller = CriarUsuarioController(true, false);

            var input = new VeiculoFixture().CriarMarcaVeiculoModel();

            //Act
            var result = await controller.CadastrarMarcaVeiculo(input, ctx);

            //Assert
            Assert.IsType<UnprocessableEntityObjectResult>(result);
        }

        #endregion

        #region Modelo

        /// <summary>
        /// Dado que:
        ///    seja solicitado o cadastro de um modelo
        /// Eu preciso 
        ///    validar se os dados informados são válidos e se não existem no banco
        /// Para 
        ///    Armazenar as informações no banco
        /// </summary>
        [Fact]
        public async void CadastrarModelo_Sucesso()
        {
            //Prepare           
            var ctx = CancellationToken.None;
            var controller = CriarUsuarioController(true, true, true, true, true, true, false);

            var input = new VeiculoFixture().CriarModeloVeiculoModel();

            //Act
            var result = await controller.CadastrarModeloVeiculo(input, ctx);

            //Assert
            Assert.IsType<CreatedResult>(result);
        }

        /// <summary>
        /// Dado que:
        ///    seja solicitado o cadastro de um modelo
        /// Eu preciso 
        ///    validar se os dados informados são válidos e se não existem no banco
        /// Para 
        ///    Informar o motivo do modelo não ter sido cadastrado
        /// </summary>
        [Fact]
        public async void CadastrarModelo_Erro()
        {
            //Prepare           
            var ctx = CancellationToken.None;
            var controller = CriarUsuarioController(true, true, false);

            var input = new VeiculoFixture().CriarModeloVeiculoModel();

            //Act
            var result = await controller.CadastrarModeloVeiculo(input, ctx);

            //Assert
            Assert.IsType<UnprocessableEntityObjectResult>(result);
        }

        #endregion

        #region Agendamento

        /// <summary>
        /// Dado que:
        ///    seja solicitado o agendaemnto de um veiculo
        /// Eu preciso 
        ///    validar se os dados informados são válidos e se não existem no banco
        /// Para 
        ///    Armazenar as informações no banco
        /// </summary>
        [Fact]
        public async void CadastrarAgendamento_Sucesso()
        {
            //Prepare           
            var ctx = CancellationToken.None;
            var controller = CriarUsuarioController(true, true, true, true, true, true, true, false);

            var input = new VeiculoFixture().CriarAgendamentoInputModel();

            //Act
            var result = await controller.AgendarVeiculo(input, ctx);

            //Assert
            Assert.IsType<CreatedResult>(result);
        }

        /// <summary>
        /// Dado que:
        ///    seja solicitado o agendaemnto de um veiculo
        /// Eu preciso 
        ///    validar se os dados informados são válidos e se não existem no banco
        /// Para 
        ///    Informar o motivo de nao ser possivel armazenar o agendamento
        /// </summary>
        [Theory]
        [InlineData("", 0, true)]
        [InlineData("AAABHZ", 10, true)]
        [InlineData("AAABHZ", -1, true)]
        [InlineData("AAABHZ", 0, false)]
        public async void CadastrarAgendamento_Erro(string placa, int dataRetiradaAddAno, bool veiculoValido)
        {
            //Prepare           
            var ctx = CancellationToken.None;
            var controller = CriarUsuarioController(veiculoValido, true, true, true, true, true, true, true);

            var input = new VeiculoFixture().CriarAgendamentoInputModel();
            input.Placa = placa;

            if (dataRetiradaAddAno < 0)
                input.DataRetirada = DateTime.MinValue;
            else
                input.DataRetirada = input.DataRetirada.AddYears(dataRetiradaAddAno);

            //Act
            var result = await controller.AgendarVeiculo(input, ctx);

            //Assert
            Assert.IsType<UnprocessableEntityObjectResult>(result);
        }

        #endregion

        private VeiculosController CriarUsuarioController(bool veiculoValido = true, bool marcaValida = true, bool modeloValido = true, bool agendamentoValido = true,
                                                          bool veiculoExiste = true, bool marcaExiste = true, bool modeloExiste = true, bool agendamentoExiste = true)
        {
            var veiculoRepository = new VeiculoRepositoryMock().ObterPorId(veiculoValido).Salvar().VerificarSeExiste(veiculoExiste).ListarTodos();
            var marcaVeiculoRepository = new MarcaVeiculoRepositoryMock().ObterPorCodigo(marcaValida).Salvar().VerificarSeExiste(marcaExiste);
            var modeloRepository = new ModeloVeiculoRepositoryMock().ObterPorCodigo(modeloValido).Salvar().VerificarSeExiste(modeloExiste);
            var agendamentoRepository = new AgendamentoRepositoryMock().ObterPorReserva(agendamentoValido).Salvar().VerificarSeExiste(agendamentoExiste);
            var veiculoApplication = new VeiculoApplication(_mapperFixture.Mapper, veiculoRepository.Object, marcaVeiculoRepository.Object, modeloRepository.Object, agendamentoRepository.Object);

            return new VeiculosController(_mapperFixture.Mapper, veiculoApplication);
        }      
    }
}
