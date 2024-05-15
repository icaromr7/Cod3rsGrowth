using Cod3rsGrowth.dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cod3rsGrowth.testes
{
    public class GeneroRepository : IGeneroRepositorio
    {
        public GeneroRepository() { }

        public string Atualizar(Genero genero)
        {
            throw new NotImplementedException();
        }

        public string Cadastrar(Genero genero)
        {
            throw new NotImplementedException();
        }

        public string Deletar(Genero genero)
        {
            throw new NotImplementedException();
        }

        public Genero ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public List <Genero> ObterTodos()
        {
            List<Genero> generos = new List<Genero>();
            return generos;
        }
    }
}
