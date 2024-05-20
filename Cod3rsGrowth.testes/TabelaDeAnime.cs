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
        private static List<Anime> Instance = null;
        
        public static List<Anime> GetInstance()
        {
            if (Instance == null)
            {
                Instance = new List<Anime>();
            }
            return Instance;
        }
    }
}
