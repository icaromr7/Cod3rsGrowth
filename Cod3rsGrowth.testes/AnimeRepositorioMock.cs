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
            animeModificado.GenerosIds = anime.GenerosIds;
            animeModificado.DataLancamento = anime.DataLancamento;
            animeModificado.Nota = anime.Nota;
            animeModificado.StatusDeExibicao = anime.StatusDeExibicao;
        }
        public void Cadastrar(Anime anime)
        {
            TabelaDeAnime.Instance.Add(anime);
        }
        public string Deletar(Anime anime)
        {
            throw new NotImplementedException();
        }
        public Anime ObterPorId(int id)
        {
            var anime = TabelaDeAnime.Instance.Find(delegate (Anime anime1){ return anime1.Id == id; });
            return anime;
        }
        public List<Anime> ObterTodos()
        {
            var animes = TabelaDeAnime.Instance;
            return animes;
        }
    }
}
