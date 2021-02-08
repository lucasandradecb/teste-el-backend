using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Teste.El.Backend.Application.Interfaces;
using Teste.El.Backend.Application.Models;
using Teste.El.Backend.Domain.Entities;
using Teste.El.Backend.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Teste.El.Backend.Api.Controllers.v1
{
    /// <summary>
    /// Controller de usuarios
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UsuariosController : ApiBaseController
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioApplication _usuarioApplication;

        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="usuarioApplication"></param>
        public UsuariosController(IMapper mapper, IUsuarioApplication usuarioApplication)
        {
            _mapper = mapper;
            _usuarioApplication = usuarioApplication;
        }

        //[HttpGet]
        //[Route("{id}")]
        //[ProducesResponseType(typeof(ClienteModel), StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        //[ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        //public IActionResult Get(Guid id)
        //{
        //    var cliente = _clienteRepository.ObterPorId(id);

        //    if (cliente == null)
        //        return NotFound("Cliente não encontrado");

        //    return Ok(_mapper.Map<Cliente, ClienteModel>(cliente));
        //}

        //[HttpGet]
        //[ProducesResponseType(typeof(IEnumerable<ClienteModel>), StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        //public IActionResult List()
        //{
        //    var cliente = _clienteRepository.ListarTodos();

        //    return Ok(_mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteModel>>(cliente));
        //}

        [HttpPost("clientes")]
        [ProducesResponseType(typeof(Cliente), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CadastrarCliente(ClienteModel clienteModel, CancellationToken ctx)
        {
            var result = await _usuarioApplication.CadastrarCliente(clienteModel, ctx);

            if (result.Valid)
                return Created("/usuarios/clientes", result.Object);

            return UnprocessableEntity(result.Notifications);
        }

        [HttpPost("operadores")]
        [ProducesResponseType(typeof(Operador), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CadastrarOperador(OperadorModel operadorModel, CancellationToken ctx)
        {
            var result = await _usuarioApplication.CadastrarOperador(operadorModel, ctx);

            if (result.Valid)
                return Created("/usuarios/operadores", result.Object);

            return UnprocessableEntity(result.Notifications);
        }
    }
}
