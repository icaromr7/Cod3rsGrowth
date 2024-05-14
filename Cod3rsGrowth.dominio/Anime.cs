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
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sinopse { get; set; }
        public List<int> GenerosIds { get; set; } = new List<int>();
        public DateTime DataLancamento { get; set; }
        public decimal Nota { get; set; }
        public StatusDeExibicao StatusDeExibicao { get; set; }

        public Anime(int id, string nome, string sinopse, List<int> generosIds, DateTime dataLancamento, decimal nota, StatusDeExibicao statusDeExibicao)
        {
            this.Id = id;
            this.Nome = nome;
            this.Sinopse = sinopse;
            this.GenerosIds = generosIds;
            this.DataLancamento = dataLancamento;
            this.Nota = Nota;
            this.StatusDeExibicao = statusDeExibicao;
        }
    }
}
