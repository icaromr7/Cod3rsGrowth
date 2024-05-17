using Cod3rsGrowth.dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cod3rsGrowth.testes
{
    public class AnimeServicosTestes : IAnimeServico
    {
        private AnimeRepositorioMock animeRepositorioMock;
        public AnimeServicosTestes() {
            animeRepositorioMock = new AnimeRepositorioMock();
        }
        public string Atualizar(Anime anime)
        {
            throw new NotImplementedException();
        }

        public string Cadastrar(Anime anime)
        {
            throw new NotImplementedException();
        }

        public string Deletar(Anime anime)
        {
            throw new NotImplementedException();
        }

        public Anime ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Anime> ObterTodos()
        {
            List<Anime> animes = new List<Anime>();
            animes = animeRepositorioMock.ObterTodos();
            return animes;
        }
    }
}
