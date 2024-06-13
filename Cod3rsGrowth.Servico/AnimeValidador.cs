using Cod3rsGrowth.dominio;
using FluentValidation;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;

namespace Cod3rsGrowth.Servico
{
    public class AnimeValidador : AbstractValidator<Anime>
    {
        private IAnimeRepositorio _animeRepositorio;
        public AnimeValidador(IAnimeRepositorio animeRepositorio)
        {
            _animeRepositorio = animeRepositorio;
            RuleFor(anime => anime.Nome).Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Nome não pode ser nullo")
                .NotEmpty().WithMessage("Nome não pode está vazio");
            RuleFor(anime => anime.Sinopse).Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("Sinopse não pode ser nullo")
                .NotEmpty().WithMessage("Sinopse não pode está vazia");
            RuleFor(anime => anime.DataLancamento)
                .NotEmpty().WithMessage("Data Lançamento não pode está vazia")
                .Must(dataLancamento =>
                {
                    return VerificarSeNaoEDataFutura(dataLancamento) == true;
                }
                )
                .When(anime => anime.StatusDeExibicao == Anime.Status.EmExibicao || anime.StatusDeExibicao == Anime.Status.Concluido)
                .WithMessage("A data de lançamento não pode ser futura quando o anime está em exibição ou concluido");
                RuleFor(anime => anime.DataLancamento)
                .Must(dataLancamento =>
                {
                    return VerificarSeNaoEDataFutura(dataLancamento) == false;
                }
                )
                .When(anime => anime.StatusDeExibicao == Anime.Status.Previsto)
                .WithMessage("A data de lançamento não pode ser atual ou está no passado quando o anime está previsto");
            RuleFor(anime => anime.Nota)
                .NotEmpty().WithMessage("Nota não pode está vazia");
            RuleFor(anime => anime.StatusDeExibicao)
                .NotEmpty().WithMessage("Status de Exibição não pode está vazio");                             
            RuleSet(ConstantesDoValidador.ATUALIZAR, () =>
            {
                RuleFor(anime => anime.Id)
            .Must(id =>
            {
                return !VerificarSeJaExiste(id) == false;
            })
            .WithMessage("O anime não existe");
            });
            RuleSet(ConstantesDoValidador.DELETAR, () =>
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
        public bool VerificarSeNaoEDataFutura(DateTime dataLancamento)
        {
            
            DateTime dateTime = DateTime.Now;
            int result = DateTime.Compare(dataLancamento, dateTime);
            if (result > 0)
                return false;
            return true;
        }       
    }
   
}
