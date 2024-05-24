using Cod3rsGrowth.dominio;
using Cod3rsGrowth.Servico;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
namespace Cod3rsGrowth.testes
{
    public class TesteDoServicoDeGenero : TesteBase {
        private IGeneroServico _generoServico;
        private IGeneroRepositorio _generoRepositorio;
        public TesteDoServicoDeGenero()
        {
            _generoServico = FornecedorDeServicos.GetService<IGeneroServico>();
            _generoRepositorio = FornecedorDeServicos.GetService<IGeneroRepositorio>();
        }
        [Fact]
        public void Ao_obter_todos_deve_retornar_uma_lista_com_generos()
        {
            var genero1 = new Genero
            {
                Id = 1,
                Nome = "Acao"
            };
            TabelaDeGenero.Instance.Add(genero1);

            //act
            List<Genero> generos = _generoServico.ObterTodos();
            const int quantidadeEsperada = 1;
            int quantidadeAtual = generos.Count();

            //assert
            Assert.Equal(quantidadeEsperada, quantidadeAtual);
        }
        [Fact]
        public void Ao_obter_por_id_deve_retornar_um_genero_especifico()
        {
            var genero1 = new Genero
            {
                Id = 1,
                Nome = "Acao"
            };
            TabelaDeGenero.Instance.Add(genero1);

            //act
            Genero genero = _generoServico.ObterPorId(1);
            int idEsperado = 1;

            //assert
            Assert.Equal(idEsperado, genero.Id);
        }
        [Fact]
        public void Ao_obter_por_id_deve_retornar_um_genero_nullo()
        {
            //act
            Genero genero = _generoServico.ObterPorId(2);

            //assert
            Assert.Null(genero);
        }
        [Fact]
        public void Ao_tentar_cadastrar_deve_retornar_um_genero_nullo()
        {
            var genero1 = new Genero
            {
                Id = 1,
                Nome = null
            };

            //act
            var mensagemError = Assert.Throws<ValidationException>(() => _generoServico.Cadastrar(genero1));

            //assert
            Assert.Equal("Nome não pode ser nullo", mensagemError.Errors.Single().ErrorMessage);
        }     
        [Fact]
        public void Ao_cadastrar_deve_retornar_o_anime_cadastrado()
        {
            var genero1 = new Genero
            {
                Id = 1,
                Nome = "Acao"
            };

            //act
            _generoServico.Cadastrar(genero1);
            Genero genero = _generoRepositorio.ObterPorId(1);

            //assert
            Assert.NotNull(genero);
        }
        [Fact]
        public void Ao_atualizar_deve_retornar_o_genero_nao_existe()
        {         
            var genero1 = new Genero
            {
                Id = 1,
                Nome = "Aventura"
            };
            //act
            var mensagemError = Assert.Throws<ValidationException>(() => _generoServico.Atualizar(genero1)); 
            Genero genero = _generoRepositorio.ObterPorId(1);

            //assert
            Assert.Equal("O genero não existe", mensagemError.Errors.Single().ErrorMessage);
        }
        [Fact]
        public void Ao_atualizar_deve_retornar_o_genero_atualizado()
        {
            var genero1 = new Genero
            {
                Id = 1,
                Nome = "Acao"
            };
            TabelaDeGenero.Instance.Add(genero1);
            var genero2 = new Genero
            {
                Id = 1,
                Nome = "Aventura"
            };
            //act
            _generoServico.Atualizar(genero2);
            Genero genero = _generoRepositorio.ObterPorId(1);

            //assert
            Assert.Equivalent(genero2.Nome, genero.Nome);
            Assert.Equivalent(genero2,genero);
        }
    }  
}