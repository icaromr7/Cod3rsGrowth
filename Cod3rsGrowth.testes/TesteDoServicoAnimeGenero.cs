using Cod3rsGrowth.dominio;
using Cod3rsGrowth.Servico;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.testes
{
    public class TesteDoServicoAnimeGenero : TesteBase
    {
        private AnimeGeneroServico _animeGeneroServico;

        public TesteDoServicoAnimeGenero() {
            _animeGeneroServico = FornecedorDeServicos.GetService<AnimeGeneroServico>();
            TabelaDeAnimeGenero.Instance.Clear();
        }

        [Fact]
        public void Ao_obter_todos_deve_retornar_uma_lista_com_todos_animegeneros()
        {
            var animeGenero = new AnimeGenero()
            {
                IdAnime = 1,
                IdGenero = 1
            };
            TabelaDeAnimeGenero.Instance.Add(animeGenero);

            //act
            List<AnimeGenero> animeGeneros = _animeGeneroServico.ObterTodos(1);
            const int quantidadeEsperada = 1;
            int quantidadeAtual = animeGeneros.Count;

            //assert
            Assert.Equal(quantidadeEsperada, quantidadeAtual);
        }
        [Fact]
        public void Ao_obter_por_id_deve_retornar_um_animegenero_especifico()
        {
            var animeGenero = new AnimeGenero()
            {
                IdAnime = 1,
                IdGenero = 1
            };
            TabelaDeAnimeGenero.Instance.Add(animeGenero);
            int idAnime = 1;
            int idGenero = 1;
            //act
            var animeGeneroAtual = _animeGeneroServico.ObterPorId(idAnime);

            //assert
            Assert.Equivalent(animeGenero, animeGeneroAtual);
        }
        [Fact]
        public void Ao_obter_por_id_deve_returnar_um_animegenero_nullo()
        {
            //act
            var animegenero = _animeGeneroServico.ObterPorId(1);

            //asset
            Assert.Null(animegenero);
        }
        [Fact]
        public void Ao_tentar_cadastrar_deve_retornar_idanime_nao_pode_esta_vazio()
        {
            var animeGenero = new AnimeGenero()
            {
                IdGenero = 1,
            };

            //act
            var mensagemError = Assert.Throws<ValidationException>(()=> _animeGeneroServico.Cadastrar(animeGenero));

            //assert
            Assert.Equal("IdAnime não pode está vazio",mensagemError.Errors.Single().ErrorMessage);
        }
        [Fact]
        public void Ao_tentar_cadastrar_deve_retornar_idgenero_nao_pode_esta_vazio()
        {
            var animeGenero = new AnimeGenero()
            {
                IdAnime = 1,
            };

            //act
            var mensagemError = Assert.Throws<ValidationException>(() => _animeGeneroServico.Cadastrar(animeGenero));

            //assert
            Assert.Equal("IdGenero não pode está vazio", mensagemError.Errors.Single().ErrorMessage);
        }
        [Fact]
        public void Ao_cadastrar_deve_retornar_o_animegenero_cadastrado()
        {
            var animeGenero = new AnimeGenero()
            {
                IdAnime = 1,
                IdGenero = 1
            };
            
            //act
            _animeGeneroServico.Cadastrar(animeGenero);

            //assert
            Assert.Contains(TabelaDeAnimeGenero.Instance, animeGenero1 => animeGenero1 == animeGenero);
        }
        public void Deve_deletar_o_animegenero()
        {
            var animeGenero = new AnimeGenero()
            {
                IdAnime = 1,
                IdGenero = 1,
            };
            TabelaDeAnimeGenero.Instance.Add(animeGenero);
            var animeGeneroDeletado = new AnimeGenero()
            {
                IdAnime = 1,
                IdGenero = 1,
            };
            //act
            _animeGeneroServico.Deletar(animeGeneroDeletado.IdAnime);

            //assert
            Assert.DoesNotContain(TabelaDeAnimeGenero.Instance, animeGenero1 => animeGenero1==animeGenero);
        }
    }
}
