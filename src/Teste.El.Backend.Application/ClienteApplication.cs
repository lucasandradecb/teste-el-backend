using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using Teste.El.Backend.Application.Interfaces;
using Teste.El.Backend.Application.Models;
using Teste.El.Backend.Domain.Entities;
using Teste.El.Backend.Domain.Repositories;

namespace Teste.El.Backend.Application
{
    public class ClienteApplication : IClienteApplication
    {
        private readonly IMapper _mapper;
        private readonly IClienteRepository _clienteRepository;

        public ClienteApplication(IMapper mapper, IClienteRepository clienteRepository)
        {
            _mapper = mapper;
            _clienteRepository = clienteRepository;
        }

        /// <summary>
        /// Realiza o cadastro de um cliente
        /// </summary>
        /// <param name="clienteModel"></param>
        /// <param name="ctx"></param>
        /// <returns></returns>
        public async Task<Result<Cliente>> CadastrarCliente(ClienteModel clienteModel, CancellationToken ctx)
        {
            var cliente = _mapper.Map<ClienteModel, Cliente>(clienteModel);

            if (cliente.Cpf.Invalid)
                cliente.AddNotifications(cliente.Cpf.Notifications);            

            if (cliente.Valid)
            {
                if (!await _clienteRepository.VerificarSeExiste(cliente, ctx))
                {
                    await _clienteRepository.Salvar(cliente, ctx);
                    return Result<Cliente>.Ok(cliente);
                }

                cliente.AddNotification(nameof(Cliente), "OPS!!! Já existe um cliente cadastrado com o CPF informado.");
            }

            return Result<Cliente>.Error(cliente.Notifications);
        }
    }
}
