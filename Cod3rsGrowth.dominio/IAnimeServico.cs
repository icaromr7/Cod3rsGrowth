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
        void Deletar(Anime anime);
        void Atualizar(Anime anime);
        List<Anime> ObterPorGeneroId(int generoId);
        void DeletarGeneroDeletado(int generoId);
    }
}
