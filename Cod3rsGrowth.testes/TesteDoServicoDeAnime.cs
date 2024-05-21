using Cod3rsGrowth.dominio;
using Cod3rsGrowth.Servico;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cod3rsGrowth.testes
{
     public class TesteDoServicoDeAnime : TesteBase
    {
        private IAnimeServico _animeServico;
        public TesteDoServicoDeAnime()
        {
            _animeServico = FornecedorDeServicos.GetService<IAnimeServico>();
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
            //act
            TabelaDeAnime.Instance.Add(anime1);
            List<Anime> animes = _animeServico.ObterTodos();
            const int quantidadeEsperada = 1;
            int quantidadeAtual = animes.Count();

            //assert
            Assert.Equal(quantidadeEsperada, quantidadeAtual);
        }
    }
}
