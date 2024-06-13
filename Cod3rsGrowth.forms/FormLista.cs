using Cod3rsGrowth.dominio;
using Cod3rsGrowth.Servico;

namespace Cod3rsGrowth.forms
{
    public partial class FormLista : Form
    {
        private List<Anime> listaDeAnimes;
        private AnimeServico _animeServico;
        private GeneroServico _generoServico;
        private AnimeGeneroServico _animeGeneroServico;
        public FormLista(AnimeServico animeServico, GeneroServico generoServico, AnimeGeneroServico animeGeneroServico)
        {
            _animeServico = animeServico;
            InitializeComponent();
            load();
            _generoServico = generoServico;
            _animeGeneroServico = animeGeneroServico;
        }

        private void load()
        {
            listaDeAnimes = new List<Anime>();
            listaDeAnimes = _animeServico.ObterTodos();
            dataAnime.DataSource = listaDeAnimes;
        }
        private void dataAnime_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AoClicarEmAdicionar(object sender, EventArgs e)
        {
            using (FormAdicionarAnime formAdicionarAnime = new FormAdicionarAnime(_animeServico, _generoServico, _animeGeneroServico) { })
            {
                if(formAdicionarAnime.ShowDialog() == DialogResult.OK)
                {
                    load();
                }
            } 

        }

        private void AoClicarEmEditar(object sender, EventArgs e)
        {

        }

        private void AoClicarEmRemover(object sender, EventArgs e)
        {

        }
        private void dataAnimeFormatting(object sender, DataGridViewCellFormattingEventArgs e) {
            dataAnime.Columns["notaColumn"].DefaultCellStyle.Format = "N1";
        }
    }
}
