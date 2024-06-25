using Cod3rsGrowth.dominio;
using Cod3rsGrowth.Servico;

namespace Cod3rsGrowth.forms
{
    public partial class FormAnimeDetalhes : Form
    {
        GeneroServico _generoServico;
        AnimeGeneroServico _animeGeneroServico;
        const int POSICAO_INICIAL_NA_LISTA = 0;
        public FormAnimeDetalhes(int idAnime, GeneroServico generoServico, AnimeGeneroServico animeGeneroServico, AnimeServico animeServico)
        {
            InitializeComponent();
            _generoServico = generoServico;
            _animeGeneroServico = animeGeneroServico;
            var anime = animeServico.ObterPorId(idAnime);
            textID.Text = anime.Id.ToString();
            textNome.Text = anime.Nome.ToString();
            textSinopse.Text = anime.Sinopse.ToString();
            campoNota.Text = anime.Nota.ToString("N1");
            PreencherListGeneros(anime.Id);
            dtpDataDeLancamento.Text = anime.DataLancamento.ToString("d");
            textStatus.Text = anime.StatusDeExibicao.ToString();
        }
        private void PreencherListGeneros(int idAnime)
        {
            List<AnimeGenero> listAnimeGenero = _animeGeneroServico.ObterTodos(idAnime);
            listGeneros.Text = "";
            for (int i = POSICAO_INICIAL_NA_LISTA; i < listAnimeGenero.Count; i++)
            {
                var genero = _generoServico.ObterPorId(listAnimeGenero[i].IdGenero);
                listGeneros.Text += genero.Nome + "\n";
            }
        }    
    }
}
