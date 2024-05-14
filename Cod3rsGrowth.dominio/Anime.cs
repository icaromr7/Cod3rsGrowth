using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cod3rsGrowth.dominio
{
    internal class Anime
    {
        private long id;
        private string nome;
        private List<Genero> generos;
        private DateTime data_lancamento;
        private Status status;

        public Anime(string nome, List<Genero> generos, DateTime data_lancamento, Status status)
        {
            this.nome = nome;
            this.generos = generos;
            this.data_lancamento = data_lancamento;
            this.status = status;
        }

        public DateTime Data_lancamento { get => data_lancamento; set => data_lancamento = value; }
        internal List<Genero> Generos { get => generos; set => generos = value; }
        public string Nome { get => nome; set => nome = value; }
        public long Id { get => id; set => id = value; }
        internal Status Status { get => status; set => status = value; }
    }
}
