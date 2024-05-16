using Cod3rsGrowth.dominio;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cod3rsGrowth.testes
{
    public  static class ComparacaoGenero
    {
        public  static bool Equals(List<Genero> x, List<Genero> y)
        {
            int cont = x.Count;
            for (int i= 0; i < cont; i++)
            {
                if (x[i].Id != y[i].Id || x[i].Nome != y[i].Nome) return false;
            }
            return true;
        }    
    }
}
