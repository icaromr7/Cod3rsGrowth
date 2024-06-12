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
            animeBindingSource = new BindingSource(components);
            btnRemover = new Button();
            btnEditar = new Button();
            btnAdicionar = new Button();
            formListaBindingSource = new BindingSource(components);
            idColumn = new DataGridViewTextBoxColumn();
            nomeColumn = new DataGridViewTextBoxColumn();
            sinopseColumn = new DataGridViewTextBoxColumn();
            notaColumn = new DataGridViewTextBoxColumn();
            dataLancamentoColumn = new DataGridViewTextBoxColumn();
            statusDeExibicaoColumn = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataAnime).BeginInit();
            ((System.ComponentModel.ISupportInitialize)animeBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)formListaBindingSource).BeginInit();
            SuspendLayout();
            // 
            // dataAnime
            // 
            dataAnime.AutoGenerateColumns = false;
            dataAnime.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataAnime.Columns.AddRange(new DataGridViewColumn[] { idColumn, nomeColumn, sinopseColumn, notaColumn, dataLancamentoColumn, statusDeExibicaoColumn });
            dataAnime.DataSource = animeBindingSource;
            dataAnime.Location = new Point(33, 36);
            dataAnime.Name = "dataAnime";
            dataAnime.RowHeadersWidth = 51;
            dataAnime.Size = new Size(656, 284);
            dataAnime.TabIndex = 0;
            dataAnime.CellContentClick += dataAnime_CellContentClick;
            dataAnime.CellFormatting += dataAnimeFormatting;
            // 
            // animeBindingSource
            // 
            animeBindingSource.DataSource = typeof(dominio.Anime);
            // 
            // btnRemover
            // 
            btnRemover.Location = new Point(595, 339);
            btnRemover.Name = "btnRemover";
            btnRemover.Size = new Size(94, 29);
            btnRemover.TabIndex = 2;
            btnRemover.Text = "Remover";
            btnRemover.UseVisualStyleBackColor = true;
            btnRemover.Click += btnRemover_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(495, 339);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(94, 29);
            btnEditar.TabIndex = 3;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnAdicionar
            // 
            btnAdicionar.Location = new Point(395, 339);
            btnAdicionar.Name = "btnAdicionar";
            btnAdicionar.Size = new Size(94, 29);
            btnAdicionar.TabIndex = 4;
            btnAdicionar.Text = "Adicionar";
            btnAdicionar.UseVisualStyleBackColor = true;
            btnAdicionar.Click += btnAdicionar_Click;
            // 
            // formListaBindingSource
            // 
            formListaBindingSource.DataSource = typeof(FormLista);
            // 
            // idColumn
            // 
            idColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            idColumn.DataPropertyName = "Id";
            idColumn.HeaderText = "Id";
            idColumn.MinimumWidth = 6;
            idColumn.Name = "idColumn";
            idColumn.Width = 51;
            // 
            // nomeColumn
            // 
            nomeColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            nomeColumn.DataPropertyName = "Nome";
            nomeColumn.HeaderText = "Nome";
            nomeColumn.MinimumWidth = 6;
            nomeColumn.Name = "nomeColumn";
            nomeColumn.Width = 79;
            // 
            // sinopseColumn
            // 
            sinopseColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            sinopseColumn.DataPropertyName = "Sinopse";
            sinopseColumn.HeaderText = "Sinopse";
            sinopseColumn.MinimumWidth = 6;
            sinopseColumn.Name = "sinopseColumn";
            sinopseColumn.Width = 90;
            // 
            // notaColumn
            // 
            notaColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            notaColumn.DataPropertyName = "Nota";
            notaColumn.HeaderText = "Nota";
            notaColumn.MaxInputLength = 3;
            notaColumn.MinimumWidth = 3;
            notaColumn.Name = "notaColumn";
            notaColumn.Width = 71;
            // 
            // dataLancamentoColumn
            // 
            dataLancamentoColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataLancamentoColumn.DataPropertyName = "DataLancamento";
            dataLancamentoColumn.HeaderText = "DataLancamento";
            dataLancamentoColumn.MinimumWidth = 6;
            dataLancamentoColumn.Name = "dataLancamentoColumn";
            dataLancamentoColumn.Width = 151;
            // 
            // statusDeExibicaoColumn
            // 
            statusDeExibicaoColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            statusDeExibicaoColumn.DataPropertyName = "StatusDeExibicao";
            statusDeExibicaoColumn.HeaderText = "StatusDeExibicao";
            statusDeExibicaoColumn.MinimumWidth = 6;
            statusDeExibicaoColumn.Name = "statusDeExibicaoColumn";
            statusDeExibicaoColumn.Width = 153;
            // 
            // FormLista
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(724, 399);
            Controls.Add(btnAdicionar);
            Controls.Add(btnEditar);
            Controls.Add(btnRemover);
            Controls.Add(dataAnime);
            Name = "FormLista";
            Text = "FormLista";
            ((System.ComponentModel.ISupportInitialize)dataAnime).EndInit();
            ((System.ComponentModel.ISupportInitialize)animeBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)formListaBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataAnime;
        private Button btnRemover;
        private Button btnEditar;
        private Button btnAdicionar;
        private BindingSource animeBindingSource;
        private BindingSource formListaBindingSource;
        private DataGridViewTextBoxColumn idColumn;
        private DataGridViewTextBoxColumn nomeColumn;
        private DataGridViewTextBoxColumn sinopseColumn;
        private DataGridViewTextBoxColumn notaColumn;
        private DataGridViewTextBoxColumn dataLancamentoColumn;
        private DataGridViewTextBoxColumn statusDeExibicaoColumn;
    }
}
