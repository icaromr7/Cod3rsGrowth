using Cod3rsGrowth.dominio;
using Cod3rsGrowth.infra;
using Cod3rsGrowth.Servico;
using FluentValidation;
using LinqToDB.Data;
using LinqToDB;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;
using static LinqToDB.DataProvider.SapHana.SapHanaProviderAdapter;

namespace Cod3rsGrowth.forms
{
    public partial class FormAdicionarAnime : Form
    {
        AnimeServico _animeServico;
        GeneroServico _generoServico;
        AnimeGeneroServico _animeGeneroServico;
        public FormAdicionarAnime(AnimeServico animeServico, GeneroServico generoServico, AnimeGeneroServico animeGeneroServico)
        {
            InitializeComponent();
            _generoServico = generoServico;
            _animeServico = animeServico;
            _animeGeneroServico = animeGeneroServico;
        }

        private void FormAdicionarAnime_Load(object sender, EventArgs e)
        {
            PreencherCheckListBoxGenero();
            PreencherComboBoxStatus();
        }
        private void PreencherCheckListBoxGenero()
        {
            var listaGeneros = _generoServico.ObterTodos();
            foreach (var genero in listaGeneros)
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
                cadastrarAnime();
                cadastrarAnimeGenero();
                DialogResult = DialogResult.OK;
                this.Close();
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
                _animeServico.Deletar(idDoUltimoAnimeCadastrado());
                MessageBox.Show(ex.Message);
                }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void cadastrarAnime()
        {
            Anime.Status status = new Anime.Status();
            if (cbStatusDeExibicao.SelectedIndex == 0)
                status = Anime.Status.EmExibicao;
            else if (cbStatusDeExibicao.SelectedIndex == 1)
                status = Anime.Status.Previsto;
            else if (cbStatusDeExibicao.SelectedIndex == 2)
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
        private void cadastrarAnimeGenero()
        {
                int idAnime = idDoUltimoAnimeCadastrado();
                var listaGeneros = _generoServico.ObterTodos();
                if (clGeneros.CheckedItems.Count > 0)
                {
                var listaGenerosChecked = clGeneros.CheckedItems;
                foreach (var item in clGeneros.CheckedItems)
                {
                    for (int i = 0; i < listaGeneros.Count; i++)
                    {
                        var text = item;
                        if (listaGeneros[i].Nome.Equals(item))
                        {
                            var animeGenero = new AnimeGenero()
                            {
                                IdAnime = idAnime,
                                IdGenero = listaGeneros[i].Id
                            };
                            _animeGeneroServico.Cadastrar(animeGenero);
                        }
                    }
                }
            }
        }
        private int idDoUltimoAnimeCadastrado()
        {
            var appSettings = ConfigurationManager.AppSettings;
            string result = appSettings[ConstantesDoRepositorio.CONNECTION_STRING];
            var dataConnection = new DataConnection(
                new DataOptions()
                    .UseSqlServer(result));
            var listaAnime = dataConnection.GetTable<Anime>();
            var idAnime = listaAnime.ToList().Last().Id;
            return idAnime;
        }
    }
}
