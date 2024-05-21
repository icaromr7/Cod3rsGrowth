using Cod3rsGrowth.dominio;
using Cod3rsGrowth.Servico;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.testes
{
    public class TesteDoServicoDeGenero : TesteBase {
        private IGeneroServico _generoServico;
        public TesteDoServicoDeGenero()
        {
            _generoServico = FornecedorDeServicos.GetService<IGeneroServico>(); ;
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
            Genero genero = _generoServico.ObterPorId(1);

            //assert
            Assert.Null(genero);
        }
    }  
}