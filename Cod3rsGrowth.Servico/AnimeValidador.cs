using Cod3rsGrowth.dominio;
using Cod3rsGrowth.testes;
using FluentValidation;

namespace Cod3rsGrowth.Servico
{
    public class AnimeValidador : AbstractValidator<Anime>
    {
        private IAnimeRepositorio _animeRepositorio;
        public AnimeValidador(IAnimeRepositorio animeRepositorio)
        {
            _animeRepositorio = animeRepositorio;
            RuleFor(anime => anime.Nome).Cascade(CascadeMode.Stop).NotNull().WithMessage("Nome não pode ser nullo")
                .NotEmpty().WithMessage("Nome não pode está vazio");
            RuleFor(anime => anime.Sinopse).Cascade(CascadeMode.Stop).NotNull().WithMessage("Sinopse não pode ser nullo")
                .NotEmpty().WithMessage("Sinopse não pode está vazia"); ;
            RuleFor(anime => anime.GenerosIds).Cascade(CascadeMode.Stop).NotNull().WithMessage("GenerosIds não pode ser nullo")
                .NotEmpty().WithMessage("GenerosIds não pode está vazio");
            RuleFor(anime => anime.DataLancamento).NotEmpty().WithMessage("Data Lançamento não pode está vazia");
            RuleFor(anime => anime.Nota).NotEmpty().WithMessage("Nota não pode está vazia");
            RuleFor(anime => anime.StatusDeExibicao).NotEmpty().WithMessage("Status de Exibição não pode está vazio");
            RuleSet(ConstantesDoValidador.ATUALIZAR, () =>
            {
                RuleFor(anime => anime.Id)
            .Must(id =>
            {
                return !VerificarSeJaExiste(id) == false;
            })
            .WithMessage("O anime não existe");
            });
        }
        public bool VerificarSeJaExiste(int id)
        {
            var _anime = _animeRepositorio.ObterPorId(id);
            if (_anime != null)
            {
                return true;
            }
            return false;
        }
    }
   
}
