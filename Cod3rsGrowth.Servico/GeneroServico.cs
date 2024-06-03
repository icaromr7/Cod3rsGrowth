using Cod3rsGrowth.dominio;
using Cod3rsGrowth.testes;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Cod3rsGrowth.Servico
{
    public class GeneroServico
    {
        private IGeneroRepositorio _generoRepositorio;
        private IValidator<Genero> _generoValidador;
        public GeneroServico(IGeneroRepositorio generoRepositorio, IValidator<Genero> generoValidador)
        {
            _generoRepositorio = generoRepositorio;
            _generoValidador = generoValidador;
        }
        public void Atualizar(Genero genero)
        {
            ValidationResult result = _generoValidador.Validate(genero, options => options.IncludeRuleSets(ConstantesDoValidador.DEFAULT,ConstantesDoValidador.ATUALIZAR));
            if (result.IsValid)
            {
                _generoRepositorio.Atualizar(genero);
            }
            else
            {
                throw new ValidationException(result.Errors);
            }
        }

        public void Cadastrar(Genero genero)
        {          
            _generoValidador.ValidateAndThrow(genero);  
            _generoRepositorio.Cadastrar(genero);
        }

        public void Deletar(int id)
        {
            Genero genero = new Genero
            {
                Id = id
            };
            ValidationResult result = _generoValidador.Validate(genero, options => options.IncludeRuleSets(ConstantesDoValidador.DELETAR));
            if (result.IsValid)
            {
                _generoRepositorio.Deletar(genero.Id);
            }
            else
            {
                throw new ValidationException(result.Errors);
            }
        }

        public Genero ObterPorId(int id)
        {
            var genero = _generoRepositorio.ObterPorId(id);
            return genero;
        }

        public List<Genero> ObterTodos()
        {
            var generos = _generoRepositorio.ObterTodos();
            return generos;
        }
    }
}
