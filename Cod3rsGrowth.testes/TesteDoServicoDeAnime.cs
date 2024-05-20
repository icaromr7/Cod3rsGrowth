using Cod3rsGrowth.dominio;
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
        private IAnimeServico _animeServicoTeste;
        public TesteDoServicoDeAnime()
        {
            _animeServicoTeste = FornecedorDeServicos.GetService<IAnimeServico>();
        }

        [Fact]
        public void Ao_obter_todos_deve_retornar_uma_lista_com_animes()
        {
            List<Anime> tabelaDeAnimesEsperada = new List<Anime>();
            tabelaDeAnimesEsperada.Add(new Anime(1, "Anime1", "Sinopse1", new List<int>() { 1, 2 }, new DateTime(2024, 5, 15), 7.8m, Anime.Status.EmExibicao));
            
            //act
            List<Anime> tabelaDeAnimesAtual = _animeServicoTeste.ObterTodos();
            var tabelaAtual = tabelaDeAnimesAtual.Where(i => !tabelaDeAnimesEsperada.Contains(i)).ToList();
            var tabelaEsperada = tabelaDeAnimesEsperada.Where(i => !tabelaDeAnimesAtual.Contains(i)).ToList();
            const int quantidadeEsperada = 1;
            int quantidadeAtual = tabelaAtual.Count();

            //assert
            Assert.Equal(quantidadeEsperada, quantidadeAtual);
        }
    }
}
