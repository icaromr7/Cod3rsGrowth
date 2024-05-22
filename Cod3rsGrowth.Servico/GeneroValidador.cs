using Cod3rsGrowth.dominio;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cod3rsGrowth.Servico
{
    public class GeneroValidador : AbstractValidator<Genero>
    {
        public GeneroValidador() {
            RuleFor(genero => genero.Nome).NotNull().WithMessage("Nome não pode ser nullo");
        }
    }
}
