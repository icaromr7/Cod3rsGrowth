using Cod3rsGrowth.dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cod3rsGrowth.testes
{
    public sealed class TabelaDeGenero
    {
        private static List<Genero> Instance = null;
        public static List<Genero> GetInstance()
        {
            if (Instance == null)
            {
                Instance = new List<Genero>();
            }
            return Instance;
        }       
    }
}
