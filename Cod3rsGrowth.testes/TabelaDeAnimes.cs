using Cod3rsGrowth.dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cod3rsGrowth.testes
{
    public sealed class TabelaDeAnimes
    {
        private static readonly TabelaDeAnimes instance = new TabelaDeAnimes();

        public List<Anime> Animes { get { new Anime(1, "Anime1", "Sinopse1", List<int>generosIds, )} }

        private TabelaDeAnimes() { }
        public static TabelaDeAnimes Instance {  get { return instance; } }
    }
}
