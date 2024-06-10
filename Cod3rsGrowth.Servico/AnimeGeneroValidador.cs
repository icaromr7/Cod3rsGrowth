using Cod3rsGrowth.dominio;
using FluentValidation;

namespace Cod3rsGrowth.Servico
{
    public class AnimeGeneroValidador : AbstractValidator<AnimeGenero>
    {
        private IAnimeGeneroRepositorio _animeGeneroRepositorio;
        public AnimeGeneroValidador(IAnimeGeneroRepositorio animeGeneroRepositorio) {
            _animeGeneroRepositorio = animeGeneroRepositorio;
            RuleFor(animeGenero => animeGenero.IdAnime).NotEmpty().WithMessage("idAnime não pode está vazio");
            RuleFor(animeGenero => animeGenero.IdGenero).NotEmpty().WithMessage("idGenero não pode está vazio");
            RuleSet(ConstantesDoValidador.ATUALIZAR, () =>
            {
                RuleFor(animeGenero => animeGenero.IdAnime)
            .Must(id =>
            {
                return !VerificarSeJaExiste(id) == false;
            })
            .WithMessage("O animeGenero não existe");
            });
            RuleSet(ConstantesDoValidador.DELETAR, () =>
            {
                RuleFor(animeGenero => animeGenero.IdAnime)
            .Must(id =>
            {
                return !VerificarSeJaExiste(id) == false;
            })
            .WithMessage("O animeGenero não existe");
            });
        }

        public bool VerificarSeJaExiste(int id)
        {
            var animeGenero = _animeGeneroRepositorio.ObterPorId(id);
            if (animeGenero != null)
            {
                return true;
            }
            return false;
        }
    }
}
