using Cod3rsGrowth.dominio;
using Cod3rsGrowth.testes;
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
        private IGeneroRepositorio _generoRepositorio;
        public GeneroValidador(IGeneroRepositorio generoRepositorio) {
            _generoRepositorio = generoRepositorio;
            RuleFor(genero => genero.Nome).NotNull().WithMessage("Nome não pode ser nullo");
            RuleSet(ConstantesDoValidador.ATUALIZAR, () =>
            {
                RuleFor(genero => genero.Id)
            .Must(id =>
            {
                return !VerificarSeJaExiste(id) == false;
            })
            .WithMessage("O genero não existe");
            });
        }
        public bool VerificarSeJaExiste(int id)
        {
            var _genero = _generoRepositorio.ObterPorId(id);
            if (_genero != null)
            {
                return true;
            }
            return false;
        }
    }
}
