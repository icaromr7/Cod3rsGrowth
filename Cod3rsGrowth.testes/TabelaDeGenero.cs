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
        private static readonly List<Genero> instance = new List<Genero>();
        public static List<Genero> Instance {  get { return instance; } }      
    }
}
