using Cod3rsGrowth.dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cod3rsGrowth.dominio
{
    public interface IGeneroRepositorio
    {
        List<Genero> ObterTodos(string nome = null);
        Genero ObterPorId(int id);

        int Cadastrar(Genero genero);
        void Deletar(int id);
        void Atualizar(Genero genero);
    }
}
