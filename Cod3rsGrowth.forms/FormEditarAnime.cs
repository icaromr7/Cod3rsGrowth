using Cod3rsGrowth.dominio;
using Cod3rsGrowth.Servico;
using FluentValidation;

namespace Cod3rsGrowth.forms
{
    public partial class FormEditarAnime : Form
    {
        AnimeServico _animeServico;
        GeneroServico _generoServico;
        AnimeGeneroServico _animeGeneroServico;
        Anime _animeModificado;
        List<Genero> GenerosAntigos = new List<Genero>();
        const int INDEX_EM_EXIBICAO = 0;
        const int INDEX_PREVISTO = 1;
        const int INDEX_CONCLUIDO = 2;
        const int QUANTIDADE_MINIMA_DE_GENEROS_SELECIONADOS = 1;
        const int POSICAO_INICIAL_NA_LISTA = 0;
        const string NECESSARIO_TER_UM_GENERO = "Necessário ter ao menos 1 genero selecionado";
        const string ERRO_AO_ATUALIZAR = "Erro ao atualizar o anime!";
        public FormEditarAnime(AnimeServico animeServico, GeneroServico generoServico, AnimeGeneroServico animeGeneroServico, int idAnime)
        {
            InitializeComponent();
            _generoServico = generoServico;
            _animeServico = animeServico;
            _animeGeneroServico = animeGeneroServico;
            _animeModificado = _animeServico.ObterPorId(idAnime);
            textID.Text = Convert.ToString(_animeModificado.Id);
            textNome.Text = Convert.ToString(_animeModificado.Nome);
            textSinopse.Text = Convert.ToString(_animeModificado.Sinopse);
            campoNota.Value = _animeModificado.Nota;
            PreencherCheckListBoxGenero();
            dtpDataDeLancamento.Value = _animeModificado.DataLancamento;
            PreencherComboBoxStatus();
            cbStatusDeExibicao.Text = _animeModificado.StatusDeExibicao.ToString();
        }

        private void PreencherCheckListBoxGenero()
        {
            var listaGeneros = _generoServico.ObterTodos();
            foreach (var genero in listaGeneros)
            {
                clGeneros.Items.Add(genero.Nome);
            }
            clGeneros.MultiColumn = true;
            List<AnimeGenero> listaAnimeGeneros = _animeGeneroServico.ObterTodos(_animeModificado.Id);

            for (int i = POSICAO_INICIAL_NA_LISTA; i < listaAnimeGeneros.Count; i++)
            {
                Genero genero = _generoServico.ObterPorId(listaAnimeGeneros[i].IdGenero);
                for (int j = POSICAO_INICIAL_NA_LISTA; j < clGeneros.Items.Count; j++)
                {                 
                    if (genero.Nome.Equals(clGeneros.Items[j]))
                    {
                        clGeneros.SetItemChecked(j, true);
                        GenerosAntigos.Add(genero);
                    }
                }
            }
        }

        private void PreencherComboBoxStatus()
        {
            cbStatusDeExibicao.DataSource = new List<string>() { "EmExibição", "Previsto", "Concluído" };
        }
        private void AoClicarEmAtualizarAnime(object sender, EventArgs e)
        {
            try
            {
                if (clGeneros.CheckedItems.Count < QUANTIDADE_MINIMA_DE_GENEROS_SELECIONADOS){
                    MessageBox.Show(NECESSARIO_TER_UM_GENERO);
                }
                else{
                    AoClicarEmAtualizar();
                    AoClicarEmAtualizarAnimeGenero();
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
                MessageBox.Show(ex.Message);
            }
        }
        private void AoClicarEmCancelar(object sender, EventArgs e)
        {
            this.Close();
        }
        private void AoClicarEmAtualizar()
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
            _animeServico.Atualizar(new Anime()
            {
                Id = Convert.ToInt32(textID.Text),
                Nome = textNome.Text,
                Sinopse = textSinopse.Text,
                Nota = Convert.ToDecimal(campoNota.Value),
                DataLancamento = dtpDataDeLancamento.Value,
                StatusDeExibicao = status
            });
        }
        private void AoClicarEmAtualizarAnimeGenero()
        {
            var generosAtuais = PreencherListaDosGenerosAtuais();
            var listaGenerosRetirados = ObterOsGenerosDiferentesEntreAsListas(generosAtuais, GenerosAntigos);
            ExcluirRelacaoAnimeGenero(generosAtuais);
            AdicionarRelacaoAnimeGenero(generosAtuais);
        }

        public void ExcluirRelacaoAnimeGenero(List<Genero> generosAtuais)
        {
            var listaGenerosRetirados = ObterOsGenerosDiferentesEntreAsListas(generosAtuais, GenerosAntigos);
            var listaAnimeGenerosRetorados = new List<AnimeGenero>();
            for (int i = POSICAO_INICIAL_NA_LISTA; i < listaGenerosRetirados.Count; i++)
            {
                var animeGenero = new AnimeGenero()
                {
                    IdAnime = _animeModificado.Id,
                    IdGenero = listaGenerosRetirados[i].Id,
                };
                listaAnimeGenerosRetorados.Add(animeGenero);
            }
            _animeGeneroServico.Deletar(listaAnimeGenerosRetorados);
        }
        public void AdicionarRelacaoAnimeGenero(List<Genero> generosAtuais)
        {
            var listaGenerosAdicionados = ObterOsGenerosDiferentesEntreAsListas(GenerosAntigos, generosAtuais);
            foreach (var adicionado in listaGenerosAdicionados)
            {
                var animeGenero = new AnimeGenero()
                {
                    IdAnime = _animeModificado.Id,
                    IdGenero = adicionado.Id,
                };
                _animeGeneroServico.Cadastrar(animeGenero);
            }
        }

        private List<Genero> PreencherListaDosGenerosAtuais()
        {
            var generosAtuais = new List<Genero>();
            var idAnime = _animeModificado.Id;
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
                            generosAtuais.Add(listaGeneros[i]);
                        }
                    }
                }
            }
            return generosAtuais;
        }

        private List<Genero> ObterOsGenerosDiferentesEntreAsListas(List<Genero> lista1, List<Genero> lista2)
        {
            var listaDiferença = new List<Genero>();
            foreach (var item in lista2)
            {
                if (lista1.Contains(item)==false)
                {
                    listaDiferença.Add(item);
                }
            }
            return listaDiferença;
        }
    }
}
