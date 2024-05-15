using Cod3rsGrowth.dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cod3rsGrowth.testes
{
    public interface IGeneroServico
    {
        Genero ObterTodos();
        Genero ObterPorId(int id);
    }
}
