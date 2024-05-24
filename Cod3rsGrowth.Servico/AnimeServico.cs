using Cod3rsGrowth.dominio;
using Cod3rsGrowth.testes;
using FluentValidation;
using FluentValidation.Results;

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
        public void Atualizar(Anime anime)
        {
            ValidationResult result = _animeValidador.Validate(anime, options => options.IncludeRuleSets(Constantes.DEFAULT,Constantes.ATUALIZAR));
            if (result.IsValid)
            {
                _animeRepositorio.Atualizar(anime);
            }
            else
            {
                throw new ValidationException(result.Errors);
            }
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
    }
}
