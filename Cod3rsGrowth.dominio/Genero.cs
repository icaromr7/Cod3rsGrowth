using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cod3rsGrowth.dominio
{
    public class Genero
    {
        public long Id {get; set;}
        public string Nome {get; set;}

        public Genero(string nome)
        {
            this.Nome = nome;
        }
        public string toString() { return Nome; }

    }
}
