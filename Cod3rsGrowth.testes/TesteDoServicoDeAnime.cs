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
        private IAnimeServico _animeServico;
        public TesteDoServicoDeAnime()
        {
            _animeServico = FornecedorDeServicos.GetService<IAnimeServico>();
        }
        [Fact]
        public void Ao_obter_todos_deve_retornar_uma_lista_com_animes()
        {
            //act
            List<Anime> animes = _animeServico.ObterTodos();
            const int quantidadeEsperada = 0;
            int quantidadeAtual = animes.Count();

            //assert
            Assert.Equal(quantidadeEsperada, quantidadeAtual);
        }
    }
}
