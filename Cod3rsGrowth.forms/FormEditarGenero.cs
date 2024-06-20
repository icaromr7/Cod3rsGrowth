using Cod3rsGrowth.dominio;
using Cod3rsGrowth.Servico;
using FluentValidation;

namespace Cod3rsGrowth.forms
{
    public partial class FormEditarGenero : Form
    {
        private GeneroServico _generoServico;
        private Genero _genero;
        const string ERROR_AO_EDITAR_GENERO = "Erro ao editar gênero!";
        public FormEditarGenero(int idGenero, GeneroServico generoServico)
        {
            _generoServico = generoServico;
            _genero = _generoServico.ObterPorId(idGenero);
            InitializeComponent();
            txtId.Text = _genero.Id.ToString();
            textNome.Text = _genero.Nome;
        }

        private void AoClicarEmAtualizarGenero(object sender, EventArgs e)
        {
            try
            {
                EditarGenero();
                _generoServico.Atualizar(_genero);
                DialogResult = DialogResult.OK;
                this.Close();
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
                MessageBox.Show(ERROR_AO_EDITAR_GENERO);
            }
        }
        private void EditarGenero()
        {
            _genero.Nome = txtId.Text;
        }
        private void AoClicarEmCancelar(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
