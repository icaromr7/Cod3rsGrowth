using Cod3rsGrowth.dominio;
using Cod3rsGrowth.testes;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cod3rsGrowth.Servico
{
    public class AnimeServico : IAnimeServico
    {
        private IAnimeRepositorio _animeRepositorio;
        public AnimeServico(IAnimeRepositorio animeRepositorio)
        {
            _animeRepositorio = animeRepositorio;
        }
        public string Atualizar(Anime anime)
        {
            throw new NotImplementedException();
        }

        public string Cadastrar(Anime anime)
        {
            throw new NotImplementedException();
        }

        public string Deletar(Anime anime)
        {
            throw new NotImplementedException();
        }

        public Anime ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Anime> ObterTodos()
        {
            var animes = _animeRepositorio.ObterTodos();
            return animes;
        }
    }
}
