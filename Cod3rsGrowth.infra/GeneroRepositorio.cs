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
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public Genero ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public List <Genero> ObterTodos()
        {
            List<Genero> generos = new List<Genero>();
            return generos;
        }
    }
}
