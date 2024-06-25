using Cod3rsGrowth.dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cod3rsGrowth.testes
{
    public sealed class TabelaDeAnimeGenero
    {
        private static List<AnimeGenero> instance = new List<AnimeGenero>();
        public static List<AnimeGenero> Instance { get { return instance; } }
    }
}
