using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cod3rsGrowth.dominio
{
    public interface IGeneroServico
    {
        List<Genero> ObterTodos();
        Genero ObterPorId(int id);
        void Cadastrar(Genero genero);
        String Deletar(Genero genero);
        String Atualizar(Genero genero);
        bool VerificarSeJaExiste(Genero genero);
    }
}
