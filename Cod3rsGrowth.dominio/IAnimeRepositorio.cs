using Cod3rsGrowth.dominio;

namespace Cod3rsGrowth.testes
{
    public interface IAnimeRepositorio
    {
        List<Anime> ObterTodos();
        Anime ObterPorId(int id);
        void Cadastrar(Anime anime);
        void Deletar(int id);
        void Atualizar(Anime anime);
    }
}
