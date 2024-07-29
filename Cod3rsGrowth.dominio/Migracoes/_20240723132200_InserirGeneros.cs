using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cod3rsGrowth.dominio.Migracoes
{
    [Migration(20240723132200)]
    public class _20240723132200_InserirGeneros : Migration
    {
        public override void Down()
        {
            throw new NotImplementedException();
        }

        public override void Up()
        {
            Insert.IntoTable("Genero").Row(new { Nome = "Ação" });
            Insert.IntoTable("Genero").Row(new { Nome = "Aventura" });
            Insert.IntoTable("Genero").Row(new { Nome = "Comédia" });
            Insert.IntoTable("Genero").Row(new { Nome = "Drama" });
            Insert.IntoTable("Genero").Row(new { Nome = "Slice of Life" });
            Insert.IntoTable("Genero").Row(new { Nome = "Fantasia" });
            Insert.IntoTable("Genero").Row(new { Nome = "Magia" });
            Insert.IntoTable("Genero").Row(new { Nome = "Super Poderes" });
            Insert.IntoTable("Genero").Row(new { Nome = "Sobrenatural" });
            Insert.IntoTable("Genero").Row(new { Nome = "Terror" });
            Insert.IntoTable("Genero").Row(new { Nome = "Mistério" });
            Insert.IntoTable("Genero").Row(new { Nome = "Psicológico" });
            Insert.IntoTable("Genero").Row(new { Nome = "Romance" });
            Insert.IntoTable("Genero").Row(new { Nome = "Ficção Científica" });
            Insert.IntoTable("Genero").Row(new { Nome = "Cyberpunk" });
            Insert.IntoTable("Genero").Row(new { Nome = "Espaço" });
            Insert.IntoTable("Genero").Row(new { Nome = "Mecha" });
            Insert.IntoTable("Genero").Row(new { Nome = "Musical" });
            Insert.IntoTable("Genero").Row(new { Nome = "Esporte" });
            Insert.IntoTable("Genero").Row(new { Nome = "Jogo" });
            Insert.IntoTable("Genero").Row(new { Nome = "Militar" });
            Insert.IntoTable("Genero").Row(new { Nome = "Histórico" });
            Insert.IntoTable("Genero").Row(new { Nome = "Paródia" });
            Insert.IntoTable("Genero").Row(new { Nome = "Shounen" });
            Insert.IntoTable("Genero").Row(new { Nome = "Shoujo" });
            Insert.IntoTable("Genero").Row(new { Nome = "Seinen" });
            Insert.IntoTable("Genero").Row(new { Nome = "Harem" });
            Insert.IntoTable("Genero").Row(new { Nome = "Ecchi" });
            Insert.IntoTable("Genero").Row(new { Nome = "Mahou Shoujo" });
            Insert.IntoTable("Genero").Row(new { Nome = "Tragédia" });
            Insert.IntoTable("Genero").Row(new { Nome = "Vampiro" });
            Insert.IntoTable("Genero").Row(new { Nome = "Artes Marciais" });
            Insert.IntoTable("Genero").Row(new { Nome = "Demônios" });
            Insert.IntoTable("Genero").Row(new { Nome = "Samurai" });
            Insert.IntoTable("Genero").Row(new { Nome = "Isekai" });
        }
    }
}
