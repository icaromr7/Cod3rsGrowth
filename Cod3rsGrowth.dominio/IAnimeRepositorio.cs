using Cod3rsGrowth.dominio;

namespace Cod3rsGrowth.testes
{
    public interface IAnimeRepositorio
    {
        List<Anime> ObterTodos();
        Anime ObterPorId(int id);
        void Cadastrar(Anime anime);
        String Deletar(Anime anime);
        void Atualizar(Anime anime);
    }
}
