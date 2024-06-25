using LinqToDB.Mapping;

namespace Cod3rsGrowth.dominio
{
    public class Genero
    {
        [PrimaryKey, Identity]
        public int Id {get; set;}
        [Column]
        public string Nome {get; set;}
    }
}
