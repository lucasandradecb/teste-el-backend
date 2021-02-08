using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using Teste.El.Backend.Application.Interfaces;
using Teste.El.Backend.Application.Models;
using Teste.El.Backend.Domain.Entities;
using Teste.El.Backend.Domain.Repositories;
using Teste.El.Backend.Domain.Resources;

namespace Teste.El.Backend.Application
{
    /// <summary>
    /// Classe de application de cliente
    /// </summary>
    public class UsuarioApplication : IUsuarioApplication
    {
        private readonly IMapper _mapper;
        private readonly IClienteRepository _clienteRepository;
        private readonly IOperadorRepository _operadorRepository;

        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="clienteRepository"></param>
        /// <param name="operadorRepository"></param>
        public UsuarioApplication(IMapper mapper, 
                                  IClienteRepository clienteRepository,
                                  IOperadorRepository operadorRepository)
        {
            _mapper = mapper;
            _clienteRepository = clienteRepository;
            _operadorRepository = operadorRepository;
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

                cliente.AddNotification(nameof(Cliente), MensagensInfo.Cliente_CpfExistente);
            }

            return Result<Cliente>.Error(cliente.Notifications);
        }

        /// <summary>
        /// Realiza o cadastro de um operador
        /// </summary>
        /// <param name="operadorModel"></param>
        /// <param name="ctx"></param>
        /// <returns></returns>
        public async Task<Result<Operador>> CadastrarOperador(OperadorModel operadorModel, CancellationToken ctx)
        {
            var operador = _mapper.Map<OperadorModel, Operador>(operadorModel);

            if (operador.Valid)
            {
                if (!await _operadorRepository.VerificarSeExiste(operador, ctx))
                {
                    await _operadorRepository.Salvar(operador, ctx);
                    return Result<Operador>.Ok(operador);
                }

                operador.AddNotification(nameof(Operador), MensagensInfo.Operador_MatriculaExistente);
            }

            return Result<Operador>.Error(operador.Notifications);
        }
    }
}
