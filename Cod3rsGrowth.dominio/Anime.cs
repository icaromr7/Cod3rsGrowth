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
