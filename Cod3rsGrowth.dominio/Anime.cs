using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public Status StatusDeExibicao { get; set; }
        public enum Status
        {
            [Description("Está exibindo episódios do anime")]
            EmExibicao = 1,
            [Description("O anime ainda não está em exibição, em previsão de lançamento")]
            Previsto = 2,
            [Description("O anime ou a temporada do anime já foi finalizada")]
            Concluido = 3
        }      
    }
}
