using FluentMigrator;
using System.Windows.Forms;
using System;

namespace Cod3rsGrowth.forms
{
    [Migration(20240605085700)]
    public class AdicionarTabelas : Migration
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
                .WithColumn("Nome").AsString()
                .WithColumn("Sinopse").AsString()
                .WithColumn("DataLancamento").AsDateTime()
                .WithColumn("GenerosIds").AsInt32().NotNullable()
                .WithColumn("Nota").AsDecimal()
                .WithColumn("StatusDeExibicao").AsString();
            Create.Table("Genero")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Nome").AsString();
            Create.ForeignKey("fk_Anime_GeneroIds_GeneroId")
            .FromTable("Anime").ForeignColumn("GenerosIds")
            .ToTable("Genero").PrimaryColumn("Id");
        }
    }
}