using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Cod3rsGrowth.dominio
{
    public class Anime
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public List<Genero> Generos { get; set; } = new List<Genero>();
        public DateTime DataLancamento { get; set; }
        public decimal Nota { get; set; }
        public StatusDeExibicao StatusDeExibicao { get; set; }

        public Anime(long id, string nome, List<Genero> generos, DateTime dataLancamento, decimal nota, StatusDeExibicao statusDeExibicao)
        {
            this.Id = id;
            this.Nome = nome;
            this.Generos = generos;
            this.DataLancamento = dataLancamento;
            this.Nota = Nota;
            this.StatusDeExibicao = statusDeExibicao;
        }
    }
}
