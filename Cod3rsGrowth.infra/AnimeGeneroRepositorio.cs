using Cod3rsGrowth.dominio;
using LinqToDB;
using LinqToDB.Data;
using System.Configuration;

namespace Cod3rsGrowth.infra
{
    public class AnimeGeneroRepositorio : IAnimeGeneroRepositorio
    {
        private readonly DataConnection dataConnection;
        public AnimeGeneroRepositorio()
        {
            var appSettings = ConfigurationManager.AppSettings;
            string result = appSettings[ConstantesDoRepositorio.CONNECTION_STRING];
            dataConnection = new DataConnection(
                new DataOptions()
                    .UseSqlServer(result));
        }
        public void Atualizar(AnimeGenero animeGenero)
        {
            dataConnection.Update(animeGenero);
        }

        public void Cadastrar(AnimeGenero animeGenero)
        {
            dataConnection.Insert(animeGenero);
        }       
        public void Deletar(int idAnime)
        {
            dataConnection.GetTable<AnimeGenero>()
                .Where(animeGenero=> animeGenero.IdAnime == idAnime)
                .Delete();
        }

        public AnimeGenero ObterPorId(int idAnime)
        {
            var animeGeneros = dataConnection.GetTable<AnimeGenero>()
                .Where(AnimeGenero => AnimeGenero.IdAnime == idAnime);
            return animeGeneros.ToList().First();
        }

        public List<AnimeGenero> ObterTodos(int idAnime = 0)
        {
            var animeGeneros = dataConnection.GetTable<AnimeGenero>()
                .Where(AnimeGenero => AnimeGenero.IdAnime == idAnime); ;
            return animeGeneros.ToList();
        }

        public List<AnimeGenero> ObterTodos()
        {
            var animeGeneros = dataConnection.GetTable<AnimeGenero>();
            return animeGeneros.ToList();
        }
    }
}
