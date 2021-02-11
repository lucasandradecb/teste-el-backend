﻿using System.Diagnostics.CodeAnalysis;

namespace Teste.El.Backend.Application.Models
{
    [ExcludeFromCodeCoverage]
    /// <summary>
    /// Modelo de dados de usuario
    /// </summary>
    public class UsuarioTipoModel
    {
        /// <summary>
        /// Dados do cliente
        /// </summary>
        public ClienteModel Cliente { get; set; }
        /// <summary>
        /// Dados do operador
        /// </summary>
        public OperadorModel Operador { get; set; }       
    }
}
