using Cod3rsGrowth.dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cod3rsGrowth.testes
{
    public sealed class TabelaDeGeneros
    {
        private static readonly TabelaDeGeneros instance = new TabelaDeGeneros();
        public List<Genero> Generos
        {
            get { Generos.Add(new Genero(1, "Acao"));
                  Generos.Add(new Genero(2, "Aventura"));
                  Generos.Add(new Genero(3, "Drama"));
                  Generos.Add(new Genero(4, "Comedia"));
                return Generos; }
            }
        private TabelaDeGeneros() { }
        public static TabelaDeGeneros Instance { 
            get { return instance; } }
    }
}
