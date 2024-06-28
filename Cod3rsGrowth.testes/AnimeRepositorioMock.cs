using Cod3rsGrowth.dominio;

namespace Cod3rsGrowth.testes
{
    public class AnimeRepositorioMock : IAnimeRepositorio
    {       
        public AnimeRepositorioMock()
        {
        }
        public void Atualizar(Anime anime)
        {
            var animeModificado = TabelaDeAnime.Instance.Find(delegate (Anime anime1) { return anime1.Id == anime.Id; });
            animeModificado.Nome = anime.Nome;
            animeModificado.Sinopse = anime.Sinopse;
            animeModificado.DataLancamento = anime.DataLancamento;
            animeModificado.Nota = anime.Nota;
            animeModificado.StatusDeExibicao = anime.StatusDeExibicao;
        }
        public int Cadastrar(Anime anime)
        {
            TabelaDeAnime.Instance.Add(anime);
            return anime.Id;
        }
        public void Deletar(int id)
        {
            var animeDeletado = TabelaDeAnime.Instance.Find(delegate (Anime anime1) { return anime1.Id == id; });
            TabelaDeAnime.Instance.Remove(animeDeletado);
        }
        public Anime ObterPorId(int id)
        {
            var anime = TabelaDeAnime.Instance.Find(delegate (Anime anime1){ return anime1.Id == id; });
            return anime;
        }
        public List<Anime> ObterTodos(FiltroAnime? filtroAnime)
        {
            var animes = TabelaDeAnime.Instance;
            return animes;
        }
    }
}
