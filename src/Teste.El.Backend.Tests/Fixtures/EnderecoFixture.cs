using Teste.El.Backend.Domain.ValueObjects;

namespace Teste.El.Backend.Tests.Fixtures
{
    public class EnderecoFixture
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public EnderecoFixture() { }

        public EnderecoCompleto CriarEndereco()
        {
            return new EnderecoCompleto("33900788", "Rua Teste", "7", "Casa", "BH", "MG");  
        }       
    }
}
