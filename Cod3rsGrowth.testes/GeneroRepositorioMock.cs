using Cod3rsGrowth.dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Cod3rsGrowth.testes
{
    public class GeneroRepositorioMock : IGeneroRepositorio
    {
        public GeneroRepositorioMock() {
        }
        public void Atualizar(Genero genero)
        {
            var generoModificado = TabelaDeGenero.Instance.Find(delegate (Genero genero1) { return genero1.Id == genero.Id; });
            generoModificado.Nome = genero.Nome;
        }
        public void Cadastrar(Genero genero)
        {
            TabelaDeGenero.Instance.Add(genero);
        }
        public string Deletar(Genero genero)
        {
            throw new NotImplementedException();
        }
        public Genero ObterPorId(int id)
        {
            var genero = TabelaDeGenero.Instance.Find(delegate (Genero genero1) { return genero1.Id == id; });
            return genero;
        }
        public List<Genero> ObterTodos()
        {
            var generos = TabelaDeGenero.Instance;
            return generos;
        }
    }
}
