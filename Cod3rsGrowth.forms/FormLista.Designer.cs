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
            idColumn = new DataGridViewTextBoxColumn();
            nomeColumn = new DataGridViewTextBoxColumn();
            sinopseColumn = new DataGridViewTextBoxColumn();
            notaColumn = new DataGridViewTextBoxColumn();
            dataLancamentoColumn = new DataGridViewTextBoxColumn();
            statusDeExibicaoColumn = new DataGridViewTextBoxColumn();
            animeBindingSource = new BindingSource(components);
            btnRemover = new Button();
            btnEditar = new Button();
            btnAdicionar = new Button();
            formListaBindingSource = new BindingSource(components);
            btnDetalhes = new Button();
            txtNome = new TextBox();
            dtpDataLancamento = new DateTimePicker();
            cbStatusDeExibicao = new ComboBox();
            btnLimparFIltro = new Button();
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
            dataAnime.Location = new Point(44, 138);
            dataAnime.MultiSelect = false;
            dataAnime.Name = "dataAnime";
            dataAnime.ReadOnly = true;
            dataAnime.RowHeadersVisible = false;
            dataAnime.RowHeadersWidth = 51;
            dataAnime.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataAnime.Size = new Size(601, 284);
            dataAnime.TabIndex = 0;
            dataAnime.CellContentClick += dataAnime_CellContentClick;
            dataAnime.CellFormatting += dataAnimeFormatting;
            dataAnime.CellMouseDown += AoClicarNoAnime;
            // 
            // idColumn
            // 
            idColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            idColumn.DataPropertyName = "Id";
            idColumn.HeaderText = "Id";
            idColumn.MinimumWidth = 6;
            idColumn.Name = "idColumn";
            idColumn.ReadOnly = true;
            idColumn.Width = 51;
            // 
            // nomeColumn
            // 
            nomeColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            nomeColumn.DataPropertyName = "Nome";
            nomeColumn.HeaderText = "Nome";
            nomeColumn.MinimumWidth = 6;
            nomeColumn.Name = "nomeColumn";
            nomeColumn.ReadOnly = true;
            nomeColumn.Width = 79;
            // 
            // sinopseColumn
            // 
            sinopseColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            sinopseColumn.DataPropertyName = "Sinopse";
            sinopseColumn.HeaderText = "Sinopse";
            sinopseColumn.MinimumWidth = 6;
            sinopseColumn.Name = "sinopseColumn";
            sinopseColumn.ReadOnly = true;
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
            notaColumn.ReadOnly = true;
            notaColumn.Width = 71;
            // 
            // dataLancamentoColumn
            // 
            dataLancamentoColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataLancamentoColumn.DataPropertyName = "DataLancamento";
            dataLancamentoColumn.HeaderText = "DataLancamento";
            dataLancamentoColumn.MinimumWidth = 6;
            dataLancamentoColumn.Name = "dataLancamentoColumn";
            dataLancamentoColumn.ReadOnly = true;
            dataLancamentoColumn.Width = 151;
            // 
            // statusDeExibicaoColumn
            // 
            statusDeExibicaoColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            statusDeExibicaoColumn.DataPropertyName = "StatusDeExibicao";
            statusDeExibicaoColumn.HeaderText = "StatusDeExibicao";
            statusDeExibicaoColumn.MinimumWidth = 6;
            statusDeExibicaoColumn.Name = "statusDeExibicaoColumn";
            statusDeExibicaoColumn.ReadOnly = true;
            statusDeExibicaoColumn.Width = 153;
            // 
            // animeBindingSource
            // 
            animeBindingSource.DataSource = typeof(dominio.Anime);
            // 
            // btnRemover
            // 
            btnRemover.Location = new Point(551, 445);
            btnRemover.Name = "btnRemover";
            btnRemover.Size = new Size(94, 29);
            btnRemover.TabIndex = 2;
            btnRemover.Text = "Remover";
            btnRemover.UseVisualStyleBackColor = true;
            btnRemover.Click += AoClicarEmRemover;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(451, 445);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(94, 29);
            btnEditar.TabIndex = 3;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += AoClicarEmEditar;
            // 
            // btnAdicionar
            // 
            btnAdicionar.Location = new Point(351, 445);
            btnAdicionar.Name = "btnAdicionar";
            btnAdicionar.Size = new Size(94, 29);
            btnAdicionar.TabIndex = 4;
            btnAdicionar.Text = "Adicionar";
            btnAdicionar.UseVisualStyleBackColor = true;
            btnAdicionar.Click += AoClicarEmAdicionar;
            // 
            // formListaBindingSource
            // 
            formListaBindingSource.DataSource = typeof(FormLista);
            // 
            // btnDetalhes
            // 
            btnDetalhes.Location = new Point(539, 103);
            btnDetalhes.Name = "btnDetalhes";
            btnDetalhes.Size = new Size(106, 29);
            btnDetalhes.TabIndex = 5;
            btnDetalhes.Text = "Ver detalhes";
            btnDetalhes.UseVisualStyleBackColor = true;
            btnDetalhes.Click += AoClicarEmVerDetalhes;
            // 
            // txtNome
            // 
            txtNome.Location = new Point(12, 56);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(416, 27);
            txtNome.TabIndex = 6;
            txtNome.TextChanged += AoFiltrarPorNome;
            // 
            // dtpDataLancamento
            // 
            dtpDataLancamento.Format = DateTimePickerFormat.Short;
            dtpDataLancamento.Location = new Point(434, 56);
            dtpDataLancamento.Name = "dtpDataLancamento";
            dtpDataLancamento.Size = new Size(118, 27);
            dtpDataLancamento.TabIndex = 7;
            dtpDataLancamento.Value = new DateTime(2024, 6, 18, 0, 0, 0, 0);
            dtpDataLancamento.ValueChanged += AoSelecionarUmaData;
            // 
            // cbStatusDeExibicao
            // 
            cbStatusDeExibicao.DropDownStyle = ComboBoxStyle.DropDownList;
            cbStatusDeExibicao.FormattingEnabled = true;
            cbStatusDeExibicao.Location = new Point(558, 55);
            cbStatusDeExibicao.Name = "cbStatusDeExibicao";
            cbStatusDeExibicao.Size = new Size(118, 28);
            cbStatusDeExibicao.TabIndex = 8;
            cbStatusDeExibicao.SelectedIndexChanged += AoSelecionarUmStatusDeExibicao;
            // 
            // btnLimparFIltro
            // 
            btnLimparFIltro.Location = new Point(44, 103);
            btnLimparFIltro.Name = "btnLimparFIltro";
            btnLimparFIltro.Size = new Size(120, 29);
            btnLimparFIltro.TabIndex = 9;
            btnLimparFIltro.Text = "Limpar Filtro";
            btnLimparFIltro.UseVisualStyleBackColor = true;
            btnLimparFIltro.Click += AoClicarEmLimparFiltro;
            // 
            // FormLista
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(690, 486);
            Controls.Add(btnLimparFIltro);
            Controls.Add(cbStatusDeExibicao);
            Controls.Add(dtpDataLancamento);
            Controls.Add(txtNome);
            Controls.Add(btnDetalhes);
            Controls.Add(btnAdicionar);
            Controls.Add(btnEditar);
            Controls.Add(btnRemover);
            Controls.Add(dataAnime);
            MaximizeBox = false;
            Name = "FormLista";
            Text = "Lista de Anime";
            Load += FormLista_Load;
            ((System.ComponentModel.ISupportInitialize)dataAnime).EndInit();
            ((System.ComponentModel.ISupportInitialize)animeBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)formListaBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
        private Button btnDetalhes;
        private TextBox txtNome;
        private DateTimePicker dtpDataLancamento;
        private ComboBox cbStatusDeExibicao;
        private Button btnLimparFIltro;
    }
}
