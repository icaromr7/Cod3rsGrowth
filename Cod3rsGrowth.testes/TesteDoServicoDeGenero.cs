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
            TabelaDeGenero.Instance.Remove(genero1);
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
            TabelaDeGenero.Instance.Remove(genero1);
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
        public void Ao_tentar_cadastrar_deve_retornar_nome_nao_pode_esta_vazio()
        {
            var genero1 = new Genero
            {
                Id = 1,
                Nome = ""
            };

            //act
            var mensagemError = Assert.Throws<ValidationException>(() => _generoServico.Cadastrar(genero1));

            //assert
            Assert.Equal("Nome não pode está vazio", mensagemError.Errors.Single().ErrorMessage);
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
            TabelaDeGenero.Instance.Remove(genero1);
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

            //assert
            Assert.Equal("O gênero não existe", mensagemError.Errors.Single().ErrorMessage);
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
            TabelaDeGenero.Instance.Remove(genero1);
            TabelaDeGenero.Instance.Remove(genero2);
        }
        [Fact]
        public void Ao_tentar_atualizar_deve_retornar_nome_nao_pode_ser_nullo()
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
                Nome = null
            };
            //act
            var mensagemError = Assert.Throws<ValidationException>(() => _generoServico.Atualizar(genero2));

            //assert
            Assert.Equal("Nome não pode ser nullo", mensagemError.Errors.Single().ErrorMessage);
            TabelaDeGenero.Instance.Remove(genero1);
        }
        [Fact]
        public void Ao_tentar_atualizar_deve_retornar_nome_nao_pode_esta_vazio()
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
                Nome = ""
            };
            //act
            var mensagemError = Assert.Throws<ValidationException>(() => _generoServico.Atualizar(genero2));

            //assert
            Assert.Equal("Nome não pode está vazio", mensagemError.Errors.Single().ErrorMessage);
            TabelaDeGenero.Instance.Remove(genero1);
        }
        [Fact]
        public void Ao_tentar_deletar_deve_retornar_o_genero_nao_existe()
        {
            var genero1 = new Genero
            {
                Id = 1,
            };
            //act
            var mensagemError = Assert.Throws<ValidationException>(() => _generoServico.Deletar(genero1));

            //assert
            Assert.Equal("O gênero não existe", mensagemError.Errors.Single().ErrorMessage);
        }
        [Fact]
        public void Ao_deletar_deve_retorna_genero_null()
        {
            
            var genero1 = new Genero
            {
                Id = 1,
                Nome = "Aventura"
            };
            TabelaDeGenero.Instance.Add(genero1);
            
            //act
            _generoServico.Deletar(genero1);
            var generoDeletado = _generoServico.ObterPorId(1);

            //assert
            Assert.Null(generoDeletado);
        }
        [Fact]
        public void Ao_deletar_deve_retornar_false_para_o_generoid_em_anime1()
        {
            var genero1 = new Genero
            {
                Id = 1,
                Nome = "Aventura"
            };
            TabelaDeGenero.Instance.Add(genero1);
            var anime1 = new Anime
            {
                Id = 1,
                Nome = "Anime1",
                Sinopse = "Sinopse1",
                GenerosIds = new List<int>() { 1, 2 },
                DataLancamento = new DateTime(2024, 5, 15),
                Nota = 7.8m,
                StatusDeExibicao = Anime.Status.EmExibicao
            };
            TabelaDeAnime.Instance.Add(anime1);

            //act
            _generoServico.Deletar(genero1);
            var anime = anime1.GenerosIds.Contains(1);
            //asert
            Assert.False(anime);
            TabelaDeAnime.Instance.Remove(anime1);
        }
    }  
}