using Microsoft.SqlServer.Server;

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
            lblNome.Anchor = AnchorStyles.Top;
            lblNome.Location = new Point(12, 94);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(571, 26);
            lblNome.TabIndex = 0;
            lblNome.Text = "Anime ";
            lblNome.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSinopse
            // 
            lblSinopse.Anchor = AnchorStyles.Top;
            lblSinopse.Location = new Point(12, 163);
            lblSinopse.Name = "lblSinopse";
            lblSinopse.Size = new Size(571, 26);
            lblSinopse.TabIndex = 2;
            lblSinopse.Text = "Sinopse ";
            lblSinopse.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblNota
            // 
            lblNota.Anchor = AnchorStyles.Top;
            lblNota.Location = new Point(12, 312);
            lblNota.Name = "lblNota";
            lblNota.Size = new Size(571, 26);
            lblNota.TabIndex = 4;
            lblNota.Text = "Nota ";
            lblNota.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblGenero
            // 
            lblGenero.Anchor = AnchorStyles.Top;
            lblGenero.Location = new Point(12, 385);
            lblGenero.Name = "lblGenero";
            lblGenero.Size = new Size(571, 26);
            lblGenero.TabIndex = 6;
            lblGenero.Text = "Genero ";
            lblGenero.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // generoBindingSource
            // 
            generoBindingSource.DataSource = typeof(dominio.Genero);
            // 
            // lblDataDeLancamento
            // 
            lblDataDeLancamento.Location = new Point(12, 524);
            lblDataDeLancamento.Name = "lblDataDeLancamento";
            lblDataDeLancamento.Size = new Size(571, 26);
            lblDataDeLancamento.TabIndex = 8;
            lblDataDeLancamento.Text = "Data de Lançamento ";
            lblDataDeLancamento.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblStatusDeExibicao
            // 
            lblStatusDeExibicao.Location = new Point(12, 603);
            lblStatusDeExibicao.Name = "lblStatusDeExibicao";
            lblStatusDeExibicao.Size = new Size(571, 26);
            lblStatusDeExibicao.TabIndex = 10;
            lblStatusDeExibicao.Text = "Status de Exibição ";
            lblStatusDeExibicao.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // animeBindingSource
            // 
            animeBindingSource.DataSource = typeof(dominio.Anime);
            // 
            // lblId
            // 
            lblId.Anchor = AnchorStyles.Top;
            lblId.Location = new Point(12, 23);
            lblId.Name = "lblId";
            lblId.Size = new Size(571, 26);
            lblId.TabIndex = 16;
            lblId.Text = "ID ";
            lblId.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textID
            // 
            textID.Anchor = AnchorStyles.Top;
            textID.Location = new Point(12, 52);
            textID.Name = "textID";
            textID.Size = new Size(571, 26);
            textID.TabIndex = 17;
            textID.Text = "Id";
            textID.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textNome
            // 
            textNome.Anchor = AnchorStyles.Top;
            textNome.Location = new Point(12, 120);
            textNome.Name = "textNome";
            textNome.Size = new Size(571, 26);
            textNome.TabIndex = 18;
            textNome.Text = "Nome";
            textNome.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // campoNota
            // 
            campoNota.Anchor = AnchorStyles.Top;
            campoNota.Location = new Point(12, 346);
            campoNota.Name = "campoNota";
            campoNota.Size = new Size(571, 26);
            campoNota.TabIndex = 20;
            campoNota.Text = "Nota";
            campoNota.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dtpDataDeLancamento
            // 
            dtpDataDeLancamento.Location = new Point(12, 562);
            dtpDataDeLancamento.Name = "dtpDataDeLancamento";
            dtpDataDeLancamento.Size = new Size(571, 26);
            dtpDataDeLancamento.TabIndex = 22;
            dtpDataDeLancamento.Text = "Data Lançamento";
            dtpDataDeLancamento.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textStatus
            // 
            textStatus.Location = new Point(12, 636);
            textStatus.Name = "textStatus";
            textStatus.Size = new Size(571, 26);
            textStatus.TabIndex = 23;
            textStatus.Text = "Status Exibição";
            textStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textSinopse
            // 
            textSinopse.Anchor = AnchorStyles.Top;
            textSinopse.Location = new Point(12, 192);
            textSinopse.Name = "textSinopse";
            textSinopse.ReadOnly = true;
            textSinopse.Size = new Size(571, 112);
            textSinopse.TabIndex = 24;
            textSinopse.Text = "";
            // 
            // listGeneros
            // 
            listGeneros.BackColor = SystemColors.Control;
            listGeneros.Location = new Point(169, 414);
            listGeneros.Name = "listGeneros";
            listGeneros.ReadOnly = true;
            listGeneros.Size = new Size(250, 82);
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
            ClientSize = new Size(602, 685);
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