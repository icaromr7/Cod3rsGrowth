using Cod3rsGrowth.dominio;
using EnumsNET;
using FluentValidation;
using FluentValidation.Results;
using LinqToDB.Data;
using System;
using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using static Cod3rsGrowth.dominio.Anime;

namespace Cod3rsGrowth.Servico
{
    public class AnimeServico
    {
        private IAnimeRepositorio _animeRepositorio;
        private IValidator<Anime> _animeValidador;
        public AnimeServico(IAnimeRepositorio animeRepositorio, IValidator<Anime> animeValidador)
        {
            _animeRepositorio = animeRepositorio;
            _animeValidador = animeValidador;
        }
        public void Atualizar(Anime anime)
        {
            ValidationResult result = _animeValidador.Validate(anime, options => options.IncludeRuleSets(ConstantesDoValidador.DEFAULT, ConstantesDoValidador.ATUALIZAR));
            if (result.IsValid)
            {
                _animeRepositorio.Atualizar(anime);
            }
            else
            {
                throw new ValidationException(result.Errors);
            }
        }

        public int Cadastrar(Anime anime)
        {
            _animeValidador.ValidateAndThrow(anime);
            int idAnime = _animeRepositorio.Cadastrar(anime);
            return idAnime;
        }

        public void Deletar(int id)
        {
            var anime = new Anime
            {
                Id = id
            };
            ValidationResult result = _animeValidador.Validate(anime, options => options.IncludeRuleSets(ConstantesDoValidador.DELETAR));
            if (result.IsValid)
            {
                _animeRepositorio.Deletar(anime.Id);
            }
            else
            {
                throw new ValidationException(result.Errors);
            }

        }
        public Anime ObterPorId(int id)
        {
            var anime = _animeRepositorio.ObterPorId(id);
            return anime;
        }

        public List<Anime> ObterTodos(FiltroAnime? filtro)
        {
            var animes = _animeRepositorio.ObterTodos(filtro);
            return animes;
        }
        public List<StatusExibicao> getDescricaoEnum() {
            List<StatusExibicao> statusDeExibicao = new List<StatusExibicao>();
            Array? status = Enum.GetValues(typeof(Anime.Status));
            int i = 0;
            var statusExibicao = new StatusExibicao
            {
                id = i,
                descricao = "Todos"
            };
            statusDeExibicao.Add(statusExibicao);
            i++;
            foreach (var item in status)
            {            
                statusExibicao = new StatusExibicao
                {
                    id = i,
                    descricao = ((Anime.Status)item).AsString(EnumFormat.Description)
                };
                statusDeExibicao.Add(statusExibicao);
                i++;
            }
            return statusDeExibicao;
        }
    }
}
