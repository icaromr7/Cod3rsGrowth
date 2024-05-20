using Cod3rsGrowth.dominio;
using Cod3rsGrowth.Servico;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.testes
{
    public class TesteDoServicoDeGenero : TesteBase {
        private IGeneroServico _generoServico;
        public TesteDoServicoDeGenero()
        {
            _generoServico = FornecedorDeServicos.GetService<IGeneroServico>(); ;
        }
        [Fact]
        public void Ao_obter_todos_deve_retornar_uma_lista_com_generos()
        {
            //act
            List<Genero> generos = _generoServico.ObterTodos();
            const int quantidadeEsperada = 0;
            int quantidadeAtual = generos.Count();

            //assert
            Assert.Equal(quantidadeEsperada, quantidadeAtual);
        }
    }  
}