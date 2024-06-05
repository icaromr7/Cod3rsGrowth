using Cod3rsGrowth.dominio;
using static Cod3rsGrowth.dominio.Anime;

namespace Cod3rsGrowth.testes
{
    public interface IAnimeRepositorio
    {
        List<Anime> ObterTodos(Status? statusDeExibicao = null);
        Anime ObterPorId(int id);
        void Cadastrar(Anime anime);
        void Deletar(int id);
        void Atualizar(Anime anime);
    }
}
