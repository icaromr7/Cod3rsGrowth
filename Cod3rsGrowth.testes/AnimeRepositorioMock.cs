using Cod3rsGrowth.dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cod3rsGrowth.testes
{
    public class AnimeRepositorioMock : IAnimeRepositorioMock
    {
        public AnimeRepositorioMock() { }
        public List<Anime> ObterTodos()
        {
            List<Anime> animes = new List<Anime>();
            return animes;
        }
    }
}
