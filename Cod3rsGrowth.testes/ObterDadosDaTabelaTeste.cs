using Cod3rsGrowth.dominio;

namespace Cod3rsGrowth.testes
{
    public class ObterDadosDaTabelaTeste
    {
        [Fact]
        public void ObterDadosDaTabelaGenero_1_acao()
        {
            List<Genero> tabelaDeGeneros = new List<Genero>();
            tabelaDeGeneros.Add(new Genero(1, "Acao"));

            //arrange
            GeneroRepositorioMock generoRepositorioMock = new GeneroRepositorioMock();

            //act
            List<Genero> tabela_de_generos = generoRepositorioMock.ObterTodos();

            //assert
            ComparacaoGenero.Equals(tabela_de_generos, tabelaDeGeneros);
        }
        [Fact]
        public void ObterDadosDaTabelaAnime()
        {
            List<Anime> tabelaDeAnimes = new List<Anime>();
            tabelaDeAnimes.Add(new Anime(1, "Anime1", "Sinopse1", new List<int>() { 1, 2 }, new DateTime(2024, 5, 15), 7.8m, Anime.Status.EmExibicao));

            // arrange
            AnimeRepositorioMock animeRepositorioMock = new AnimeRepositorioMock();

            //act
            List<Anime> tabela_de_animes = animeRepositorioMock.ObterTodos();

            //assert
            ComparacaoAnime.Equals(tabelaDeAnimes,tabela_de_animes);
            
        }
    }  
}