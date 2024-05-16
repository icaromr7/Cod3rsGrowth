using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cod3rsGrowth.dominio
{
    public class Genero
    {
        public int Id {get; set;}
        public string Nome {get; set;}

        public Genero(int id,string nome)
        {
            this.Id = id;
            this.Nome = nome;
        }
    }
}
