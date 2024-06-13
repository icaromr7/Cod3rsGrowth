namespace Cod3rsGrowth.forms
{
    partial class FormAdicionarAnime
    {
        
        private System.ComponentModel.IContainer components = null;

       
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code


        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lblNome = new Label();
            textNome = new TextBox();
            lblSinopse = new Label();
            textSinopse = new TextBox();
            lblNota = new Label();
            lblGenero = new Label();
            generoBindingSource = new BindingSource(components);
            lblDataDeLancamento = new Label();
            dtpDataDeLancamento = new DateTimePicker();
            lblStatusDeExibicao = new Label();
            cbStatusDeExibicao = new ComboBox();
            animeBindingSource = new BindingSource(components);
            btnSalvar = new Button();
            btnCancelar = new Button();
            campoNota = new NumericUpDown();
            clGeneros = new CheckedListBox();
            ((System.ComponentModel.ISupportInitialize)generoBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)animeBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)campoNota).BeginInit();
            SuspendLayout();
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Location = new Point(47, 26);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(52, 20);
            lblNome.TabIndex = 0;
            lblNome.Text = "Anime";
            // 
            // textNome
            // 
            textNome.Location = new Point(47, 60);
            textNome.Name = "textNome";
            textNome.Size = new Size(376, 27);
            textNome.TabIndex = 1;
            // 
            // lblSinopse
            // 
            lblSinopse.AutoSize = true;
            lblSinopse.Location = new Point(47, 104);
            lblSinopse.Name = "lblSinopse";
            lblSinopse.Size = new Size(61, 20);
            lblSinopse.TabIndex = 2;
            lblSinopse.Text = "Sinopse";
            // 
            // textSinopse
            // 
            textSinopse.Location = new Point(47, 137);
            textSinopse.Multiline = true;
            textSinopse.Name = "textSinopse";
            textSinopse.Size = new Size(520, 72);
            textSinopse.TabIndex = 3;
            // 
            // lblNota
            // 
            lblNota.AutoSize = true;
            lblNota.Location = new Point(47, 221);
            lblNota.Name = "lblNota";
            lblNota.Size = new Size(42, 20);
            lblNota.TabIndex = 4;
            lblNota.Text = "Nota";
            // 
            // lblGenero
            // 
            lblGenero.AutoSize = true;
            lblGenero.Location = new Point(47, 304);
            lblGenero.Name = "lblGenero";
            lblGenero.Size = new Size(57, 20);
            lblGenero.TabIndex = 6;
            lblGenero.Text = "Genero";
            // 
            // generoBindingSource
            // 
            generoBindingSource.DataSource = typeof(dominio.Genero);
            // 
            // lblDataDeLancamento
            // 
            lblDataDeLancamento.AutoSize = true;
            lblDataDeLancamento.Location = new Point(48, 477);
            lblDataDeLancamento.Name = "lblDataDeLancamento";
            lblDataDeLancamento.Size = new Size(147, 20);
            lblDataDeLancamento.TabIndex = 8;
            lblDataDeLancamento.Text = "Data de Lançamento";
            // 
            // dtpDataDeLancamento
            // 
            dtpDataDeLancamento.CustomFormat = "";
            dtpDataDeLancamento.Location = new Point(48, 514);
            dtpDataDeLancamento.Name = "dtpDataDeLancamento";
            dtpDataDeLancamento.Size = new Size(315, 27);
            dtpDataDeLancamento.TabIndex = 9;
            dtpDataDeLancamento.Value = new DateTime(2024, 6, 12, 0, 0, 0, 0);
            // 
            // lblStatusDeExibicao
            // 
            lblStatusDeExibicao.AutoSize = true;
            lblStatusDeExibicao.Location = new Point(48, 563);
            lblStatusDeExibicao.Name = "lblStatusDeExibicao";
            lblStatusDeExibicao.Size = new Size(130, 20);
            lblStatusDeExibicao.TabIndex = 10;
            lblStatusDeExibicao.Text = "Status de Exibição";
            // 
            // cbStatusDeExibicao
            // 
            cbStatusDeExibicao.DisplayMember = "StatusDeExibicao";
            cbStatusDeExibicao.DropDownStyle = ComboBoxStyle.DropDownList;
            cbStatusDeExibicao.FormattingEnabled = true;
            cbStatusDeExibicao.Location = new Point(48, 597);
            cbStatusDeExibicao.Name = "cbStatusDeExibicao";
            cbStatusDeExibicao.Size = new Size(151, 28);
            cbStatusDeExibicao.TabIndex = 11;
            cbStatusDeExibicao.ValueMember = "StatusDeExibicao";
            // 
            // animeBindingSource
            // 
            animeBindingSource.DataSource = typeof(dominio.Anime);
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(48, 660);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(163, 37);
            btnSalvar.TabIndex = 12;
            btnSalvar.Text = "Adicionar Anime";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += AoClicarEmSalvar;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(405, 660);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(163, 37);
            btnCancelar.TabIndex = 13;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += AoClicarEmCancelar;
            // 
            // campoNota
            // 
            campoNota.DecimalPlaces = 1;
            campoNota.Location = new Point(47, 258);
            campoNota.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            campoNota.Name = "campoNota";
            campoNota.Size = new Size(70, 27);
            campoNota.TabIndex = 14;
            campoNota.ThousandsSeparator = true;
            campoNota.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // clGeneros
            // 
            clGeneros.DataBindings.Add(new Binding("SelectedValue", generoBindingSource, "Nome", true));
            clGeneros.FormattingEnabled = true;
            clGeneros.Location = new Point(48, 327);
            clGeneros.Name = "clGeneros";
            clGeneros.Size = new Size(519, 136);
            clGeneros.TabIndex = 15;
            // 
            // FormAdicionarAnime
            // 
            AcceptButton = btnSalvar;
            AccessibleRole = AccessibleRole.ScrollBar;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            CancelButton = btnCancelar;
            ClientSize = new Size(602, 706);
            Controls.Add(clGeneros);
            Controls.Add(campoNota);
            Controls.Add(btnCancelar);
            Controls.Add(btnSalvar);
            Controls.Add(cbStatusDeExibicao);
            Controls.Add(lblStatusDeExibicao);
            Controls.Add(dtpDataDeLancamento);
            Controls.Add(lblDataDeLancamento);
            Controls.Add(lblGenero);
            Controls.Add(lblNota);
            Controls.Add(textSinopse);
            Controls.Add(lblSinopse);
            Controls.Add(textNome);
            Controls.Add(lblNome);
            Name = "FormAdicionarAnime";
            Text = "Cadastro de Anime";
            Load += FormAdicionarAnime_Load;
            ((System.ComponentModel.ISupportInitialize)generoBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)animeBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)campoNota).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNome;
        private TextBox textNome;
        private Label lblSinopse;
        private TextBox textSinopse;
        private Label lblNota;
        private TextBox textNota;
        private Label lblGenero;
        private BindingSource generoBindingSource;
        private Label lblDataDeLancamento;
        private DateTimePicker dtpDataDeLancamento;
        private Label lblStatusDeExibicao;
        private ComboBox cbStatusDeExibicao;
        private BindingSource animeBindingSource;
        private Button btnSalvar;
        private Button btnCancelar;
        private NumericUpDown campoNota;
        private CheckedListBox clGeneros;
    }
}