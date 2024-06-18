namespace Cod3rsGrowth.forms
{
    partial class FormAnimeDetalhes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lblNome = new Label();
            lblSinopse = new Label();
            lblNota = new Label();
            lblGenero = new Label();
            generoBindingSource = new BindingSource(components);
            lblDataDeLancamento = new Label();
            lblStatusDeExibicao = new Label();
            animeBindingSource = new BindingSource(components);
            lblId = new Label();
            textID = new Label();
            textNome = new Label();
            campoNota = new Label();
            dtpDataDeLancamento = new Label();
            textStatus = new Label();
            textSinopse = new RichTextBox();
            listGeneros = new RichTextBox();
            ((System.ComponentModel.ISupportInitialize)generoBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)animeBindingSource).BeginInit();
            SuspendLayout();
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Location = new Point(43, 55);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(59, 20);
            lblNome.TabIndex = 0;
            lblNome.Text = "Anime :";
            // 
            // lblSinopse
            // 
            lblSinopse.AutoSize = true;
            lblSinopse.Location = new Point(43, 85);
            lblSinopse.Name = "lblSinopse";
            lblSinopse.Size = new Size(68, 20);
            lblSinopse.TabIndex = 2;
            lblSinopse.Text = "Sinopse :";
            // 
            // lblNota
            // 
            lblNota.AutoEllipsis = true;
            lblNota.AutoSize = true;
            lblNota.Location = new Point(43, 235);
            lblNota.Margin = new Padding(2);
            lblNota.Name = "lblNota";
            lblNota.Size = new Size(49, 20);
            lblNota.TabIndex = 4;
            lblNota.Text = "Nota :";
            // 
            // lblGenero
            // 
            lblGenero.AutoSize = true;
            lblGenero.Location = new Point(43, 257);
            lblGenero.Name = "lblGenero";
            lblGenero.Size = new Size(64, 20);
            lblGenero.TabIndex = 6;
            lblGenero.Text = "Genero :";
            // 
            // generoBindingSource
            // 
            generoBindingSource.DataSource = typeof(dominio.Genero);
            // 
            // lblDataDeLancamento
            // 
            lblDataDeLancamento.AutoSize = true;
            lblDataDeLancamento.Location = new Point(43, 375);
            lblDataDeLancamento.Name = "lblDataDeLancamento";
            lblDataDeLancamento.Size = new Size(154, 20);
            lblDataDeLancamento.TabIndex = 8;
            lblDataDeLancamento.Text = "Data de Lançamento :";
            // 
            // lblStatusDeExibicao
            // 
            lblStatusDeExibicao.AutoSize = true;
            lblStatusDeExibicao.Location = new Point(43, 408);
            lblStatusDeExibicao.Name = "lblStatusDeExibicao";
            lblStatusDeExibicao.Size = new Size(137, 20);
            lblStatusDeExibicao.TabIndex = 10;
            lblStatusDeExibicao.Text = "Status de Exibição :";
            // 
            // animeBindingSource
            // 
            animeBindingSource.DataSource = typeof(dominio.Anime);
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(43, 22);
            lblId.Name = "lblId";
            lblId.Size = new Size(31, 20);
            lblId.TabIndex = 16;
            lblId.Text = "ID :";
            // 
            // textID
            // 
            textID.AutoSize = true;
            textID.Location = new Point(83, 22);
            textID.Name = "textID";
            textID.Size = new Size(22, 20);
            textID.TabIndex = 17;
            textID.Text = "Id";
            // 
            // textNome
            // 
            textNome.AutoSize = true;
            textNome.Location = new Point(108, 55);
            textNome.Name = "textNome";
            textNome.Size = new Size(50, 20);
            textNome.TabIndex = 18;
            textNome.Text = "Nome";
            // 
            // campoNota
            // 
            campoNota.AutoSize = true;
            campoNota.Location = new Point(97, 235);
            campoNota.Name = "campoNota";
            campoNota.Size = new Size(39, 20);
            campoNota.TabIndex = 20;
            campoNota.Text = "nota";
            // 
            // dtpDataDeLancamento
            // 
            dtpDataDeLancamento.AutoSize = true;
            dtpDataDeLancamento.Location = new Point(203, 375);
            dtpDataDeLancamento.Name = "dtpDataDeLancamento";
            dtpDataDeLancamento.Size = new Size(126, 20);
            dtpDataDeLancamento.TabIndex = 22;
            dtpDataDeLancamento.Text = "Data Lançamento";
            // 
            // textStatus
            // 
            textStatus.AutoSize = true;
            textStatus.Location = new Point(186, 408);
            textStatus.Name = "textStatus";
            textStatus.Size = new Size(109, 20);
            textStatus.TabIndex = 23;
            textStatus.Text = "Status Exibição";
            // 
            // textSinopse
            // 
            textSinopse.Location = new Point(56, 110);
            textSinopse.Name = "textSinopse";
            textSinopse.ReadOnly = true;
            textSinopse.Size = new Size(534, 112);
            textSinopse.TabIndex = 24;
            textSinopse.Text = "";
            // 
            // listGeneros
            // 
            listGeneros.BackColor = SystemColors.Control;
            listGeneros.Location = new Point(56, 280);
            listGeneros.Name = "listGeneros";
            listGeneros.ReadOnly = true;
            listGeneros.Size = new Size(141, 82);
            listGeneros.TabIndex = 25;
            listGeneros.Text = "";
            // 
            // FormAnimeDetalhes
            // 
            AccessibleRole = AccessibleRole.ScrollBar;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = SystemColors.Control;
            ClientSize = new Size(602, 458);
            Controls.Add(listGeneros);
            Controls.Add(textSinopse);
            Controls.Add(textStatus);
            Controls.Add(dtpDataDeLancamento);
            Controls.Add(campoNota);
            Controls.Add(textNome);
            Controls.Add(textID);
            Controls.Add(lblId);
            Controls.Add(lblStatusDeExibicao);
            Controls.Add(lblDataDeLancamento);
            Controls.Add(lblGenero);
            Controls.Add(lblNota);
            Controls.Add(lblSinopse);
            Controls.Add(lblNome);
            MaximizeBox = false;
            Name = "FormAnimeDetalhes";
            Text = "Detalhes do Anime";
            ((System.ComponentModel.ISupportInitialize)generoBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)animeBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblNome;
        private Label lblSinopse;
        private Label lblNota;
        private TextBox textNota;
        private Label lblGenero;
        private BindingSource generoBindingSource;
        private Label lblDataDeLancamento;
        private Label lblStatusDeExibicao;
        private BindingSource animeBindingSource;
        private Label lblId;
        private Label textID;
        private Label textNome;
        private Label campoNota;
        private Label dtpDataDeLancamento;
        private Label textStatus;
        private RichTextBox textSinopse;
        private RichTextBox listGeneros;
    }
}