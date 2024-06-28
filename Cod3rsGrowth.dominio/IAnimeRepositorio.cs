using Cod3rsGrowth.dominio;
using static Cod3rsGrowth.dominio.Anime;

namespace Cod3rsGrowth.dominio
{
    public interface IAnimeRepositorio
    {
        List<Anime> ObterTodos(FiltroAnime? filtro);
        Anime ObterPorId(int id);
        int Cadastrar(Anime anime);
        void Deletar(int id);
        void Atualizar(Anime anime);
    }
}
