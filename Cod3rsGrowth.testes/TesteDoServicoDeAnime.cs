using Cod3rsGrowth.dominio;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;

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
            TabelaDeAnime.Instance.Remove(anime1);
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
            TabelaDeAnime.Instance.Remove(anime1);
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
        public void Ao_tentar_cadastrar_deve_retornar_nome_nao_pode_esta_vazio()
        {
            var anime1 = new Anime
            {
                Id = 1,
                Nome = "",
                Sinopse = "Sinopse1",
                GenerosIds = new List<int>() { 1, 2 },
                DataLancamento = new DateTime(2024, 5, 15),
                Nota = 7.8m,
                StatusDeExibicao = Anime.Status.EmExibicao
            };
            //act
            var mensagemError = Assert.Throws<ValidationException>(() => _animeServico.Cadastrar(anime1));
            //assert
            Assert.Equal("Nome não pode está vazio", mensagemError.Errors.Single().ErrorMessage);
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
        public void Ao_tentar_cadastrar_deve_retornar_sinopse_nao_pode_esta_vazia()
        {
            var anime1 = new Anime
            {
                Id = 1,
                Nome = "Anime1",
                Sinopse = "",
                GenerosIds = new List<int>() { 1, 2 },
                DataLancamento = new DateTime(2024, 5, 15),
                Nota = 7.8m,
                StatusDeExibicao = Anime.Status.EmExibicao
            };
            //act
            var mensagemError = Assert.Throws<ValidationException>(() => _animeServico.Cadastrar(anime1));
            //assert
            Assert.Equal("Sinopse não pode está vazia", mensagemError.Errors.Single().ErrorMessage);
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
            TabelaDeAnime.Instance.Remove(anime1);
        }
        [Fact]
        public void Ao_tentar_editar_anime_deve_retornar_o_anime_nao_existe()
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
            var mensagemError = Assert.Throws<ValidationException>(() => _animeServico.Atualizar(anime1));
            //assert
            Assert.Equal("O anime não existe", mensagemError.Errors.Single().ErrorMessage);
        }
        [Fact]
        public void Ao_atualizar_o_nome_deve_retornar_o_nome_atualizado()
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
            var anime2 = new Anime
            {
                Id = 1,
                Nome = "Anime2",
                Sinopse = "Sinopse1",
                GenerosIds = new List<int>() { 1, 2 },
                DataLancamento = new DateTime(2024, 5, 15),
                Nota = 7.8m,
                StatusDeExibicao = Anime.Status.EmExibicao
            };

            //act
            _animeServico.Atualizar(anime2);
            Anime anime = _animeRepositorio.ObterPorId(1);

            //assert
            Assert.Equal(anime2.Nome, anime.Nome);
            TabelaDeAnime.Instance.Remove(anime1);
        }
        [Fact]
        public void Ao_atualizar_a_sinopse_deve_retornar_a_sinopse_atualizada()
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
            var anime2 = new Anime
            {
                Id = 1,
                Nome = "Anime1",
                Sinopse = "Sinopse2",
                GenerosIds = new List<int>() { 1, 2 },
                DataLancamento = new DateTime(2024, 5, 15),
                Nota = 7.8m,
                StatusDeExibicao = Anime.Status.EmExibicao
            };

            //act
            _animeServico.Atualizar(anime2);
            Anime anime = _animeRepositorio.ObterPorId(1);

            //assert
            Assert.Equal(anime2.Sinopse, anime.Sinopse);
            TabelaDeAnime.Instance.Remove(anime1);
        }
        [Fact]
        public void Ao_atualizar_o_generoids_deve_retornar_o_generoids_atualizado()
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
            var anime2 = new Anime
            {
                Id = 1,
                Nome = "Anime1",
                Sinopse = "Sinopse1",
                GenerosIds = new List<int>() { 3, 4 },
                DataLancamento = new DateTime(2024, 5, 15),
                Nota = 7.8m,
                StatusDeExibicao = Anime.Status.EmExibicao
            };

            //act
            _animeServico.Atualizar(anime2);
            Anime anime = _animeRepositorio.ObterPorId(1);

            //assert
            Assert.Equivalent(anime2.GenerosIds, anime.GenerosIds);
            TabelaDeAnime.Instance.Remove(anime1);
        }
        [Fact]
        public void Ao_atualizar_a_datalancamento_deve_retornar_a_datalancamento_atualizada()
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
            var anime2 = new Anime
            {
                Id = 1,
                Nome = "Anime1",
                Sinopse = "Sinopse1",
                GenerosIds = new List<int>() { 1, 2 },
                DataLancamento = new DateTime(2023, 3, 11),
                Nota = 7.8m,
                StatusDeExibicao = Anime.Status.EmExibicao
            };

            //act
            _animeServico.Atualizar(anime2);
            Anime anime = _animeRepositorio.ObterPorId(1);

            //assert
            Assert.Equivalent(anime2.DataLancamento, anime.DataLancamento);
            TabelaDeAnime.Instance.Remove(anime1);
        }
        [Fact]
        public void Ao_atualizar_a_nota_deve_retornar_a_nota_atualizada()
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
            var anime2 = new Anime
            {
                Id = 1,
                Nome = "Anime1",
                Sinopse = "Sinopse1",
                GenerosIds = new List<int>() { 1, 2 },
                DataLancamento = new DateTime(2024, 5, 15),
                Nota = 8.3m,
                StatusDeExibicao = Anime.Status.EmExibicao
            };

            //act
            _animeServico.Atualizar(anime2);
            Anime anime = _animeRepositorio.ObterPorId(1);

            //assert
            Assert.Equivalent(anime2.Nota, anime.Nota);
            TabelaDeAnime.Instance.Remove(anime1);
        }
        [Fact]
        public void Ao_atualizar_o_statusdeexibicao_deve_retornar_o_statusdeexibicao_atualizado()
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
            var anime2 = new Anime
            {
                Id = 1,
                Nome = "Anime1",
                Sinopse = "Sinopse1",
                GenerosIds = new List<int>() { 1, 2 },
                DataLancamento = new DateTime(2024, 5, 15),
                Nota = 7.8m,
                StatusDeExibicao = Anime.Status.Concluido
            };

            //act
            _animeServico.Atualizar(anime2);
            Anime anime = _animeRepositorio.ObterPorId(1);

            //assert
            Assert.Equivalent(anime2.StatusDeExibicao, anime.StatusDeExibicao);
            TabelaDeAnime.Instance.Remove(anime1);
        }
        [Fact]
        public void Ao_atualizar_deve_retornar_o_anime_atualizado()
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
            var anime2 = new Anime
            {
                Id = 1,
                Nome = "Anime2",
                Sinopse = "Sinopse2",
                GenerosIds = new List<int>() { 3, 4 },
                DataLancamento = new DateTime(2024, 6, 14),
                Nota = 8.1m,
                StatusDeExibicao = Anime.Status.Concluido
            };

            //act
            _animeServico.Atualizar(anime2);
            Anime anime = _animeRepositorio.ObterPorId(1);

            //assert
            Assert.Equal(anime2.Nome, anime.Nome);
            Assert.Equal(anime2.Sinopse, anime.Sinopse);
            Assert.Equivalent(anime2.GenerosIds, anime.GenerosIds);
            Assert.Equivalent(anime2.DataLancamento, anime.DataLancamento);
            Assert.Equivalent(anime2.Nota, anime.Nota);
            Assert.Equivalent(anime2.StatusDeExibicao, anime.StatusDeExibicao);
            Assert.Equivalent(anime2, anime);
            TabelaDeAnime.Instance.Remove(anime1);
        }
        [Fact]
        public void Ao_tentar_atualizar_deve_retornar_nome_nao_pode_ser_nullo()
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
            var anime2 = new Anime
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
            var mensagemError = Assert.Throws<ValidationException>(() => _animeServico.Atualizar(anime2));
            //assert
            Assert.Equal("Nome não pode ser nullo", mensagemError.Errors.Single().ErrorMessage);
            TabelaDeAnime.Instance.Remove(anime1);
        }
        [Fact]
        public void Ao_tentar_atualizar_deve_retornar_nome_nao_pode_esta_vazio()
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
            var anime2 = new Anime
            {
                Id = 1,
                Nome = "",
                Sinopse = "Sinopse1",
                GenerosIds = new List<int>() { 1, 2 },
                DataLancamento = new DateTime(2024, 5, 15),
                Nota = 7.8m,
                StatusDeExibicao = Anime.Status.EmExibicao
            };
            //act
            var mensagemError = Assert.Throws<ValidationException>(() => _animeServico.Atualizar(anime2));
            //assert
            Assert.Equal("Nome não pode está vazio", mensagemError.Errors.Single().ErrorMessage);
            TabelaDeAnime.Instance.Remove(anime1);
        }
        [Fact]
        public void Ao_tentar_atualizar_deve_retornar_sinopse_nao_pode_ser_nullo()
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
            var anime2 = new Anime
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
            var mensagemError = Assert.Throws<ValidationException>(() => _animeServico.Atualizar(anime2));
            //assert
            Assert.Equal("Sinopse não pode ser nullo", mensagemError.Errors.Single().ErrorMessage);
            TabelaDeAnime.Instance.Remove(anime1);
        }
        [Fact]
        public void Ao_tentar_atualizar_deve_retornar_sinopse_nao_pode_esta_vazio()
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
            var anime2 = new Anime
            {
                Id = 1,
                Nome = "Anime1",
                Sinopse = "",
                GenerosIds = new List<int>() { 1, 2 },
                DataLancamento = new DateTime(2024, 5, 15),
                Nota = 7.8m,
                StatusDeExibicao = Anime.Status.EmExibicao
            };
            //act
            var mensagemError = Assert.Throws<ValidationException>(() => _animeServico.Atualizar(anime2));
            //assert
            Assert.Equal("Sinopse não pode está vazia", mensagemError.Errors.Single().ErrorMessage);
            TabelaDeAnime.Instance.Remove(anime1);
        }
        [Fact]
        public void Ao_tentar_atualizar_deve_retornar_generoids_nao_pode_ser_nullo()
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
            var anime2 = new Anime
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
            var mensagemError = Assert.Throws<ValidationException>(() => _animeServico.Atualizar(anime2));
            //assert
            Assert.Equal("GenerosIds não pode ser nullo", mensagemError.Errors.Single().ErrorMessage);
            TabelaDeAnime.Instance.Remove(anime1);
        }
        [Fact]
        public void Ao_tentar_atualizar_deve_retornar_generoids_nao_pode_esta_vazio()
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
            var anime2 = new Anime
            {
                Id = 1,
                Nome = "Anime1",
                Sinopse = "Sinopse1",
                GenerosIds = new List<int>() { },
                DataLancamento = new DateTime(2024, 5, 15),
                Nota = 7.8m,
                StatusDeExibicao = Anime.Status.EmExibicao
            };
            //act
            var mensagemError = Assert.Throws<ValidationException>(() => _animeServico.Atualizar(anime2));
            //assert
            Assert.Equal("GenerosIds não pode está vazio", mensagemError.Errors.Single().ErrorMessage);
            TabelaDeAnime.Instance.Remove(anime1);
        }
        [Fact]
        public void Ao_tentar_atualizar_deve_retornar_data_lancamento_nao_pode_esta_vazia()
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
            var anime2 = new Anime
            {
                Id = 1,
                Nome = "Anime1",
                Sinopse = "Sinopse1",
                GenerosIds = new List<int>() { 1 , 2},
                DataLancamento = new DateTime(),
                Nota = 7.8m,
                StatusDeExibicao = Anime.Status.EmExibicao
            };
            //act
            var mensagemError = Assert.Throws<ValidationException>(() => _animeServico.Atualizar(anime2));
            //assert
            Assert.Equal("Data Lançamento não pode está vazia", mensagemError.Errors.Single().ErrorMessage);
            TabelaDeAnime.Instance.Remove(anime1);
        }
        [Fact]
        public void Ao_tentar_atualizar_deve_retornar_nota_nao_pode_esta_vazia()
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
            var anime2 = new Anime
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
            var mensagemError = Assert.Throws<ValidationException>(() => _animeServico.Atualizar(anime2));
            //assert
            Assert.Equal("Nota não pode está vazia", mensagemError.Errors.Single().ErrorMessage);
            TabelaDeAnime.Instance.Remove(anime1);
        }
        [Fact]
        public void Ao_tentar_atualizar_deve_retornar_status_de_exibicao_nao_pode_esta_vazio()
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
            var anime2 = new Anime
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
            var mensagemError = Assert.Throws<ValidationException>(() => _animeServico.Atualizar(anime2));
            //assert
            Assert.Equal("Status de Exibição não pode está vazio", mensagemError.Errors.Single().ErrorMessage);
            TabelaDeAnime.Instance.Remove(anime1);
        }
    }
}
