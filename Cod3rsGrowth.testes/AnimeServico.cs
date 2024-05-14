using Cod3rsGrowth.dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cod3rsGrowth.testes
{
    public interface AnimeServico
    {
        Anime buscartodosAnime();
        Anime buscarAnime(int id);
        String inserirAnime(Anime anime);
        String deletarAnime(Anime anime);
        String deletarAnimePorId(int id);
        String alterarAnime(Anime anime);
        

    }
}
