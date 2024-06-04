using Cod3rsGrowth.dominio;
using Cod3rsGrowth.infra;
using LinqToDB;
using LinqToDB.Data;
using System.Configuration;

namespace Cod3rsGrowth.testes
{
    public class AnimeRepositorio : IAnimeRepositorio
    {
        private readonly DataConnection dataConnection;
        public AnimeRepositorio()
        {
            var appSettings = ConfigurationManager.AppSettings;
            string result = appSettings[ConstantesDoRepositorio.CONNECTION_STRING];
            dataConnection = new DataConnection(
                new DataOptions()
                    .UseSqlServer(result));
        }

        public void Atualizar(Anime anime)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Anime anime)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            dataConnection.GetTable<Anime>()
                .Where(anime => anime.Id == id)
                .Delete();
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
