using Flunt.Validations;
using Teste.El.Backend.Domain.ValueObjects.Core;

namespace Teste.El.Backend.Domain.ValueObjects
{
    /// <summary>
    /// Objeto de CPF
    /// </summary>
    public class CPF : ValueObject
    {
        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <param name="numero"></param>
        public CPF(string numero)
        {
            Numero = numero;

            AddNotifications(new Contract()
                .Requires()
                .IsNotNullOrWhiteSpace(Numero, nameof(CPF.Numero), "CPF não pode ser nulo ou branco")
                .HasLen(Numero, 11, nameof(CPF.Numero), "CPF deve conter 11 posições")
                .IsDigit(Numero, nameof(CPF.Numero), "CPF deve conter apenas números")
                .Matchs(Numero, "^([0-9]){3}.([0-9]){3}.([0-9]){3}-([0-9]){2}$", nameof(Numero), "Número informado está fora do padrão de CPF"));
        }

        /// <summary>
        /// Número do CPF
        /// </summary>
        public string Numero { get; private set; }

        /// <summary>
        /// Converter em string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Numero;
        }
    }
}