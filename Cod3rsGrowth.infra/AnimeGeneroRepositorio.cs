using Cod3rsGrowth.dominio;
using LinqToDB;
using LinqToDB.Data;
using System.Configuration;
using System.Linq;
using static LinqToDB.Reflection.Methods.LinqToDB;
using static LinqToDB.Sql;

namespace Cod3rsGrowth.infra
{
    public class AnimeGeneroRepositorio : IAnimeGeneroRepositorio
    {
        private readonly DataConnection dataConnection;
        const int ID_DEFAULT = 0;
        const int POSICAO_INICIAL_DA_LISTA = 0;
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
        public void Deletar(List<AnimeGenero> animeGeneros)
        {         
            string sqlQuery = "DELETE FROM dbo.AnimeGenero WHERE ";
            for (int i = POSICAO_INICIAL_DA_LISTA; i < animeGeneros.Count; i++)
            {
                sqlQuery += "IdAnime =" + animeGeneros[i].IdAnime
                    + "AND IdGenero = " + animeGeneros[i].IdGenero;
                if (i < animeGeneros.Count - 1)
                {
                    sqlQuery += " or ";
                }
            }
            dataConnection.Execute(sqlQuery);
        }

        public void DeletarPorAnime(int idAnime)
        {
            dataConnection.GetTable<AnimeGenero>()
                .Where(animeGenero => animeGenero.IdAnime == idAnime)
                .Delete();
        }

        public void DeletarPorGenero(int idGenero)
        {
            dataConnection.GetTable<AnimeGenero>()
                .Where(animeGenero => animeGenero.IdGenero == idGenero)
                .Delete();
        }

        public AnimeGenero ObterPorId(int idAnime)
        {
            var animeGeneros = dataConnection.GetTable<AnimeGenero>()
                .Where(AnimeGenero => AnimeGenero.IdAnime == idAnime);         
            return animeGeneros.ToList().First();
        }

        public List<AnimeGenero> ObterTodos(int? idAnime = ID_DEFAULT)
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
