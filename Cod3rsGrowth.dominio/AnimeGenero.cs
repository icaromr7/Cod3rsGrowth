using LinqToDB.Mapping;

namespace Cod3rsGrowth.dominio
{
    public class AnimeGenero
    {
        [Column]
        public int IdAnime {  get; set; }
        [Column]
        public int IdGenero { get; set; }
    }
}
