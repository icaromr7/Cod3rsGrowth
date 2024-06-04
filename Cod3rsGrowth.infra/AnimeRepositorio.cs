using Cod3rsGrowth.dominio;
using Cod3rsGrowth.infra;
using LinqToDB;
using LinqToDB.Data;
using System.Configuration;
using static Cod3rsGrowth.dominio.Anime;
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
            dataConnection.Update(anime);
        }

        public void Cadastrar(Anime anime)
        {
            dataConnection.Insert(anime);
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

        public List<Anime> ObterTodos(Status? statusDeExibicao = null)
        {
            var animes = dataConnection.GetTable<Anime>();

            if (statusDeExibicao.HasValue)
            {
                animes = (ITable<Anime>) animes.Where(anime => anime.StatusDeExibicao == statusDeExibicao.Value);
            }

            return animes.ToList();
        }
    }
}
