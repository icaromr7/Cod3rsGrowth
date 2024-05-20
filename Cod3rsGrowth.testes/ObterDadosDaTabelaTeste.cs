using Cod3rsGrowth.dominio;
using Cod3rsGrowth.Servico;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.testes
{
    public class ObterDadosDaTabelaTeste : TesteBase { 
        [Fact]
        public void ObterDadosDaTabelaGenero_1_acao()
        {
            List<Genero> tabelaDeGenerosEsperada = new List<Genero>();
            tabelaDeGenerosEsperada.Add(new Genero(1, "Acao"));
            //arrange
            IGeneroServico generoServicosTeste = FornecedorDeServicos.GetService<IGeneroServico>();

            //act
            List<Genero> tabelaDeGenerosAtual = generoServicosTeste.ObterTodos();
            var tabelaAtual = tabelaDeGenerosAtual.Where(i => !tabelaDeGenerosEsperada.Contains(i)).ToList();
            var tabelaEsperada = tabelaDeGenerosEsperada.Where(i => !tabelaDeGenerosAtual.Contains(i)).ToList();
            bool comparacao = tabelaAtual.Count == tabelaEsperada.Count;

            //assert
            Assert.True(comparacao);
        }
        [Fact]
        public void ObterDadosDaTabelaAnime()
        {
            List<Anime> tabelaDeAnimesEsperada = new List<Anime>();
            tabelaDeAnimesEsperada.Add(new Anime(1, "Anime1", "Sinopse1", new List<int>() { 1, 2 }, new DateTime(2024, 5, 15), 7.8m, Anime.Status.EmExibicao));

            // arrange
            IAnimeServico? animeServicosTestes = FornecedorDeServicos.GetService<IAnimeServico>();

            //act
            List<Anime> tabelaDeAnimesAtual = animeServicosTestes.ObterTodos();
            var tabelaAtual = tabelaDeAnimesAtual.Where(i => !tabelaDeAnimesEsperada.Contains(i)).ToList();
            var tabelaEsperada = tabelaDeAnimesEsperada.Where(i => !tabelaDeAnimesAtual.Contains(i)).ToList();
            bool comparacao = tabelaAtual.Count == tabelaEsperada.Count;
            //assert
            Assert.True(comparacao);
            
        }
    }  
}