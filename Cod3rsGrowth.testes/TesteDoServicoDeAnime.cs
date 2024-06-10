using Cod3rsGrowth.dominio;
using Cod3rsGrowth.Servico;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.testes
{
    public class TesteDoServicoDeAnime : TesteBase
    {
        private AnimeServico _animeServico;
        public TesteDoServicoDeAnime()
        {
            _animeServico = FornecedorDeServicos.GetService<AnimeServico>();
            TabelaDeAnime.Instance.Clear();
        }
        [Fact]
        public void Ao_obter_todos_deve_retornar_uma_lista_com_animes()
        {
            var anime1 = new Anime
            {
                Id = 1,
                Nome = "Anime1",
                Sinopse = "Sinopse1",
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
        public void Ao_obter_por_id_deve_retornar_um_anime_nullo()
        {

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
        public void Ao_tentar_cadastrar_deve_retornar_data_lancamento_nao_pode_esta_vazio()
        {
            var anime1 = new Anime
            {
                Id = 1,
                Nome = "Anime1",
                Sinopse = "Sinopse1",
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
                DataLancamento = new DateTime(2024, 5, 15),
                Nota = 7.8m,
                StatusDeExibicao = Anime.Status.EmExibicao
            };

            //act
            _animeServico.Cadastrar(anime1);

            //assert
            Assert.Contains(TabelaDeAnime.Instance, anime => anime == anime1);
        }
        [Fact]
        public void Ao_tentar_editar_anime_deve_retornar_o_anime_nao_existe()
        {
            var anime1 = new Anime
            {
                Id = 1,
                Nome = "Anime1",
                Sinopse = "Sinopse1",
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
                DataLancamento = new DateTime(2024, 5, 15),
                Nota = 7.8m,
                StatusDeExibicao = Anime.Status.EmExibicao
            };

            //act
            _animeServico.Atualizar(anime2);

            //assert
            Assert.Equal("Anime2", anime1.Nome);
        }
        [Fact]
        public void Ao_atualizar_a_sinopse_deve_retornar_a_sinopse_atualizada()
        {
            var anime1 = new Anime
            {
                Id = 1,
                Nome = "Anime1",
                Sinopse = "Sinopse1",
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
                DataLancamento = new DateTime(2024, 5, 15),
                Nota = 7.8m,
                StatusDeExibicao = Anime.Status.EmExibicao
            };

            //act
            _animeServico.Atualizar(anime2);

            //assert
            Assert.Equal("Sinopse2", anime1.Sinopse);
        }
        [Fact]
        public void Ao_atualizar_a_datalancamento_deve_retornar_a_datalancamento_atualizada()
        {
            var anime1 = new Anime
            {
                Id = 1,
                Nome = "Anime1",
                Sinopse = "Sinopse1",
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
                DataLancamento = new DateTime(2023, 3, 11),
                Nota = 7.8m,
                StatusDeExibicao = Anime.Status.EmExibicao
            };

            //act
            _animeServico.Atualizar(anime2);

            //assert
            Assert.Equivalent(new DateTime(2023, 3, 11), anime1.DataLancamento);
        }
        [Fact]
        public void Ao_atualizar_a_nota_deve_retornar_a_nota_atualizada()
        {
            var anime1 = new Anime
            {
                Id = 1,
                Nome = "Anime1",
                Sinopse = "Sinopse1",
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
                DataLancamento = new DateTime(2024, 5, 15),
                Nota = 8.3m,
                StatusDeExibicao = Anime.Status.EmExibicao
            };

            //act
            _animeServico.Atualizar(anime2);

            //assert
            Assert.Equal(8.3m, anime1.Nota);
        }
        [Fact]
        public void Ao_atualizar_o_statusdeexibicao_deve_retornar_o_statusdeexibicao_atualizado()
        {
            var anime1 = new Anime
            {
                Id = 1,
                Nome = "Anime1",
                Sinopse = "Sinopse1",
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
                DataLancamento = new DateTime(2024, 5, 15),
                Nota = 7.8m,
                StatusDeExibicao = Anime.Status.Concluido
            };

            //act
            _animeServico.Atualizar(anime2);

            //assert
            Assert.Equal(Anime.Status.Concluido, anime1.StatusDeExibicao);
        }
        [Fact]
        public void Ao_atualizar_deve_retornar_o_anime_atualizado()
        {
            var anime1 = new Anime
            {
                Id = 1,
                Nome = "Anime1",
                Sinopse = "Sinopse1",
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
                DataLancamento = new DateTime(2024, 6, 14),
                Nota = 8.1m,
                StatusDeExibicao = Anime.Status.Concluido
            };

            //act
            _animeServico.Atualizar(anime2);

            //assert
            Assert.Equal("Anime2", anime1.Nome);
            Assert.Equal("Sinopse2", anime1.Sinopse);
            Assert.Equivalent(new DateTime(2024, 6, 14), anime1.DataLancamento);
            Assert.Equivalent(8.1m, anime1.Nota);
            Assert.Equivalent(Anime.Status.Concluido, anime1.StatusDeExibicao);
        }
        [Fact]
        public void Ao_tentar_atualizar_deve_retornar_nome_nao_pode_ser_nullo()
        {
            var anime1 = new Anime
            {
                Id = 1,
                Nome = "Anime1",
                Sinopse = "Sinopse1",
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
                DataLancamento = new DateTime(2024, 5, 15),
                Nota = 7.8m,
                StatusDeExibicao = Anime.Status.EmExibicao
            };
            //act
            var mensagemError = Assert.Throws<ValidationException>(() => _animeServico.Atualizar(anime2));
            //assert
            Assert.Equal("Nome não pode ser nullo", mensagemError.Errors.Single().ErrorMessage);
        }
        [Fact]
        public void Ao_tentar_atualizar_deve_retornar_nome_nao_pode_esta_vazio()
        {
            var anime1 = new Anime
            {
                Id = 1,
                Nome = "Anime1",
                Sinopse = "Sinopse1",
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
                DataLancamento = new DateTime(2024, 5, 15),
                Nota = 7.8m,
                StatusDeExibicao = Anime.Status.EmExibicao
            };
            //act
            var mensagemError = Assert.Throws<ValidationException>(() => _animeServico.Atualizar(anime2));
            //assert
            Assert.Equal("Nome não pode está vazio", mensagemError.Errors.Single().ErrorMessage);
        }
        [Fact]
        public void Ao_tentar_atualizar_deve_retornar_sinopse_nao_pode_ser_nullo()
        {
            var anime1 = new Anime
            {
                Id = 1,
                Nome = "Anime1",
                Sinopse = "Sinopse1",
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
                DataLancamento = new DateTime(2024, 5, 15),
                Nota = 7.8m,
                StatusDeExibicao = Anime.Status.EmExibicao
            };
            //act
            var mensagemError = Assert.Throws<ValidationException>(() => _animeServico.Atualizar(anime2));
            //assert
            Assert.Equal("Sinopse não pode ser nullo", mensagemError.Errors.Single().ErrorMessage);
        }
        [Fact]
        public void Ao_tentar_atualizar_deve_retornar_sinopse_nao_pode_esta_vazio()
        {
            var anime1 = new Anime
            {
                Id = 1,
                Nome = "Anime1",
                Sinopse = "Sinopse1",
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
                DataLancamento = new DateTime(2024, 5, 15),
                Nota = 7.8m,
                StatusDeExibicao = Anime.Status.EmExibicao
            };
            //act
            var mensagemError = Assert.Throws<ValidationException>(() => _animeServico.Atualizar(anime2));
            //assert
            Assert.Equal("Sinopse não pode está vazia", mensagemError.Errors.Single().ErrorMessage);
        }
        [Fact]
        public void Ao_tentar_atualizar_deve_retornar_data_lancamento_nao_pode_esta_vazia()
        {
            var anime1 = new Anime
            {
                Id = 1,
                Nome = "Anime1",
                Sinopse = "Sinopse1",
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
                DataLancamento = new DateTime(),
                Nota = 7.8m,
                StatusDeExibicao = Anime.Status.EmExibicao
            };
            //act
            var mensagemError = Assert.Throws<ValidationException>(() => _animeServico.Atualizar(anime2));
            //assert
            Assert.Equal("Data Lançamento não pode está vazia", mensagemError.Errors.Single().ErrorMessage);
        }
        [Fact]
        public void Ao_tentar_atualizar_deve_retornar_nota_nao_pode_esta_vazia()
        {
            var anime1 = new Anime
            {
                Id = 1,
                Nome = "Anime1",
                Sinopse = "Sinopse1",
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
                DataLancamento = new DateTime(2024, 5, 15),
                Nota = new decimal(),
                StatusDeExibicao = Anime.Status.EmExibicao
            };
            //act
            var mensagemError = Assert.Throws<ValidationException>(() => _animeServico.Atualizar(anime2));
            //assert
            Assert.Equal("Nota não pode está vazia", mensagemError.Errors.Single().ErrorMessage);
        }
        [Fact]
        public void Ao_tentar_atualizar_deve_retornar_status_de_exibicao_nao_pode_esta_vazio()
        {
            var anime1 = new Anime
            {
                Id = 1,
                Nome = "Anime1",
                Sinopse = "Sinopse1",
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
                DataLancamento = new DateTime(2024, 5, 15),
                Nota = 7.8m,
                StatusDeExibicao = new Anime.Status() { }
            };
            //act
            var mensagemError = Assert.Throws<ValidationException>(() => _animeServico.Atualizar(anime2));
            //assert
            Assert.Equal("Status de Exibição não pode está vazio", mensagemError.Errors.Single().ErrorMessage);
        }
        [Fact]
        public void Ao_tentar_deletar_deve_retornar_o_anime_nao_existe()
        {
            int id = 1;
            //act
            var mensagemError = Assert.Throws<ValidationException>(() => _animeServico.Deletar(id));
            //assert
            Assert.Equal("O anime não existe", mensagemError.Errors.Single().ErrorMessage);
        }
        [Fact]
        public void Ao_deletar_deve_retornar_que_nao_contem_o_anime()
        {
            var anime1 = new Anime
            {
                Id = 1,
                Nome = "Anime1",
                Sinopse = "Sinopse1",
                DataLancamento = new DateTime(2024, 5, 15),
                Nota = 7.8m,
                StatusDeExibicao = Anime.Status.EmExibicao
            };
            TabelaDeAnime.Instance.Add(anime1);
            int id = 1;
            //act
            _animeServico.Deletar(id);

            //assert
            Assert.DoesNotContain(TabelaDeAnime.Instance, anime => anime == anime1);
        }
    }
}
