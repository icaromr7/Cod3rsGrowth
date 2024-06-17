using Cod3rsGrowth.dominio;
using Cod3rsGrowth.Servico;
using FluentValidation;

namespace Cod3rsGrowth.forms
{
    public partial class FormLista : Form
    {
        private List<Anime> listaDeAnimes;
        private Anime anime = null;
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
                if (formAdicionarAnime.ShowDialog() == DialogResult.OK)
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
            try
            {
                if (anime == null)
                {
                    MessageBox.Show("Nenhum anime selecionado!!");
                }
                else
                {
                    var result = MessageBox.Show(this, "Você tem certeza que deseja excluir o anime?", "Confirmação", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        _animeGeneroServico.Deletar(anime.Id);
                        _animeServico.Deletar(anime.Id);
                        load();
                    }                   
                }
            }
            catch (ValidationException ex)
            {
                string result = "";
                foreach (var erro in ex.Errors)
                {
                    result += erro.ErrorMessage + "\n";
                }
                MessageBox.Show(result);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao deletar o anime!!");
            }


        }
        private void dataAnimeFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dataAnime.Columns["notaColumn"].DefaultCellStyle.Format = "N1";
        }
        private void AoClicarNoAnime(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    anime = listaDeAnimes[e.RowIndex];
                }
            }
            catch (Exception ex)
            {
            }

        }      
    }
}
