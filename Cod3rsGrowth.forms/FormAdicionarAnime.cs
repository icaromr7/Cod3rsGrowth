using Cod3rsGrowth.dominio;
using Cod3rsGrowth.infra;
using Cod3rsGrowth.Servico;
using FluentValidation;
using LinqToDB;
using LinqToDB.Data;
using System.CodeDom;
using System.Configuration;

namespace Cod3rsGrowth.forms
{
    public partial class FormAdicionarAnime : Form
    {
        AnimeServico _animeServico;
        GeneroServico _generoServico;
        AnimeGeneroServico _animeGeneroServico;    
        const int INDEX_EM_EXIBICAO = 0;
        const int INDEX_PREVISTO = 1;
        const int INDEX_CONCLUIDO = 2;
        const int QUANTIDADE_MINIMA_DE_GENEROS_SELECIONADOS = 1;
        const int POSICAO_INICIAL_NA_LISTA = 0;
        const string NECESSARIO_TER_UM_GENERO = "Necessário ter ao menos 1 genero selecionado";
        const string ERRO_AO_ADICIONAR = "Erro ao adicionar anime!";

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
            cbStatusDeExibicao.DataSource = new List<string>() {"EmExibição", "Previsto", "Concluído" };
        }

        private void AoClicarEmSalvar(object sender, EventArgs e)
        {
            try
            {
                if (clGeneros.CheckedItems.Count < QUANTIDADE_MINIMA_DE_GENEROS_SELECIONADOS)
                {
                    MessageBox.Show(NECESSARIO_TER_UM_GENERO);
                }
                else
                {
                    AoClicarEmAdicionarAnime();
                    AoClicarEmCadastrarAnimeGenero();
                    DialogResult = DialogResult.OK;
                    this.Close();
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
                MessageBox.Show(ERRO_AO_ADICIONAR);
            }
        }
        private void AoClicarEmCancelar(object sender, EventArgs e)
        {
            this.Close();
        }
        private void AoClicarEmAdicionarAnime()
        {
            Anime.Status status = new Anime.Status();
            if (cbStatusDeExibicao.SelectedIndex == INDEX_EM_EXIBICAO)
            {
                status = Anime.Status.EmExibicao;                
            }
            else if (cbStatusDeExibicao.SelectedIndex == INDEX_PREVISTO)
                status = Anime.Status.Previsto;
            else if (cbStatusDeExibicao.SelectedIndex == INDEX_CONCLUIDO)
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
        private void AoClicarEmCadastrarAnimeGenero()
        {
                int idAnime = ObtreIdDoUltimoIdCadastrado();
                var listaGeneros = _generoServico.ObterTodos();
                if (clGeneros.CheckedItems.Count >= QUANTIDADE_MINIMA_DE_GENEROS_SELECIONADOS)
                {
                var listaGenerosChecked = clGeneros.CheckedItems;
                foreach (var item in clGeneros.CheckedItems)
                {
                    for (int i = POSICAO_INICIAL_NA_LISTA; i < listaGeneros.Count; i++)
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
        private int ObtreIdDoUltimoIdCadastrado()
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
