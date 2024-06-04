using Cod3rsGrowth.dominio;
using Cod3rsGrowth.infra;
using LinqToDB;
using LinqToDB.Data;
using System.Configuration;

namespace Cod3rsGrowth.testes
{
    public class GeneroRepositorio : IGeneroRepositorio
    {
        private readonly DataConnection dataConnection;
        public GeneroRepositorio() {
            var appSettings = ConfigurationManager.AppSettings;
            string result = appSettings[ConstantesDoRepositorio.CONNECTION_STRING];
            dataConnection = new DataConnection(
                new DataOptions()
                    .UseSqlServer(result));
        }

        public void Atualizar(Genero genero)
        {
            dataConnection.Update(genero);
        }

        public void Cadastrar(Genero genero)
        {
            dataConnection.Insert(genero);
        }

        public void Deletar(int id)
        {
            dataConnection.GetTable<Genero>()
                .Where(genero => genero.Id == id)
                .Delete();
        }

        public Genero ObterPorId(int id)
        {
            var genero = dataConnection.GetTable<Genero>()
                .FirstOrDefault(genero => genero.Id == id);
            return genero;
        }

        public List <Genero> ObterTodos()
        {
            var generos = dataConnection.GetTable<Genero>();
            generos = (ITable<Genero>)generos.OrderBy(g => g.Nome);
            return generos.ToList();
        }
    }
}
