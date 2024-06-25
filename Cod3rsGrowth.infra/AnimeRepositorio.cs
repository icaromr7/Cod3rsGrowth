using Cod3rsGrowth.dominio;
using LinqToDB;
using LinqToDB.Data;
using System.Configuration;
using static Cod3rsGrowth.dominio.Anime;

namespace Cod3rsGrowth.infra
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
            var anime = dataConnection.GetTable<Anime>()

                .FirstOrDefault(anime => anime.Id == id);
            return anime;
        }

        public List<Anime> ObterTodos(FiltroAnime? filtro)
        {
            var animes = dataConnection.GetTable<Anime>();
            var listaAnimes = animes.AsQueryable();
            if(filtro != null)
            {
                if (filtro.StatusExibicao.HasValue)
                {
                    listaAnimes = listaAnimes.Where(anime => anime.StatusDeExibicao == filtro.StatusExibicao.Value);
                }
                if (filtro.DataLancamento.HasValue)
                {
                    listaAnimes = listaAnimes.Where(anime => anime.DataLancamento == filtro.DataLancamento);
                }
                if (filtro.Nome != null)
                {
                    listaAnimes = listaAnimes.Where(anime => anime.Nome.Contains(filtro.Nome));
                }
            }
            
            return listaAnimes.ToList();
        }
    }
}
