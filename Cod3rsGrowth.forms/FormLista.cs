using Cod3rsGrowth.dominio;
using Cod3rsGrowth.Servico;

namespace Cod3rsGrowth.forms
{
    public partial class FormLista : Form
    {
        private List<Anime> listaDeAnimes;
        private AnimeServico _animeServico;
        public FormLista(AnimeServico animeServico)
        {
            _animeServico = animeServico;
            InitializeComponent();
            load();
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
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {

        }
    }
}
