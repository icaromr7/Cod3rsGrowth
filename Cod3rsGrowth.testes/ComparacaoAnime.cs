using Cod3rsGrowth.dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cod3rsGrowth.testes
{
    public static class ComparacaoAnime
    {
        public static bool Equals(List<Anime> x, List<Anime> y)
        {
            int cont = x.Count;
            for (int i = 0; i < cont; i++)
            {
                if (x[i].Id != y[i].Id || x[i].Nome != y[i].Nome|| x[i].Sinopse!= y[i].Sinopse|| 
                    x[i].Nota != y[i].Nota|| x[i].DataLancamento!= y[i].DataLancamento|| 
                    x[i].GenerosIds != y[i].GenerosIds||
                    x[i].StatusDeExibicao!= y[i].StatusDeExibicao) return false;
            }
            return true;
        }
    }
}
