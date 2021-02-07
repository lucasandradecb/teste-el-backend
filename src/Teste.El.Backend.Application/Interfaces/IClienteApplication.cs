using Teste.El.Backend.Application.Models;
using Teste.El.Backend.Domain.Entities;

namespace Teste.El.Backend.Application.Interfaces
{
    public interface IClienteApplication
    {
        Result<Cliente> Salvar(ClienteModel clienteModel);
    }
}