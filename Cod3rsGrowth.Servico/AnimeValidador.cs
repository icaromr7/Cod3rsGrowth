using Cod3rsGrowth.dominio;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cod3rsGrowth.Servico
{
    public class AnimeValidador : AbstractValidator<Anime>
    {
        public AnimeValidador()
        {
            RuleFor(anime => anime.Nome).NotNull().WithMessage("Nome não pode ser nullo");
            RuleFor(anime => anime.Sinopse).NotNull().WithMessage("Sinopse não pode ser nullo");
            RuleFor(anime => anime.GenerosIds).NotNull().WithMessage("GenerosIds não pode ser nullo");
            RuleFor(anime => anime.GenerosIds).NotEmpty().WithMessage("GenerosIds não pode está vazio");
            RuleFor(anime => anime.DataLancamento).NotEmpty().WithMessage("Data Lançamento não pode está vazia");
            RuleFor(anime => anime.Nota).NotEmpty().WithMessage("Nota não pode está vazia");
            RuleFor(anime => anime.StatusDeExibicao).NotEmpty().WithMessage("Status de Exibição não pode está vazio");
        }       
    }
}
