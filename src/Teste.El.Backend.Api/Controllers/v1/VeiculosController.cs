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
    /// Controller de veiculos
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class VeiculosController : ApiBaseController
    {
        private readonly IMapper _mapper;
        private readonly IVeiculoApplication _veiculoApplication;

        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="veiculoApplication"></param>
        public VeiculosController(IMapper mapper, IVeiculoApplication veiculoApplication)
        {
            _mapper = mapper;
            _veiculoApplication = veiculoApplication;
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

        [HttpPost]
        [ProducesResponseType(typeof(Veiculo), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CadastrarVeiculo(VeiculoModel veiculoModel, CancellationToken ctx)
        {
            var result = await _veiculoApplication.CadastrarVeiculo(veiculoModel, ctx);

            if (result.Valid)
                return Created("/veiculos", result.Object);

            return UnprocessableEntity(result.Notifications);
        }

        [HttpPost("marcas")]
        [ProducesResponseType(typeof(MarcaVeiculo), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CadastrarMarcaVeiculo(MarcaVeiculoModel marcaVeiculoModel, CancellationToken ctx)
        {
            var result = await _veiculoApplication.CadastrarMarcaVeiculo(marcaVeiculoModel, ctx);

            if (result.Valid)
                return Created("/veiculos/marcas", result.Object);

            return UnprocessableEntity(result.Notifications);
        }

        [HttpPost("modelos")]
        [ProducesResponseType(typeof(ModeloVeiculo), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CadastrarModeloVeiculo(ModeloVeiculoModel modeloVeiculoModel, CancellationToken ctx)
        {
            var result = await _veiculoApplication.CadastrarModeloVeiculo(modeloVeiculoModel, ctx);

            if (result.Valid)
                return Created("/veiculos/modelos", result.Object);

            return UnprocessableEntity(result.Notifications);
        }
    }
}
