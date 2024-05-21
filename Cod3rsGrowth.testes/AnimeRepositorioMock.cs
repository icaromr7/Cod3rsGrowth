using Cod3rsGrowth.dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cod3rsGrowth.testes
{
    public class AnimeRepositorioMock : IAnimeRepositorio
    {
        public AnimeRepositorioMock()
        {
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
            var anime = TabelaDeAnime.Instance.Find(delegate (Anime anime1){ return anime1.Id == id; });
            return anime;
        }
        public List<Anime> ObterTodos()
        {
            var animes = TabelaDeAnime.Instance;
            return animes;
        }
    }
}
