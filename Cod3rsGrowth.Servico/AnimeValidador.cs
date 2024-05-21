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
            RuleFor(anime => anime.Id).NotNull();
            RuleFor(anime => anime.Nome).NotNull();
            RuleFor(anime => anime.Sinopse).NotNull();
            RuleFor(anime => anime.GenerosIds).NotNull().NotEmpty();
            RuleFor(anime => anime.DataLancamento).NotNull();
            RuleFor(anime => anime.Nota).NotNull();
            RuleFor(anime => anime.StatusDeExibicao).NotNull();
        }
    }
}
