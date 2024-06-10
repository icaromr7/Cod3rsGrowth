using Cod3rsGrowth.dominio;

namespace Cod3rsGrowth.testes
{
    public class AnimeGeneroRepositorioMock : IAnimeGeneroRepositorio
    {
        public void Atualizar(AnimeGenero animeGenero)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(AnimeGenero animeGenero)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<AnimeGenero> ObterPorId(int idAnime)
        {
            throw new NotImplementedException();
        }

        public List<AnimeGenero> ObterTodos()
        {
            throw new NotImplementedException();
        }
    }
}
