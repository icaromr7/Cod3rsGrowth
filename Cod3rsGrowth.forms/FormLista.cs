using Cod3rsGrowth.dominio;
using Cod3rsGrowth.Servico;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.forms
{
    public partial class FormLista : Form
    {
        private List<Anime> listaDeAnimes;
        private AnimeServico _animeServico;
        private GeneroServico _generoServico;
        public FormLista(AnimeServico animeServico, GeneroServico generoServico)
        {
            _animeServico = animeServico;
            InitializeComponent();
            load();
            _generoServico = generoServico;
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

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            FormAdicionarAnime formAdicionarAnime = new FormAdicionarAnime(_animeServico, _generoServico);
            formAdicionarAnime.Show();

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }

        private void btnRemover_Click(object sender, EventArgs e)
        {

        }
    }
}
