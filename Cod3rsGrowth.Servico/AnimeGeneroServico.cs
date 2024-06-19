using Cod3rsGrowth.dominio;
using FluentValidation;
using FluentValidation.Results;

namespace Cod3rsGrowth.Servico
{
    public class AnimeGeneroServico
    {
        private IAnimeGeneroRepositorio _animeGeneroRepositorio;
        private IValidator<AnimeGenero> _animeGeneroValidador;

        public AnimeGeneroServico(IAnimeGeneroRepositorio animeGeneroRepositorio, IValidator<AnimeGenero> animeGeneroValidador)
        {
            _animeGeneroRepositorio = animeGeneroRepositorio;
            _animeGeneroValidador = animeGeneroValidador;
        }
        public void Atualizar(AnimeGenero animeGenero)
        {
            ValidationResult result = _animeGeneroValidador.Validate(animeGenero, options => options.IncludeRuleSets(ConstantesDoValidador.DEFAULT, ConstantesDoValidador.ATUALIZAR));
            if (result.IsValid)
            {
                _animeGeneroRepositorio.Atualizar(animeGenero);
            }
            else
            {
                throw new ValidationException(result.Errors);
            }
        }

        public void Cadastrar(AnimeGenero animeGenero)
        {
            _animeGeneroValidador.ValidateAndThrow(animeGenero);
            _animeGeneroRepositorio.Cadastrar(animeGenero);
        }

        public void Deletar(AnimeGenero animeGenero)
        {                             
            _animeGeneroRepositorio.Deletar(animeGenero);        
        }       
        public AnimeGenero ObterPorId(int idAnime)
        {
            var animeGeneros = _animeGeneroRepositorio.ObterPorId(idAnime);
            return animeGeneros;
        }

        public List<AnimeGenero> ObterTodos(int? idAnime)
        {
            var animeGeneros = _animeGeneroRepositorio.ObterTodos(idAnime);
            return animeGeneros;
        }
    }
}
