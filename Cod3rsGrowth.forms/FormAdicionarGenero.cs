using Cod3rsGrowth.dominio;
using Cod3rsGrowth.Servico;
using FluentValidation;
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
    public partial class FormAdicionarGenero : Form
    {
        private GeneroServico _generoServico;
        public FormAdicionarGenero(GeneroServico generoServico)
        {
            _generoServico = generoServico;
            InitializeComponent();
        }

        private void AoClicarEmAdicionarGenero(object sender, EventArgs e)
        {
            try
            {
                var genero = new Genero()
                {
                    Nome = RetornaNomeFormatado(textNome.Text.Trim())
                };
                _generoServico.Cadastrar(genero);
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
                MessageBox.Show(ex.Message);
            }
        }
        private string RetornaNomeFormatado(string nomeGenero)
        {
            var nomes = nomeGenero.Split(' ');
            var nomeGeneroFormatado = "";
            foreach (var nome in nomes)
            {
                nomeGeneroFormatado += nome.Substring(0, 1).ToUpper() + nome.Substring(1)+" ";
            }
            return nomeGeneroFormatado.Trim();
        }
    }
}
