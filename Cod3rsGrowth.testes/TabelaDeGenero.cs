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
        private static List<Genero> TabelaDeGeneros = null;
        
        public static void ConstruirTabelaGenero() {
            if(TabelaDeGeneros == null)
            {
                TabelaDeGeneros = new List<Genero>();
                TabelaDeGeneros.Add(new Genero(1, "Acao"));
            }
        }  
        public static List<Genero> GetTabelaGenero()
        {
            return TabelaDeGeneros;
        }
        
    }
}
