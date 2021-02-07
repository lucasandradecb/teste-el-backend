﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Teste.El.Backend.Application.Interfaces;
using Teste.El.Backend.Application.Models;
using Teste.El.Backend.Domain.Entities;
using Teste.El.Backend.Domain.Repositories;
using System;
using System.Collections.Generic;

namespace Teste.El.Backend.Api.Controllers.v1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ClienteController : ApiBaseController
    {
        private readonly IMapper _mapper;
        private readonly IClienteApplication _clienteApplication;
        private readonly IClienteRepository _clienteRepository;

        public ClienteController(IMapper mapper, IClienteApplication clienteApplication, IClienteRepository clienteRepository)
        {
            _mapper = mapper;
            _clienteApplication = clienteApplication;
            _clienteRepository = clienteRepository;
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(ClienteModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public IActionResult Get(Guid id)
        {
            var cliente = _clienteRepository.ObterPorId(id);

            if (cliente == null)
                return NotFound("Cliente não encontrado");

            return Ok(_mapper.Map<Cliente, ClienteModel>(cliente));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ClienteModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public IActionResult List()
        {
            var cliente = _clienteRepository.ListarTodos();

            return Ok(_mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteModel>>(cliente));
        }

        [HttpPost]
        [ProducesResponseType(typeof(ClienteModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public IActionResult Post(ClienteModel clienteModel)
        {
            var result = _clienteApplication.Salvar(clienteModel);

            if (result.Success)
                return Created($"/clientes/{result.Object.Id}", _mapper.Map<Cliente, ClienteModel>(result.Object));

            return BadRequest(result.Notifications);
        }
    }
}
