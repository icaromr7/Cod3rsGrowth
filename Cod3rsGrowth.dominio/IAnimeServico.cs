using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cod3rsGrowth.dominio
{
    public interface IAnimeServico
    {
        List<Anime> ObterTodos();
        Anime ObterPorId(int id);
        void Cadastrar(Anime anime);
        String Deletar(Anime anime);
        String Atualizar(Anime anime);
        bool ValidarAnime(Anime anime);
        bool VerificarSeJaExiste(Anime anime);
    }
}
