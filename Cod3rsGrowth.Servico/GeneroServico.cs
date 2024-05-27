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
    public class GeneroServico : IGeneroServico
    {
        private IGeneroRepositorio _generoRepositorio;
        private IValidator<Genero> _generoValidador;
        private IAnimeServico _animeServico;
        public GeneroServico(IGeneroRepositorio generoRepositorio, IValidator<Genero> generoValidador, IAnimeServico animeServico)
        {
            _generoRepositorio = generoRepositorio;
            _generoValidador = generoValidador;
            _animeServico = animeServico;
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

        public void Deletar(Genero genero)
        {
            ValidationResult result = _generoValidador.Validate(genero, options => options.IncludeRuleSets(ConstantesDoValidador.ATUALIZAR));
            if (result.IsValid)
            {
                _animeServico.DeletarGeneroDeletado(genero.Id);
                _generoRepositorio.Deletar(genero);
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
