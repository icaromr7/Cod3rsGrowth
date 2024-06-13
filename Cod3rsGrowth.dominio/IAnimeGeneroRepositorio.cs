namespace Cod3rsGrowth.dominio
{
    public interface IAnimeGeneroRepositorio
    {
        List<AnimeGenero> ObterTodos();
        List<AnimeGenero> ObterTodos(int idAnime = 0);
        AnimeGenero ObterPorId(int idAnime, int idGenero);
        void Cadastrar(AnimeGenero animeGenero);
        void Deletar(AnimeGenero animeGenero);
        void Atualizar(AnimeGenero animeGenero);
    }
}
