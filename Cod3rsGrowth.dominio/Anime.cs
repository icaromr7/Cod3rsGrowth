using LinqToDB.Mapping;
using System.ComponentModel;

namespace Cod3rsGrowth.dominio
{
    public class Anime
    {
        [PrimaryKey, Identity]
        public int Id { get; set; }
        [Column]
        public string Nome { get; set; }
        [Column]
        public string Sinopse { get; set; }
        [Column]
        public DateTime DataLancamento { get; set; }
        [Column]
        public decimal Nota { get; set; }
        [Column]
        public Status StatusDeExibicao { get; set; }

        public List<int> IdGeneros { get; set; }
        public enum Status
        {
            [Description("Em Exibição")]
            EmExibicao = 1,
            [Description("Previsto")]
            Previsto =2 ,
            [Description("Concluído")]
            Concluido = 3
        }      
    }
}
