namespace Cod3rsGrowth.dominio
{
    public interface IAnimeGeneroRepositorio
    {
        List<AnimeGenero> ObterTodos();
        List<AnimeGenero> ObterTodos(int idAnime = 0);
        AnimeGenero ObterPorId(int idAnime);
        void Cadastrar(AnimeGenero animeGenero);
        void Deletar(int idAnime);
        void Atualizar(AnimeGenero animeGenero);
    }
}
