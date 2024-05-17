using Cod3rsGrowth.dominio;
using Cod3rsGrowth.testes;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cod3rsGrowth.dominio.Servicos
{
    public class AnimeServicos : IAnimeServico
    {
        private ServiceProvider serviceProvider;
        private IAnimeRepositorio animeRepositorio;

        public AnimeServicos()
        {
            var service = new ServiceCollection();
            serviceProvider = ModuloDeInjecaoTeste.BindServices(service).BuildServiceProvider();
        }
        public string Atualizar(Anime anime)
        {
            throw new NotImplementedException();
        }

        public string Cadastrar(Anime anime)
        {
            throw new NotImplementedException();
        }

        public string Deletar(Anime anime)
        {
            throw new NotImplementedException();
        }

        public Anime ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Anime> ObterTodos()
        {
            List<Anime> animes = new List<Anime>();
            return animes;
        }
    }
}
