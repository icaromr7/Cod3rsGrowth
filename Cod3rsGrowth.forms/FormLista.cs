using Cod3rsGrowth.dominio;
using Cod3rsGrowth.Servico;
using FluentValidation;

namespace Cod3rsGrowth.forms
{
    public partial class FormLista : Form
    {
        private List<Anime> listaDeAnimes;
        private List<Genero> listaDeGeneros;
        private Anime anime = null;
        private Genero genero = null;
        private AnimeServico _animeServico;
        private GeneroServico _generoServico;
        private AnimeGeneroServico _animeGeneroServico;
        private string _animeNome = null;
        private Anime.Status? _status = null;
        private DateTime? _date = null;
        const int QUANTIDADE_NA_LISTA = 0;
        const int INDEX_TODOS = 0;
        const int INDEX_EM_EXIBICAO = 1;
        const int INDEX_PREVISTO = 2;
        const int INDEX_CONCLUIDO = 3;
        const int QUANTIDADE_MINIMA_DE_GENEROS_SELECIONADOS = 1;
        const int INDICA_PRIMEIRA_POSICAO = 0;
        const string NECESSARIO_UM_GENERO_CADASTRADO = "É necessário ter ao menos um gênero cadastrado";
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
        private void AoFiltrarPorNomeAnime(object sender, EventArgs e)
        {

            _animeNome = txtNomeAnime.Text.Trim();
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
        private void AoClicarEmLimparFiltroAnime(object sender, EventArgs e)
        {
            txtNomeAnime.Text = "";
            cbStatusDeExibicao.SelectedIndex = INDEX_TODOS;
            dtpDataLancamento.Value = DateTime.Now;
            _animeNome = null;
            _date = null;
            _status = null;
            dataAnime.DataSource = _animeServico.ObterTodos(_status, _animeNome, _date);
        }
        private void AoClicarEmAdicionarAnime(object sender, EventArgs e)
        {
            if (_generoServico.ObterTodos().Count == QUANTIDADE_NA_LISTA)
            {
                MessageBox.Show(NECESSARIO_UM_GENERO_CADASTRADO);
            }
            else
            {
                using (FormAdicionarAnime formAdicionarAnime = new FormAdicionarAnime(_animeServico, _generoServico, _animeGeneroServico) { })
                {
                    if (formAdicionarAnime.ShowDialog() == DialogResult.OK)
                    {
                        PreencherDataAnime();
                    }
                }
            }
        }
        private void AoClicarEmEditarAnime(object sender, EventArgs e)
        {
            try
            {
                if (_generoServico.ObterTodos().Count == QUANTIDADE_NA_LISTA)
                {
                    MessageBox.Show(NECESSARIO_UM_GENERO_CADASTRADO);
                }
                else if (anime == null)
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
        private void AoClicarEmRemoverAnime(object sender, EventArgs e)
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
                        var animeGenero = new AnimeGenero()
                        {
                            IdAnime = anime.Id,
                            IdGenero = 0
                        };
                        _animeGeneroServico.Deletar(animeGenero);
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
            //dataAnime.Columns["notaColumn"].DefaultCellStyle.Format = "N1";
            notaColumnAnime.DefaultCellStyle.Format = "N1";
        }
        private void PreencherComboBoxStatus()
        {
            cbStatusDeExibicao.DataSource = new List<string>() { "Todos", "EmExibição", "Previsto", "Concluído" };
        }
        private void AoClicarEmUmItemNoDataGrid(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (e.RowIndex >= INDICA_PRIMEIRA_POSICAO)
                    {
                        if (tabLista.SelectedTab == pagGenero)
                        {
                            DataGridViewRow row = dataGenero.Rows[e.RowIndex];
                            int idGenero = (int)row.Cells[idColumnGenero.Index].Value;
                            genero = _generoServico.ObterPorId(idGenero);
                        }
                        else if (tabLista.SelectedTab == pagAnime)
                        {
                            DataGridViewRow row = dataAnime.Rows[e.RowIndex];
                            int idAnime = (int)row.Cells[idColumnAnime.Index].Value;
                            anime = _animeServico.ObterPorId(idAnime);
                        }

                    }
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

        private void AoClicarEmRemoverGenero(object sender, MouseEventArgs e)
        {
            try
            {
                if (genero == null)
                {
                    MessageBox.Show("Nenhum Gênero selecionado!!");
                }
                else
                {
                    var result = MessageBox.Show(this, "Você tem certeza que deseja excluir o Gênero?", "Confirmação", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        var animeGenero = new AnimeGenero()
                        {
                            IdAnime = 0,
                            IdGenero = genero.Id
                        };
                        _animeGeneroServico.Deletar(animeGenero);
                        _generoServico.Deletar(genero.Id);
                        PreencherDataGenero();
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
                MessageBox.Show("Erro ao deletar o gênero!!");
            }
        }

        private void AoClicarEmEditarGenero(object sender, MouseEventArgs e)
        {
            try
            {
                if (genero == null)
                {
                    MessageBox.Show("Nenhum gênero selecionado!!");
                }
                else
                {
                    using (FormEditarGenero formEditarGenero = new FormEditarGenero(genero.Id, _generoServico) { })
                    {
                        if (formEditarGenero.ShowDialog() == DialogResult.OK)
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

        private void AoTrocarDePagina(object sender, EventArgs e)
        {
            if (tabLista.SelectedTab == pagAnime)
                PreencherDataAnime();
            else if (tabLista.SelectedTab == pagGenero) PreencherDataGenero();

        }
        private void PreencherDataGenero()
        {
            listaDeGeneros = _generoServico.ObterTodos();
            dataGenero.DataSource = listaDeGeneros;
        }

        private void AoClicarEmAdicionarGenero(object sender, MouseEventArgs e)
        {
            using (FormAdicionarGenero formAdicionarGenero = new FormAdicionarGenero( _generoServico) { })
            {
                if (formAdicionarGenero.ShowDialog() == DialogResult.OK)
                {
                    PreencherDataGenero();
                }
            }
        }  
    }
}
