using Cod3rsGrowth.dominio;
using Cod3rsGrowth.Servico;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using FluentValidation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace Cod3rsGrowth.testes
{
     public class TesteDoServicoDeAnime : TesteBase
    {
        private IAnimeServico _animeServico;
        private IAnimeRepositorio _animeRepositorio;
        public TesteDoServicoDeAnime()
        {
            _animeServico = FornecedorDeServicos.GetService<IAnimeServico>();
            _animeRepositorio = FornecedorDeServicos.GetService<IAnimeRepositorio>();
        }
        [Fact]
        public void Ao_obter_todos_deve_retornar_uma_lista_com_animes()
        {
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
            List<Anime> animes = _animeServico.ObterTodos();
            const int quantidadeEsperada = 1;
            int quantidadeAtual = animes.Count();

            //assert
            Assert.Equal(quantidadeEsperada, quantidadeAtual);
        }
        [Fact]
        public void Ao_obter_por_id_deve_retornar_um_anime_com_id_especifico()
        {
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
            Anime anime = _animeServico.ObterPorId(1);
            int idEsperado = 1;

            //assert
            Assert.Equal(idEsperado, anime.Id);
        }
        [Fact]
        public void Ao_obter_por_id_deve_retornar_um_anime_nullo() {

            //act
            Anime anime = _animeServico.ObterPorId(1);

            //assert
            Assert.Null(anime);
        }
        [Fact]
        public void Ao_tentar_cadastrar_deve_retornar_nome_nao_pode_ser_nullo()
        {
            var anime1 = new Anime
            {
                Id = 1,
                Nome = null,
                Sinopse = "Sinopse1",
                GenerosIds = new List<int>() { 1, 2 },
                DataLancamento = new DateTime(2024, 5, 15),
                Nota = 7.8m,
                StatusDeExibicao = Anime.Status.EmExibicao
            };
            //act
            var mensagemError = Assert.Throws<ValidationException>(() => _animeServico.Cadastrar(anime1));
            //assert
            Assert.Equal("Nome não pode ser nullo", mensagemError.Errors.Single().ErrorMessage);
        }
        [Fact]
        public void Ao_tentar_cadastrar_deve_retornar_sinopse_nao_pode_ser_nullo()
        {
            var anime1 = new Anime
            {
                Id = 1,
                Nome = "Anime1",
                Sinopse = null,
                GenerosIds = new List<int>() { 1, 2 },
                DataLancamento = new DateTime(2024, 5, 15),
                Nota = 7.8m,
                StatusDeExibicao = Anime.Status.EmExibicao
            };
            //act
            var mensagemError = Assert.Throws<ValidationException>(() => _animeServico.Cadastrar(anime1));
            //assert
            Assert.Equal("Sinopse não pode ser nullo", mensagemError.Errors.Single().ErrorMessage);
        }
        [Fact]
        public void Ao_tentar_cadastrar_deve_retornar_generosids_nao_pode_ser_nullo()
        {
            var anime1 = new Anime
            {
                Id = 1,
                Nome = "Anime1",
                Sinopse = "Sinopse1",
                GenerosIds = null,
                DataLancamento = new DateTime(2024, 5, 15),
                Nota = 7.8m,
                StatusDeExibicao = Anime.Status.EmExibicao
            };
            //act
            var mensagemError = Assert.Throws<ValidationException>(() => _animeServico.Cadastrar(anime1));
            //assert
            Assert.Equal("GenerosIds não pode ser nullo", mensagemError.Errors.Single().ErrorMessage);
        }
        [Fact]
        public void Ao_tentar_cadastrar_deve_retornar_generosids_nao_pode_esta_vazio()
        {
            var anime1 = new Anime
            {
                Id = 1,
                Nome = "Anime1",
                Sinopse = "Sinopse1",
                GenerosIds = new List<int>(),
                DataLancamento = new DateTime(2024, 5, 15),
                Nota = 7.8m,
                StatusDeExibicao = Anime.Status.EmExibicao
            };
            //act
            var mensagemError = Assert.Throws<ValidationException>(() => _animeServico.Cadastrar(anime1));
            //assert
            Assert.Equal("GenerosIds não pode está vazio", mensagemError.Errors.Single().ErrorMessage);
        }
        [Fact]
        public void Ao_tentar_cadastrar_deve_retornar_data_lancamento_nao_pode_esta_vazio()
        {
            var anime1 = new Anime
            {
                Id = 1,
                Nome = "Anime1",
                Sinopse = "Sinopse1",
                GenerosIds = new List<int>() { 1, 2},
                DataLancamento = new DateTime(),
                Nota = 7.8m,
                StatusDeExibicao = Anime.Status.EmExibicao
            };
            //act
            var mensagemError = Assert.Throws<ValidationException>(() => _animeServico.Cadastrar(anime1));
            //assert
            Assert.Equal("Data Lançamento não pode está vazia", mensagemError.Errors.Single().ErrorMessage);
        }
        [Fact]
        public void Ao_tentar_cadastrar_deve_retornar_nota_nao_pode_esta_vazio()
        {
            var anime1 = new Anime
            {
                Id = 1,
                Nome = "Anime1",
                Sinopse = "Sinopse1",
                GenerosIds = new List<int>() { 1, 2 },
                DataLancamento = new DateTime(2024, 5, 15),
                Nota = new decimal(),
                StatusDeExibicao = Anime.Status.EmExibicao
            };
            //act
            var mensagemError = Assert.Throws<ValidationException>(() => _animeServico.Cadastrar(anime1));
            //assert
            Assert.Equal("Nota não pode está vazia", mensagemError.Errors.Single().ErrorMessage);
        }
        [Fact]
        public void Ao_tentar_cadastrar_deve_retornar_status_de_exibicao_nao_pode_esta_vazio()
        {
            var anime1 = new Anime
            {
                Id = 1,
                Nome = "Anime1",
                Sinopse = "Sinopse1",
                GenerosIds = new List<int>() { 1, 2 },
                DataLancamento = new DateTime(2024, 5, 15),
                Nota = 7.8m,
                StatusDeExibicao = new Anime.Status() { }
            };
            //act
            var mensagemError = Assert.Throws<ValidationException>(() => _animeServico.Cadastrar(anime1));
            //assert
            Assert.Equal("Status de Exibição não pode está vazio", mensagemError.Errors.Single().ErrorMessage);
        }
        [Fact]
        public void Ao_cadastrar_deve_retornar_o_anime_cadastrado()
        {
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

            //act
            _animeServico.Cadastrar(anime1);
            Anime anime = _animeRepositorio.ObterPorId(1);

            //assert
            Assert.NotNull(anime);
        }
    }
}
