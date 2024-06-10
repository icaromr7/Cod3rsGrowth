using Cod3rsGrowth.dominio;
using Cod3rsGrowth.Servico;
using FluentValidation;

namespace Cod3rsGrowth.forms
{
    public partial class FormAdicionarAnime : Form
    {
        AnimeServico _animeServico;
        GeneroServico _generoServico;
        public FormAdicionarAnime(AnimeServico animeServico, GeneroServico generoServico)
        {
            InitializeComponent();
            _generoServico = generoServico;
            _animeServico = animeServico;
        }

        private void FormAdicionarAnime_Load(object sender, EventArgs e)
        {
            PreencherCheckListBoxGenero();
            PreencherCheckListBoxGenero();
            PreencherComboBoxStatus();
        }
        private void PreencherCheckListBoxGenero()
        {
            var listaAnimes = _generoServico.ObterTodos();
            foreach (var genero in listaAnimes)
            {
                clGeneros.Items.Add(genero.Nome);
            }
            clGeneros.MultiColumn = true;
        }
        private void PreencherComboBoxStatus()
        {
            cbStatusDeExibicao.DataSource = new List<string>() { "EmExibição", "Previsto", "Concluído" };
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                Anime.Status status = new Anime.Status();
                if(cbStatusDeExibicao.SelectedIndex == 0)
                    status = Anime.Status.EmExibicao;               
                else if (cbStatusDeExibicao.SelectedIndex == 1)
                    status = Anime.Status.Previsto;
                else if (cbStatusDeExibicao.SelectedIndex ==2)
                    status = Anime.Status.Concluido;
                _animeServico.Cadastrar(new Anime()
                {
                    Nome = textNome.Text,
                    Sinopse = textSinopse.Text,
                    Nota = Convert.ToDecimal(campoNota.Value),
                    DataLancamento = dtpDataDeLancamento.Value,
                    StatusDeExibicao = status

                });
            }
            catch (ValidationException ex)
            {
                string result = "";
                foreach(var erro  in ex.Errors)
                {
                    result += erro.ErrorMessage+"\n";
                }
                MessageBox.Show(result);
            }
            catch (Exception ex) 
                {
                MessageBox.Show(ex.Message);
                }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
