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
        private string _animeNome = null;
        private Anime.Status? _status = null;
        private DateTime? _date = null;
        const int INDEX_TODOS = 0;
        const int INDEX_EM_EXIBICAO = 1;
        const int INDEX_PREVISTO = 2;
        const int INDEX_CONCLUIDO = 3;
        const int QUANTIDADE_MINIMA_DE_GENEROS_SELECIONADOS = 1;
        public FormLista(AnimeServico animeServico, GeneroServico generoServico, AnimeGeneroServico animeGeneroServico)
        {
            _animeServico = animeServico;
            InitializeComponent();
            _generoServico = generoServico;
            _animeGeneroServico = animeGeneroServico;
        }
        private void PreencherDataAnime()
        {
            listaDeAnimes = new List<Anime>();
            listaDeAnimes = _animeServico.ObterTodos();
            dataAnime.DataSource = listaDeAnimes;
        }
        private void dataAnime_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void AoFiltrarPorNome(object sender, EventArgs e)
        {

            _animeNome = txtNome.Text.Trim();
            dataAnime.DataSource = _animeServico.ObterTodos(_status, _animeNome, _date);
        }
        private void AoSelecionarUmStatusDeExibicao(object sender, EventArgs e)
        {
            if (cbStatusDeExibicao.SelectedIndex == INDEX_EM_EXIBICAO) _status = Anime.Status.EmExibicao;
            else if (cbStatusDeExibicao.SelectedIndex == INDEX_PREVISTO) _status = Anime.Status.Previsto;
            else if (cbStatusDeExibicao.SelectedIndex == INDEX_CONCLUIDO) _status = Anime.Status.Concluido;
            else _status = null;
            dataAnime.DataSource = _animeServico.ObterTodos(_status, _animeNome, _date);
        }
        private void AoSelecionarUmaData(object sender, EventArgs e)
        {
            _date = dtpDataLancamento.Value;
            dataAnime.DataSource = _animeServico.ObterTodos(_status, _animeNome, _date);
        }
        private void AoClicarEmLimparFiltro(object sender, EventArgs e)
        {
            txtNome.Text = "";
            cbStatusDeExibicao.SelectedIndex = INDEX_TODOS;
            dtpDataLancamento.Value = DateTime.Now;
            _animeNome = null;
            _date = null;
            _status = null;
            dataAnime.DataSource = _animeServico.ObterTodos(_status, _animeNome, _date);
        }
        private void AoClicarEmAdicionar(object sender, EventArgs e)
        {
            using (FormAdicionarAnime formAdicionarAnime = new FormAdicionarAnime(_animeServico, _generoServico, _animeGeneroServico) { })
            {
                if (formAdicionarAnime.ShowDialog() == DialogResult.OK)
                {
                    PreencherDataAnime();
                }
            }
        }
        private void AoClicarEmEditar(object sender, EventArgs e)
        {
            try
            {
                if (anime == null)
                {
                    MessageBox.Show("Nenhum anime selecionado!!");
                }
                else
                {
                    using (FormEditarAnime formEditarAnime = new FormEditarAnime(_animeServico, _generoServico, _animeGeneroServico, anime) { })
                    {
                        if (formEditarAnime.ShowDialog() == DialogResult.OK)
                        {
                            PreencherDataAnime();
                        }
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
                MessageBox.Show("Erro ao editar o anime!!");
            }
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
                        PreencherDataAnime();
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
        private void PreencherComboBoxStatus()
        {
            cbStatusDeExibicao.DataSource = new List<string>() { "Todos", "EmExibição", "Previsto", "Concluído" };
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
        private void AoClicarEmVerDetalhes(object sender, EventArgs e)
        {
            if (anime == null)
            {
                MessageBox.Show("Nenhum anime selecionado!!");
            }
            else
            {
                using (FormAnimeDetalhes formAnimeDetalhes = new FormAnimeDetalhes(anime, _generoServico, _animeGeneroServico) { })
                {
                    formAnimeDetalhes.ShowDialog();
                }
            }
        }

        private void FormLista_Load(object sender, EventArgs e)
        {
            PreencherDataAnime();          
            PreencherComboBoxStatus();
        }
    }
}
