using Cod3rsGrowth.dominio;
using FluentValidation;

namespace Cod3rsGrowth.Servico
{
    public class GeneroValidador : AbstractValidator<Genero>
    {
        private IGeneroRepositorio _generoRepositorio;
        public GeneroValidador(IGeneroRepositorio generoRepositorio) {
            _generoRepositorio = generoRepositorio;
            RuleFor(genero => genero.Nome).Cascade(CascadeMode.Stop).NotNull().WithMessage("Nome não pode ser nullo")
                .NotEmpty().WithMessage("Nome não pode está vazio")
                .Must(EhGeneroValido).WithMessage("Já existe um gênero com esse nome"); 
            
            RuleSet(ConstantesDoValidador.ATUALIZAR, () =>
            {
                RuleFor(genero => genero.Id)
            .Must(id =>
            {
                return VerificarSeJaExiste(id);
            })
            .WithMessage("O gênero não existe");
            });
            RuleSet(ConstantesDoValidador.DELETAR, () =>
            {
                RuleFor(genero => genero.Id)
            .Must(id =>
            {
                return VerificarSeJaExiste(id);
            })
            .WithMessage("O gênero não existe");
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

        public bool EhGeneroValido(string nomeGenero)
        {
            var listaGeneros = _generoRepositorio.ObterTodos();
            return !listaGeneros.Any(x => x.Nome.ToLower().Trim() == nomeGenero.ToLower().Trim());
        }   
    }
}
