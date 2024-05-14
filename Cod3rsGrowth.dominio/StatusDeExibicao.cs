using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cod3rsGrowth.dominio
{
    public enum StatusDeExibicao
    {
        [Description("Está exibindo episódios do anime")]
        EmExibicao = 1,
        [Description("O anime ainda não está em exibição, em previsão de lançamento")]
        Previsto = 2,
        [Description("O anime ou a temporada do anime já foi finalizada")]
        Concluido = 3
    }
}
