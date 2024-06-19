namespace Cod3rsGrowth.dominio
{
    public interface IAnimeGeneroRepositorio
    {
        List<AnimeGenero> ObterTodos();
        List<AnimeGenero> ObterTodos(int? idAnime);
        AnimeGenero ObterPorId(int idAnime);
        void Cadastrar(AnimeGenero animeGenero);
        void Deletar(AnimeGenero animeGenero);
        void Atualizar(AnimeGenero animeGenero);
    }
}
