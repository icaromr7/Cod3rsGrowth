using Cod3rsGrowth.dominio;
using Cod3rsGrowth.Servico;

namespace Cod3rsGrowth.web.Servico
{
    public class MetodosAuxiliares
    {
        const int POSICAO_INICIAL_NA_LISTA = 0;
        public MetodosAuxiliares() {
        }
        public static List<int> ObterOsGenerosDiferentesEntreAsListas(List<int> lista1, List<int> lista2)
        {
            var listaDiferenca = new List<int>();
            foreach (var item in lista2)
            {
                if (lista1.Contains(item) == false)
                {
                    listaDiferenca.Add(item);
                }
            }
            return listaDiferenca;
        }
        public static void ExcluirRelacaoAnimeGenero(Anime anime, List<int> generosAntigos, AnimeGeneroServico animeGeneroServico)
        {
            var generosRetirados = ObterOsGenerosDiferentesEntreAsListas(anime.IdGeneros, generosAntigos);
            var listaAnimeGenerosRetirados = new List<AnimeGenero>();
            for (int i = POSICAO_INICIAL_NA_LISTA; i < generosRetirados.Count; i++)
            {
                var animeGenero = new AnimeGenero()
                {
                    IdAnime = anime.Id,
                    IdGenero = generosRetirados[i],
                };
                listaAnimeGenerosRetirados.Add(animeGenero);
            }
            animeGeneroServico.Deletar(listaAnimeGenerosRetirados);
        }
        public static void AdicionarRelacaoAnimeGenero(Anime anime, List<int> generosAntigos, AnimeGeneroServico animeGeneroServico)
        {
            var listaGenerosAdicionados = ObterOsGenerosDiferentesEntreAsListas(generosAntigos, anime.IdGeneros);
            foreach (var adicionado in listaGenerosAdicionados)
            {
                var animeGenero = new AnimeGenero()
                {
                    IdAnime = anime.Id,
                    IdGenero = adicionado,
                };
                animeGeneroServico.Cadastrar(animeGenero);
            }
        }
    }
}
