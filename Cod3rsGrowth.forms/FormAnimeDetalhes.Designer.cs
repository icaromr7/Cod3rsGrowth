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
            textSinopse = new RichTextBox();
            listGeneros = new RichTextBox();
            textID = new TextBox();
            textNome = new TextBox();
            campoNota = new TextBox();
            dtpDataDeLancamento = new TextBox();
            textStatus = new TextBox();
            ((System.ComponentModel.ISupportInitialize)generoBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)animeBindingSource).BeginInit();
            SuspendLayout();
            // 
            // lblNome
            // 
            lblNome.Location = new Point(18, 53);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(63, 26);
            lblNome.TabIndex = 0;
            lblNome.Text = "Anime :";
            lblNome.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSinopse
            // 
            lblSinopse.Location = new Point(21, 147);
            lblSinopse.Name = "lblSinopse";
            lblSinopse.Size = new Size(571, 26);
            lblSinopse.TabIndex = 2;
            lblSinopse.Text = "Sinopse ";
            lblSinopse.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblNota
            // 
            lblNota.Location = new Point(479, 22);
            lblNota.Name = "lblNota";
            lblNota.Size = new Size(53, 26);
            lblNota.TabIndex = 4;
            lblNota.Text = "Nota :";
            lblNota.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblGenero
            // 
            lblGenero.Location = new Point(21, 302);
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
            lblDataDeLancamento.Location = new Point(310, 102);
            lblDataDeLancamento.Name = "lblDataDeLancamento";
            lblDataDeLancamento.Size = new Size(157, 26);
            lblDataDeLancamento.TabIndex = 8;
            lblDataDeLancamento.Text = "Data de Lançamento :";
            lblDataDeLancamento.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblStatusDeExibicao
            // 
            lblStatusDeExibicao.Location = new Point(18, 102);
            lblStatusDeExibicao.Name = "lblStatusDeExibicao";
            lblStatusDeExibicao.Size = new Size(139, 26);
            lblStatusDeExibicao.TabIndex = 10;
            lblStatusDeExibicao.Text = "Status de Exibição :";
            lblStatusDeExibicao.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // animeBindingSource
            // 
            animeBindingSource.DataSource = typeof(dominio.Anime);
            // 
            // lblId
            // 
            lblId.Location = new Point(47, 23);
            lblId.Name = "lblId";
            lblId.Size = new Size(34, 26);
            lblId.TabIndex = 16;
            lblId.Text = "ID :";
            lblId.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textSinopse
            // 
            textSinopse.Location = new Point(21, 176);
            textSinopse.Name = "textSinopse";
            textSinopse.ReadOnly = true;
            textSinopse.Size = new Size(562, 112);
            textSinopse.TabIndex = 24;
            textSinopse.Text = "";
            // 
            // listGeneros
            // 
            listGeneros.BackColor = SystemColors.Control;
            listGeneros.Location = new Point(206, 341);
            listGeneros.Name = "listGeneros";
            listGeneros.ReadOnly = true;
            listGeneros.Size = new Size(199, 82);
            listGeneros.TabIndex = 25;
            listGeneros.Text = "";
            // 
            // textID
            // 
            textID.Location = new Point(81, 23);
            textID.Name = "textID";
            textID.ReadOnly = true;
            textID.Size = new Size(48, 27);
            textID.TabIndex = 26;
            textID.TextAlign = HorizontalAlignment.Center;
            // 
            // textNome
            // 
            textNome.Location = new Point(81, 56);
            textNome.Name = "textNome";
            textNome.ReadOnly = true;
            textNome.Size = new Size(502, 27);
            textNome.TabIndex = 27;
            // 
            // campoNota
            // 
            campoNota.Location = new Point(538, 22);
            campoNota.Name = "campoNota";
            campoNota.ReadOnly = true;
            campoNota.Size = new Size(45, 27);
            campoNota.TabIndex = 28;
            campoNota.TextAlign = HorizontalAlignment.Center;
            // 
            // dtpDataDeLancamento
            // 
            dtpDataDeLancamento.Location = new Point(479, 101);
            dtpDataDeLancamento.Name = "dtpDataDeLancamento";
            dtpDataDeLancamento.ReadOnly = true;
            dtpDataDeLancamento.Size = new Size(104, 27);
            dtpDataDeLancamento.TabIndex = 29;
            dtpDataDeLancamento.TextAlign = HorizontalAlignment.Center;
            // 
            // textStatus
            // 
            textStatus.Location = new Point(166, 102);
            textStatus.Name = "textStatus";
            textStatus.ReadOnly = true;
            textStatus.Size = new Size(125, 27);
            textStatus.TabIndex = 30;
            textStatus.TextAlign = HorizontalAlignment.Center;
            // 
            // FormAnimeDetalhes
            // 
            AccessibleRole = AccessibleRole.ScrollBar;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = SystemColors.Control;
            ClientSize = new Size(604, 450);
            Controls.Add(textStatus);
            Controls.Add(dtpDataDeLancamento);
            Controls.Add(campoNota);
            Controls.Add(textNome);
            Controls.Add(textID);
            Controls.Add(listGeneros);
            Controls.Add(textSinopse);
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
        private RichTextBox textSinopse;
        private RichTextBox listGeneros;
        private TextBox textID;
        private TextBox textNome;
        private TextBox campoNota;
        private TextBox dtpDataDeLancamento;
        private TextBox textStatus;
    }
}