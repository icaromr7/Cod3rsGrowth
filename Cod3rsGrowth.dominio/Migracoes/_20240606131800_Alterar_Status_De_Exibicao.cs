using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cod3rsGrowth.dominio.Migracoes
{
    [Migration(20240606131800)]
    public class _20240606131800_Alterar_Status_De_Exibicao : Migration
    {
        public override void Down()
        {
            Delete.Table("Anime");
            Delete.Table("Genero");
        }

        public override void Up()
        {
            Alter.Table("Anime")
                .AlterColumn("StatusDeExibicao").AsInt32();
        }
    }
}
