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
        private static TabelaDeGeneros instance = null;
        private static readonly object locker = new object();
        private static List<Genero> _generos = new List<Genero>();

        private TabelaDeGeneros() { }
        public static TabelaDeGeneros Instance { 
            get {
                if(instance == null)
                {
                    instance = new TabelaDeGeneros();
                }
                return instance; } 
        }
        public static List<Genero> ObterGeneros()
        {
            lock (locker) {
                _generos.Add(new Genero(1, "Acao"));
                _generos.Add(new Genero(2, "Aventura"));
                _generos.Add(new Genero(3, "Drama"));
                _generos.Add(new Genero(4, "Comedia"));
                return _generos;
            }
        }
    }
}
