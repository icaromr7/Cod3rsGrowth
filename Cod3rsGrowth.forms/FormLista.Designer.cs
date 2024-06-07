namespace Cod3rsGrowth.forms
{
    public partial class FormLista
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
            dataAnime = new DataGridView();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nomeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            sinopseDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            notaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            dataLancamentoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            statusDeExibicaoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            animeBindingSource = new BindingSource(components);
            btnRemover = new Button();
            btnEditar = new Button();
            btnAdicionar = new Button();
            ((System.ComponentModel.ISupportInitialize)dataAnime).BeginInit();
            ((System.ComponentModel.ISupportInitialize)animeBindingSource).BeginInit();
            SuspendLayout();
            // 
            // dataAnime
            // 
            dataAnime.AutoGenerateColumns = false;
            dataAnime.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataAnime.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, nomeDataGridViewTextBoxColumn, sinopseDataGridViewTextBoxColumn, notaDataGridViewTextBoxColumn, dataLancamentoDataGridViewTextBoxColumn, statusDeExibicaoDataGridViewTextBoxColumn });
            dataAnime.DataSource = animeBindingSource;
            dataAnime.Location = new Point(218, 45);
            dataAnime.Name = "dataAnime";
            dataAnime.RowHeadersWidth = 51;
            dataAnime.Size = new Size(656, 284);
            dataAnime.TabIndex = 0;
            dataAnime.CellContentClick += dataAnime_CellContentClick;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.MinimumWidth = 6;
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            idDataGridViewTextBoxColumn.Width = 51;
            // 
            // nomeDataGridViewTextBoxColumn
            // 
            nomeDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            nomeDataGridViewTextBoxColumn.DataPropertyName = "Nome";
            nomeDataGridViewTextBoxColumn.HeaderText = "Nome";
            nomeDataGridViewTextBoxColumn.MinimumWidth = 6;
            nomeDataGridViewTextBoxColumn.Name = "nomeDataGridViewTextBoxColumn";
            nomeDataGridViewTextBoxColumn.Width = 79;
            // 
            // sinopseDataGridViewTextBoxColumn
            // 
            sinopseDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            sinopseDataGridViewTextBoxColumn.DataPropertyName = "Sinopse";
            sinopseDataGridViewTextBoxColumn.HeaderText = "Sinopse";
            sinopseDataGridViewTextBoxColumn.MinimumWidth = 6;
            sinopseDataGridViewTextBoxColumn.Name = "sinopseDataGridViewTextBoxColumn";
            sinopseDataGridViewTextBoxColumn.Width = 90;
            // 
            // notaDataGridViewTextBoxColumn
            // 
            notaDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            notaDataGridViewTextBoxColumn.DataPropertyName = "Nota";
            notaDataGridViewTextBoxColumn.HeaderText = "Nota";
            notaDataGridViewTextBoxColumn.MaxInputLength = 3;
            notaDataGridViewTextBoxColumn.MinimumWidth = 3;
            notaDataGridViewTextBoxColumn.DefaultCellStyle = new DataGridViewCellStyle() { Format = "#.#"};
            notaDataGridViewTextBoxColumn.Name = "notaDataGridViewTextBoxColumn";
            notaDataGridViewTextBoxColumn.Width = 71;
            // 
            // dataLancamentoDataGridViewTextBoxColumn
            // 
            dataLancamentoDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataLancamentoDataGridViewTextBoxColumn.DataPropertyName = "DataLancamento";
            dataLancamentoDataGridViewTextBoxColumn.HeaderText = "DataLancamento";
            dataLancamentoDataGridViewTextBoxColumn.MinimumWidth = 6;
            dataLancamentoDataGridViewTextBoxColumn.Name = "dataLancamentoDataGridViewTextBoxColumn";
            dataLancamentoDataGridViewTextBoxColumn.Width = 151;
            // 
            // statusDeExibicaoDataGridViewTextBoxColumn
            // 
            statusDeExibicaoDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            statusDeExibicaoDataGridViewTextBoxColumn.DataPropertyName = "StatusDeExibicao";
            statusDeExibicaoDataGridViewTextBoxColumn.HeaderText = "StatusDeExibicao";
            statusDeExibicaoDataGridViewTextBoxColumn.MinimumWidth = 6;
            statusDeExibicaoDataGridViewTextBoxColumn.Name = "statusDeExibicaoDataGridViewTextBoxColumn";
            statusDeExibicaoDataGridViewTextBoxColumn.Width = 153;
            // 
            // animeBindingSource
            // 
            animeBindingSource.DataSource = typeof(dominio.Anime);
            // 
            // btnRemover
            // 
            btnRemover.Location = new Point(1030, 569);
            btnRemover.Name = "btnRemover";
            btnRemover.Size = new Size(94, 29);
            btnRemover.TabIndex = 2;
            btnRemover.Text = "Remover";
            btnRemover.UseVisualStyleBackColor = true;
            btnRemover.Click += button1_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(930, 569);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(94, 29);
            btnEditar.TabIndex = 3;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            // 
            // btnAdicionar
            // 
            btnAdicionar.Location = new Point(830, 569);
            btnAdicionar.Name = "btnAdicionar";
            btnAdicionar.Size = new Size(94, 29);
            btnAdicionar.TabIndex = 4;
            btnAdicionar.Text = "Adicionar";
            btnAdicionar.UseVisualStyleBackColor = true;
            btnAdicionar.Click += btnAdicionar_Click;
            // 
            // FormLista
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1147, 610);
            Controls.Add(btnAdicionar);
            Controls.Add(btnEditar);
            Controls.Add(btnRemover);
            Controls.Add(dataAnime);
            Name = "FormLista";
            Text = "FormLista";
            ((System.ComponentModel.ISupportInitialize)dataAnime).EndInit();
            ((System.ComponentModel.ISupportInitialize)animeBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataAnime;
        private Button btnRemover;
        private Button btnEditar;
        private Button btnAdicionar;
        private BindingSource animeBindingSource;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn sinopseDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn notaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dataLancamentoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn statusDeExibicaoDataGridViewTextBoxColumn;
    }
}
