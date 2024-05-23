using Cod3rsGrowth.dominio;
using Cod3rsGrowth.testes;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cod3rsGrowth.Servico
{
    public class AnimeServico : IAnimeServico
    {
        private IAnimeRepositorio _animeRepositorio;
        private IValidator<Anime> _animeValidador;
        public AnimeServico(IAnimeRepositorio animeRepositorio, IValidator<Anime> animeValidador)
        {
            _animeRepositorio = animeRepositorio;
            _animeValidador = animeValidador;
        }
        public string Atualizar(Anime anime)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Anime anime)
        {
            _animeValidador.ValidateAndThrow(anime);
            _animeRepositorio.Cadastrar(anime);
        }

        public string Deletar(Anime anime)
        {
            throw new NotImplementedException();
        }

        public Anime ObterPorId(int id)
        {
            var anime= _animeRepositorio.ObterPorId(id); 
            return anime;
        }

        public List<Anime> ObterTodos()
        {
            var animes = _animeRepositorio.ObterTodos();
            return animes;
        }
        public bool VerificarSeJaExiste(Anime anime)
        {
            var _anime =_animeRepositorio.ObterPorId(anime.Id);
            if (_anime != null) {
                return true;
            }
            return false;
        }
    }
}
