using Cod3rsGrowth.dominio;
using FluentValidation;

namespace Cod3rsGrowth.Servico
{
    public class AnimeGeneroValidador : AbstractValidator<AnimeGenero>
    {
        private IAnimeGeneroRepositorio _animeGeneroRepositorio;
        public AnimeGeneroValidador(IAnimeGeneroRepositorio animeGeneroRepositorio) {
            _animeGeneroRepositorio = animeGeneroRepositorio;
            RuleFor(animeGenero => animeGenero.IdAnime).NotEmpty().WithMessage("IdAnime não pode está vazio");
            RuleFor(animeGenero => animeGenero.IdGenero).NotEmpty().WithMessage("IdGenero não pode está vazio");
            RuleSet(ConstantesDoValidador.ATUALIZAR, () =>
            {
                RuleFor(animeGenero => animeGenero.IdAnime)
            .Must(id =>
            {
                return VerificarSeJaExiste(id);
            })
            .WithMessage("O animeGenero não existe");
            });           
        }

        public bool VerificarSeJaExiste(int idAnime)
        {
            var animeGenero1 = _animeGeneroRepositorio.ObterPorId(idAnime);
            if (animeGenero1 != null)
            {
                return true;
            }
            return false;
        }
    }
}
