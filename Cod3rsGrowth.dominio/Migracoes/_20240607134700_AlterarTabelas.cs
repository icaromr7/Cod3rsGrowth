using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cod3rsGrowth.dominio.Migracoes
{
    [Migration(20240607134700)]
    public class _20240607134700_AlterarTabelas : Migration
    {
        public override void Down()
        {
            Delete.Table("AnimeGenero");
            Delete.Table("Anime");
            Delete.Table("Genero");
        }

        public override void Up()
        {
            Down();
            Create.Table("Anime")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Nome").AsString().NotNullable()
                .WithColumn("Sinopse").AsString().NotNullable()
                .WithColumn("DataLancamento").AsDateTime().NotNullable()
                .WithColumn("Nota").AsDecimal().NotNullable()
                .WithColumn("StatusDeExibicao").AsString().NotNullable();
            Create.Table("Genero")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Nome").AsString().NotNullable();
            Create.Table("AnimeGenero")
                .WithColumn("IdAnime").AsInt32().NotNullable().ForeignKey("Anime", "Id")
                .WithColumn("IdGenero").AsInt32().NotNullable().ForeignKey("Genero", "Id");
        }
    }
}
