using FluentMigrator;

namespace Cod3rsGrowth.dominio.Migracoes
{
    [Migration(20240605085700)]
    public class _20240605085700_CriarTabelas : Migration
    {
        public override void Down()
        {
            Delete.Table("Anime");
            Delete.Table("Genero");
        }

        public override void Up()
        {
            Create.Table("Anime")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Nome").AsString().NotNullable()
                .WithColumn("Sinopse").AsString().NotNullable()
                .WithColumn("DataLancamento").AsDateTime().NotNullable()
                .WithColumn("GenerosIds").AsInt32().NotNullable()
                .WithColumn("Nota").AsDecimal().NotNullable()
                .WithColumn("StatusDeExibicao").AsString().NotNullable();
            Create.Table("Genero")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Nome").AsString().NotNullable();
            Create.ForeignKey("fk_Anime_Genero_GeneroId")
            .FromTable("Anime").ForeignColumn("GenerosIds")
            .ToTable("Genero").PrimaryColumn("Id");
        }
    }
}