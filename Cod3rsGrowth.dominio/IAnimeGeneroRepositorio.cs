namespace Cod3rsGrowth.dominio
{
    public interface IAnimeGeneroRepositorio
    {
        List<AnimeGenero> ObterTodos();
        List<AnimeGenero> ObterPorId(int idAnime);
        void Cadastrar(AnimeGenero animeGenero);
        void Deletar(int id);
        void Atualizar(AnimeGenero animeGenero);
    }
}
