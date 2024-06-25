using System.ComponentModel;

namespace Cod3rsGrowth.dominio
{
    public class FiltroAnime
    {
        public string? Nome { get; set; }
        public DateTime? DataLancamento { get; set; }
        public Anime.Status? StatusExibicao { get; set; }
        
    }
}
