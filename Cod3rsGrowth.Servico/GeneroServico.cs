using Cod3rsGrowth.dominio;
using Cod3rsGrowth.testes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cod3rsGrowth.Servico
{
    public class GeneroServico : IGeneroServico
    {
        private IGeneroRepositorio _generoRepositorio;
        public GeneroServico(IGeneroRepositorio generoRepositorio)
        {
            _generoRepositorio = generoRepositorio;
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
            var genero = _generoRepositorio.ObterPorId(id);
            return genero;
        }

        public List<Genero> ObterTodos()
        {
            var generos = _generoRepositorio.ObterTodos();
            return generos;
        }
    }
}
