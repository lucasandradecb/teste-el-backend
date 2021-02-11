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

        //#region Usuario

        /// <summary>
        /// Dado que:
        ///    seja solicitado o cadastro de um usuario
        /// Eu preciso 
        ///    validar se os dados informados são válidos e se não existem no banco
        /// Para 
        ///    Armazenar as informações no banco
        /// </summary>
        //[Fact]
        //public async void CadastrarUsuario_Sucesso()
        //{
        //    //Prepare           
        //    var ctx = CancellationToken.None;
        //    var controller = CriarUsuarioController();

        //    var input = new UsuarioModel
        //    {
        //        Login = "123465",
        //        Senha = "123456"
        //    };

        //    //Act
        //    var result = await controller.CadastrarUsuario(input, ctx);

        //    //Assert
        //    Assert.IsType<OkResult>(result);
        //}

        ///// <summary>
        ///// Dado que:
        /////    seja solicitado o cadastro de um usuario
        ///// Eu preciso 
        /////    validar se os dados informados são válidos e se não existem no banco
        ///// Para 
        /////    Informar o motivo do usuario não poder ser cadastrado 
        ///// </summary>
        //[Fact]
        //public async void CadastrarUsuario_Erro()
        //{
        //    //Prepare           
        //    var ctx = CancellationToken.None;
        //    var controller = CriarUsuarioController(true, true, false);

        //    var input = new UsuarioModel
        //    {
        //        Login = "123465",
        //        Senha = "123456"
        //    };

        //    //Act
        //    var result = await controller.CadastrarUsuario(input, ctx);

        //    //Assert
        //    Assert.IsType<UnprocessableEntityObjectResult>(result);
        //}

        //#endregion

        //#region Cliente

        ///// <summary>
        ///// Dado que:
        /////    seja solicitado o cadastro de um cliente
        ///// Eu preciso 
        /////    validar se os dados informados são válidos e se não existem no banco
        ///// Para 
        /////    Armazenar as informações no banco
        ///// </summary>
        //[Fact]
        //public async void CadastrarCliente_Sucesso()
        //{
        //    //Prepare           
        //    var ctx = CancellationToken.None;
        //    var controller = CriarUsuarioController();

        //    var endereco = new EnderecoFixture().CriarEndereco();

        //    var input = new ClienteModel
        //    {
        //        Aniversario = DateTime.Now.AddYears(-20),
        //        Cpf = "90459735020",
        //        Nome = "Teste",
        //        Endereco = new ClienteModel.DadosEndereco
        //        {
        //            Cep = endereco.Cep,
        //            Cidade = endereco.Cidade,
        //            Complemento = endereco.Complemento,
        //            Estado = endereco.Estado,
        //            Logradouro = endereco.Logradouro,
        //            Numero = endereco.Numero
        //        }
        //    };

        //    //Act
        //    var result = await controller.CadastrarCliente(input, ctx);

        //    //Assert
        //    Assert.IsType<CreatedResult>(result);
        //}

        ///// <summary>
        ///// Dado que:
        /////    seja solicitado o cadastro de um cliente
        ///// Eu preciso 
        /////    validar se os dados informados são válidos e se não existem no banco
        ///// Para 
        /////    Informar o motivo do cliente não poder ser cadastrado 
        ///// </summary>
        //[Theory]
        //[InlineData("12345678901", true)]
        //[InlineData("90459735020", false)]
        //public async void CadastrarCliente_Erro(string cpf, bool clienteValido)
        //{
        //    //Prepare           
        //    var ctx = CancellationToken.None;
        //    var controller = CriarUsuarioController(clienteValido);

        //    var endereco = new EnderecoFixture().CriarEndereco();

        //    var input = new ClienteModel
        //    {
        //        Aniversario = DateTime.Now.AddYears(-20),
        //        Cpf = cpf,
        //        Nome = "Teste",
        //        Endereco = new ClienteModel.DadosEndereco
        //        {
        //            Cep = endereco.Cep,
        //            Cidade = endereco.Cidade,
        //            Complemento = endereco.Complemento,
        //            Estado = endereco.Estado,
        //            Logradouro = endereco.Logradouro,
        //            Numero = endereco.Numero
        //        }
        //    };

        //    //Act
        //    var result = await controller.CadastrarCliente(input, ctx);

        //    //Assert
        //    Assert.IsType<UnprocessableEntityObjectResult>(result);
        //}

        //#endregion

        //#region Operador

        ///// <summary>
        ///// Dado que:
        /////    seja solicitado o cadastro de um operador
        ///// Eu preciso 
        /////    validar se os dados informados são válidos e se não existem no banco
        ///// Para 
        /////    Armazenar as informações no banco
        ///// </summary>
        //[Fact]
        //public async void CadastrarOperador_Sucesso()
        //{
        //    //Prepare           
        //    var ctx = CancellationToken.None;
        //    var controller = CriarUsuarioController();

        //    var input = new OperadorModel
        //    {
        //        Matricula = "123465",
        //        Nome = "Teste"
        //    };

        //    //Act
        //    var result = await controller.CadastrarOperador(input, ctx);

        //    //Assert
        //    Assert.IsType<CreatedResult>(result);
        //}

        ///// <summary>
        ///// Dado que:
        /////    seja solicitado o cadastro de um operador
        ///// Eu preciso 
        /////    validar se os dados informados são válidos e se não existem no banco
        ///// Para 
        /////    Informar o motivo do operador não poder ser cadastrado 
        ///// </summary>
        //[Fact]
        //public async void CadastrarOperador_Erro()
        //{
        //    //Prepare           
        //    var ctx = CancellationToken.None;
        //    var controller = CriarUsuarioController(true, false);

        //    var input = new OperadorModel
        //    {
        //        Matricula = "123465",
        //        Nome = "Teste"
        //    };

        //    //Act
        //    var result = await controller.CadastrarOperador(input, ctx);

        //    //Assert
        //    Assert.IsType<UnprocessableEntityObjectResult>(result);
        //}

        //#endregion

        private VeiculosController CriarUsuarioController(bool veiculoValido = true, bool marcaValida = true, bool modeloValido = true, bool agendamentoValido = true)
        {
            var veiculoRepository = new VeiculoRepositoryMock().ObterPorId(veiculoValido).Salvar().VerificarSeExiste(!veiculoValido).ListarTodos();
            var marcaVeiculoRepository = new MarcaVeiculoRepositoryMock().ObterPorCodigo(marcaValida).Salvar().VerificarSeExiste(!marcaValida);
            var modeloRepository = new ModeloVeiculoRepositoryMock().ObterPorCodigo(modeloValido).Salvar().VerificarSeExiste(!modeloValido);
            var agendamentoRepository = new AgendamentoRepositoryMock().ObterPorReserva(agendamentoValido).Salvar().VerificarSeExiste(!agendamentoValido);
            var veiculoApplication = new VeiculoApplication(_mapperFixture.Mapper, veiculoRepository.Object, marcaVeiculoRepository.Object, modeloRepository.Object, agendamentoRepository.Object);

            return new VeiculosController(_mapperFixture.Mapper, veiculoApplication);
        }      
    }
}
