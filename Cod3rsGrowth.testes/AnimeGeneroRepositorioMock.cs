﻿using Cod3rsGrowth.dominio;

namespace Cod3rsGrowth.testes
{
    public class AnimeGeneroRepositorioMock : IAnimeGeneroRepositorio
    {
        public void Atualizar(AnimeGenero animeGenero)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(AnimeGenero animeGenero)
        {
            TabelaDeAnimeGenero.Instance.Add(animeGenero);
        }

        public void Deletar(int idAnime)
        {
            var animeGeneroDeletado = TabelaDeAnimeGenero.Instance.Find(delegate (AnimeGenero animeGenero1) { return animeGenero1.IdAnime == idAnime; });
            TabelaDeAnimeGenero.Instance.Remove(animeGeneroDeletado);        
        }

        public AnimeGenero ObterPorId(int idAnime)
        {
            var animeGenero = TabelaDeAnimeGenero.Instance.Find(delegate(AnimeGenero animeGenero1) {return animeGenero1.IdAnime==idAnime; });
            return animeGenero;
        }

        public List<AnimeGenero> ObterTodos(int? idAnime = 0)
        {
            var animeGeneros = TabelaDeAnimeGenero.Instance.FindAll(delegate(AnimeGenero animeGenero) {return animeGenero.IdAnime==idAnime; });
            return animeGeneros;
        }

        public List<AnimeGenero> ObterTodos()
        {
            var animesGeneros = TabelaDeAnimeGenero.Instance;
            return animesGeneros;
        }
    }
}