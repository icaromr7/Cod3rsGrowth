using Cod3rsGrowth.dominio;
using LinqToDB.Data;
using LinqToDB;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cod3rsGrowth.testes;

namespace Cod3rsGrowth.infra
{
    public class GeneroRepositorio : IGeneroRepositorio
    {
        private readonly DataConnection dataConnection;
        public GeneroRepositorio()
        {
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

        public List<Genero> ObterTodos()
        {
            var generos = dataConnection.GetTable<Genero>();
            generos = (ITable<Genero>)generos.OrderBy(g => g.Nome);
            return generos.ToList();
        }
    }
}
