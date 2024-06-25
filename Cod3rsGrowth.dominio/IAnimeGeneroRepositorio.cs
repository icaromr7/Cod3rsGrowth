namespace Cod3rsGrowth.dominio
{
    public interface IAnimeGeneroRepositorio
    {
        List<AnimeGenero> ObterTodos();
        List<AnimeGenero> ObterTodos(int? idAnime);
        AnimeGenero ObterPorId(int idAnime);
        void Cadastrar(AnimeGenero animeGenero);
        void Deletar(List<AnimeGenero> animeGeneros);
        void DeletarPorAnime(int idAnime);
        void DeletarPorGenero(int idGenero);
        void Atualizar(AnimeGenero animeGenero);
    }
}
