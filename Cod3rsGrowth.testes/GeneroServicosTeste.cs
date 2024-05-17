using Cod3rsGrowth.dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cod3rsGrowth.testes
{
    internal class GeneroServicosTeste : IGeneroServico
    {
        private GeneroRepositorioMock generoRepositorioMock;
        public GeneroServicosTeste() { 
        generoRepositorioMock = new GeneroRepositorioMock();
        }
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

        public List<Genero> ObterTodos()
        {
            List<Genero> generos = new List<Genero>();
            generos = generoRepositorioMock.ObterTodos();
            return generos;
        }
    }
}
