using Cod3rsGrowth.dominio;

namespace Cod3rsGrowth.testes
{
    public interface IAnimeRepositorio
    {
        List<Anime> ObterTodos();
        Anime ObterPorId(int id);
        void Cadastrar(Anime anime);
        void Deletar(Anime anime);
        void Atualizar(Anime anime);
        List<Anime> ObterPorGeneroId(int generoId);
        void DeletarGeneroDeletado(int generoId);

    }
}
