using Cod3rsGrowth.dominio;
using Cod3rsGrowth.testes;
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
        private AnimeValidador _animeValidador;
        public AnimeServico(IAnimeRepositorio animeRepositorio)
        {
            _animeRepositorio = animeRepositorio;
            _animeValidador = new AnimeValidador();
        }
        public string Atualizar(Anime anime)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Anime anime)
        {
            try
            {
                if (ValidarAnime(anime)==true&&VerificarSeJaExiste(anime)==false)
                {
                    _animeRepositorio.Cadastrar(anime);
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
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

        public bool ValidarAnime(Anime anime)
        {
            ValidationResult result = _animeValidador.Validate(anime);
            if (result.IsValid)
            {
                return true;
            }
            return false;
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
