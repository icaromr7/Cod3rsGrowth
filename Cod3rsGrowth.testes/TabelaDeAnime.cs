using Cod3rsGrowth.dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cod3rsGrowth.testes
{
    public sealed class TabelaDeAnime
    {
        private static List<Anime> TabelaDeAnimes = null;

        private TabelaDeAnime() { }
        public static List<Anime> GetTabelaAnime()
        {
            if (TabelaDeAnimes == null)
            {
                TabelaDeAnimes = new List<Anime>();
                TabelaDeAnimes.Add(new Anime(1, "Anime1", "Sinopse1", new List<int>() { 1, 2 }, new DateTime(2024, 5, 15), 7.8m, Anime.Status.EmExibicao));
            }
            return TabelaDeAnimes;
        }

        //private static List<Anime> Animes { get { new Anime(1, "Anime1", "Sinopse1", new List<int>() { 1,2 }, new DateTime(2024, 5, 15), 7.8m, Anime.Status.EmExibicao); return Animes; } }
       
    }
}
