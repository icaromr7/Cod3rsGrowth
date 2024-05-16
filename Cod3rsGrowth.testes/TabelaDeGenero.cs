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
        
        private TabelaDeGenero() { }  
        public static List<Genero> GetTabelaGenero()
        {
            if (TabelaDeGeneros == null)
            { 
                TabelaDeGeneros = new List<Genero>
                {
                    new Genero(1, "Acao")
                };
            }
            return TabelaDeGeneros;
        }
        
    }
}
