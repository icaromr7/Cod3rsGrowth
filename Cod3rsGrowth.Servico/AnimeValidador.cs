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
            RuleFor(anime => anime.GenerosIds).NotNull().NotEmpty().WithMessage("GenerosIds não pode ser nullo e nem está vazio");
            RuleFor(anime => anime.DataLancamento).NotNull().WithMessage("Data Lançamento não pode ser nullo");
            RuleFor(anime => anime.Nota).NotNull().WithMessage("Nota não pode ser nullo");
            RuleFor(anime => anime.StatusDeExibicao).NotNull().WithMessage("Status de Exibição não pode ser nullo");
        }       
    }
}
