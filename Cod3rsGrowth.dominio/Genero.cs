using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cod3rsGrowth.dominio
{
    internal class Genero
    {
        private long id;
        private string nome;

        public Genero(string nome)
        {
            this.nome = nome;
        }

        public long getId() { return id; }
        public string getNome() {  return nome; }

        public void setNome(string nome) {  this.nome = nome; }

        public void setId(long id) { this.id = id;}
        
        public string toString() { return nome; }

    }
}
