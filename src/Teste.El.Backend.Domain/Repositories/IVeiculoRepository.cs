﻿using Teste.El.Backend.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Teste.El.Backend.Domain.Repositories
{
    /// <summary>
    /// Interface do repositório de veiculos
    /// </summary>
    public interface IVeiculoRepository
    {
        /// <summary>
        /// Armazena um veiculo no banco de dados
        /// </summary>
        /// <param name="veiculo"></param>
        /// <param name="ctx"></param>
        /// <returns></returns>
        Task Salvar(Veiculo veiculo, CancellationToken ctx);
        /// <summary>
        /// Obtém o veiculo por placa
        /// </summary>
        /// <param name="placa"></param>
        /// <param name="ctx"></param>
        /// <returns></returns>
        Task<Veiculo> ObterPorPlaca(string placa, CancellationToken ctx);
        /// <summary>
        /// Verifica se o modelo já existe no banco
        /// </summary>
        /// <param name="veiculo"></param>
        /// <param name="ctx"></param>
        /// <returns></returns>
        Task<bool> VerificarSeExiste(Veiculo veiculo, CancellationToken ctx);
    }
}
