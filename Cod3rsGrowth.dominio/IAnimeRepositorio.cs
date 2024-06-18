using Cod3rsGrowth.dominio;
using static Cod3rsGrowth.dominio.Anime;

namespace Cod3rsGrowth.dominio
{
    public interface IAnimeRepositorio
    {
        List<Anime> ObterTodos(Status? statusDeExibicao = null, string nome = null, DateTime? dateTime = null);
        Anime ObterPorId(int id);
        void Cadastrar(Anime anime);
        void Deletar(int id);
        void Atualizar(Anime anime);
    }
}
