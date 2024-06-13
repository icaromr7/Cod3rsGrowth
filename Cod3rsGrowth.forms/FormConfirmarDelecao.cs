using Cod3rsGrowth.dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cod3rsGrowth.forms
{
    public partial class FormConfirmarDelecao : Form
    {
        public FormConfirmarDelecao(String nome)
        {
            InitializeComponent();
            lblMensagemConfirmacao.Text = "Deseja mesmo excluir o anime:\n" + nome;
        }

        private void FormConfirmarDelecao_Load(object sender, EventArgs e)
        {

        }

        private void AoClicarEmConfirmar(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void AoClicarEmCancelar(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
