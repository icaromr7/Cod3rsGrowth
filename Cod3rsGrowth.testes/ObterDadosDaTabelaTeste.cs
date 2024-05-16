using Cod3rsGrowth.dominio;

namespace Cod3rsGrowth.testes
{
    public class ObterDadosDaTabelaTeste
    {
        [Fact]
        public void ObterDadosDaTabelaGenero_1_acao()
        {
            List<Genero> tabelaDeGenerosEsperada = new List<Genero>();
            tabelaDeGenerosEsperada.Add(new Genero(1, "Acao"));

            //arrange
            GeneroRepositorioMock generoRepositorioMock = new GeneroRepositorioMock();

            //act
            List<Genero> tabelaDeGenerosAtual = generoRepositorioMock.ObterTodos();

            //assert
            ComparacaoGenero.Equals(tabelaDeGenerosEsperada,tabelaDeGenerosAtual);
        }
        [Fact]
        public void ObterDadosDaTabelaAnime()
        {
            List<Anime> tabelaDeAnimesEsperada = new List<Anime>();
            tabelaDeAnimesEsperada.Add(new Anime(1, "Anime1", "Sinopse1", new List<int>() { 1, 2 }, new DateTime(2024, 5, 15), 7.8m, Anime.Status.EmExibicao));

            // arrange
            AnimeRepositorioMock animeRepositorioMock = new AnimeRepositorioMock();

            //act
            List<Anime> tabelaDeAnimesAtual = animeRepositorioMock.ObterTodos();

            //assert
            ComparacaoAnime.Equals(tabelaDeAnimesEsperada, tabelaDeAnimesAtual);
            
        }
    }  
}