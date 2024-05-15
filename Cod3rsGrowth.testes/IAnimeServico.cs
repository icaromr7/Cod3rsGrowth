using Cod3rsGrowth.dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cod3rsGrowth.testes
{
    public interface IAnimeServico
    {
        Anime ObterTodos();
        Anime ObterPorId(int id);
        String Cadastrar(Anime anime);
        String Deletar(Anime anime);
        String Atualizar(Anime anime);
    }
}
