using Cod3rsGrowth.dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cod3rsGrowth.testes
{
    public sealed class TabelaDeAnime
    {
        private static List<Anime> instance = new List<Anime>();
        
        public static List<Anime> Instance { get { return instance; } }
        
    }
}
