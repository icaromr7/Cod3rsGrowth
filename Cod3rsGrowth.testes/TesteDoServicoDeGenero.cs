using Cod3rsGrowth.dominio;
using Cod3rsGrowth.Servico;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.testes
{
    public class TesteDoServicoDeGenero : TesteBase {
        private IGeneroServico _generoServicoTeste;
        public TesteDoServicoDeGenero()
        {
            _generoServicoTeste = FornecedorDeServicos.GetService<IGeneroServico>(); ;
        }
        [Fact]
        public void Ao_obter_todos_deve_retornar_uma_lista_com_generos()
        {
            List<Genero> tabelaDeGenerosEsperada = new List<Genero>();
            tabelaDeGenerosEsperada.Add(new Genero(1, "Acao"));
            //arrange
            //act
            List<Genero> tabelaDeGenerosAtual = _generoServicoTeste.ObterTodos();
            var tabelaAtual = tabelaDeGenerosAtual.Where(i => !tabelaDeGenerosEsperada.Contains(i)).ToList();
            var tabelaEsperada = tabelaDeGenerosEsperada.Where(i => !tabelaDeGenerosAtual.Contains(i)).ToList();
            const int quantidadeEsperada = 1;
            int quantidadeAtual = tabelaAtual.Count();

            //assert
            Assert.Equal(quantidadeEsperada, quantidadeAtual);
        }
        
    }  
}