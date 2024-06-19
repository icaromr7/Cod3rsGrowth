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
            idColumnAnime = new DataGridViewTextBoxColumn();
            nomeColumnAnime = new DataGridViewTextBoxColumn();
            sinopseColumnAnime = new DataGridViewTextBoxColumn();
            notaColumnAnime = new DataGridViewTextBoxColumn();
            dataLancamentoColumnAnime = new DataGridViewTextBoxColumn();
            statusDeExibicaoColumnAnime = new DataGridViewTextBoxColumn();
            animeBindingSource = new BindingSource(components);
            btnRemoverAnime = new Button();
            btnEditarAnime = new Button();
            btnAdicionarAnime = new Button();
            formListaBindingSource = new BindingSource(components);
            btnDetalhes = new Button();
            txtNomeAnime = new TextBox();
            dtpDataLancamento = new DateTimePicker();
            cbStatusDeExibicao = new ComboBox();
            btnLimparFiltroAnime = new Button();
            contextMenuStrip1 = new ContextMenuStrip(components);
            contextMenuStrip2 = new ContextMenuStrip(components);
            contextMenuStrip3 = new ContextMenuStrip(components);
            tabLista = new TabControl();
            pagAnime = new TabPage();
            pagGenero = new TabPage();
            textNomeGenero = new TextBox();
            btnLimparFiltroGenero = new Button();
            btnAdicionarGenero = new Button();
            btnEditarGenero = new Button();
            btnRemoverGenero = new Button();
            dataGenero = new DataGridView();
            idColumnGenero = new DataGridViewTextBoxColumn();
            nomeColumnGenero = new DataGridViewTextBoxColumn();
            generoBindingSource = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)dataAnime).BeginInit();
            ((System.ComponentModel.ISupportInitialize)animeBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)formListaBindingSource).BeginInit();
            tabLista.SuspendLayout();
            pagAnime.SuspendLayout();
            pagGenero.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGenero).BeginInit();
            ((System.ComponentModel.ISupportInitialize)generoBindingSource).BeginInit();
            SuspendLayout();
            // 
            // dataAnime
            // 
            dataAnime.AutoGenerateColumns = false;
            dataAnime.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataAnime.Columns.AddRange(new DataGridViewColumn[] { idColumnAnime, nomeColumnAnime, sinopseColumnAnime, notaColumnAnime, dataLancamentoColumnAnime, statusDeExibicaoColumnAnime });
            dataAnime.DataSource = animeBindingSource;
            dataAnime.Location = new Point(35, 119);
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
            dataAnime.CellMouseDown += AoClicarEmUmItemNoDataGrid;
            // 
            // idColumnAnime
            // 
            idColumnAnime.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            idColumnAnime.DataPropertyName = "Id";
            idColumnAnime.HeaderText = "Id";
            idColumnAnime.MinimumWidth = 6;
            idColumnAnime.Name = "idColumnAnime";
            idColumnAnime.ReadOnly = true;
            idColumnAnime.Width = 51;
            // 
            // nomeColumnAnime
            // 
            nomeColumnAnime.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            nomeColumnAnime.DataPropertyName = "Nome";
            nomeColumnAnime.HeaderText = "Nome";
            nomeColumnAnime.MinimumWidth = 6;
            nomeColumnAnime.Name = "nomeColumnAnime";
            nomeColumnAnime.ReadOnly = true;
            nomeColumnAnime.Width = 79;
            // 
            // sinopseColumnAnime
            // 
            sinopseColumnAnime.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            sinopseColumnAnime.DataPropertyName = "Sinopse";
            sinopseColumnAnime.HeaderText = "Sinopse";
            sinopseColumnAnime.MinimumWidth = 6;
            sinopseColumnAnime.Name = "sinopseColumnAnime";
            sinopseColumnAnime.ReadOnly = true;
            sinopseColumnAnime.Width = 90;
            // 
            // notaColumnAnime
            // 
            notaColumnAnime.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            notaColumnAnime.DataPropertyName = "Nota";
            notaColumnAnime.HeaderText = "Nota";
            notaColumnAnime.MaxInputLength = 3;
            notaColumnAnime.MinimumWidth = 3;
            notaColumnAnime.Name = "notaColumnAnime";
            notaColumnAnime.ReadOnly = true;
            notaColumnAnime.Width = 71;
            // 
            // dataLancamentoColumnAnime
            // 
            dataLancamentoColumnAnime.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataLancamentoColumnAnime.DataPropertyName = "DataLancamento";
            dataLancamentoColumnAnime.HeaderText = "DataLancamento";
            dataLancamentoColumnAnime.MinimumWidth = 6;
            dataLancamentoColumnAnime.Name = "dataLancamentoColumnAnime";
            dataLancamentoColumnAnime.ReadOnly = true;
            dataLancamentoColumnAnime.Width = 151;
            // 
            // statusDeExibicaoColumnAnime
            // 
            statusDeExibicaoColumnAnime.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            statusDeExibicaoColumnAnime.DataPropertyName = "StatusDeExibicao";
            statusDeExibicaoColumnAnime.HeaderText = "StatusDeExibicao";
            statusDeExibicaoColumnAnime.MinimumWidth = 6;
            statusDeExibicaoColumnAnime.Name = "statusDeExibicaoColumnAnime";
            statusDeExibicaoColumnAnime.ReadOnly = true;
            statusDeExibicaoColumnAnime.Width = 153;
            // 
            // animeBindingSource
            // 
            animeBindingSource.DataSource = typeof(dominio.Anime);
            // 
            // btnRemoverAnime
            // 
            btnRemoverAnime.Location = new Point(542, 426);
            btnRemoverAnime.Name = "btnRemoverAnime";
            btnRemoverAnime.Size = new Size(94, 29);
            btnRemoverAnime.TabIndex = 2;
            btnRemoverAnime.Text = "Remover";
            btnRemoverAnime.UseVisualStyleBackColor = true;
            btnRemoverAnime.Click += AoClicarEmRemoverAnime;
            // 
            // btnEditarAnime
            // 
            btnEditarAnime.Location = new Point(442, 426);
            btnEditarAnime.Name = "btnEditarAnime";
            btnEditarAnime.Size = new Size(94, 29);
            btnEditarAnime.TabIndex = 3;
            btnEditarAnime.Text = "Editar";
            btnEditarAnime.UseVisualStyleBackColor = true;
            btnEditarAnime.Click += AoClicarEmEditarAnime;
            // 
            // btnAdicionarAnime
            // 
            btnAdicionarAnime.Location = new Point(342, 426);
            btnAdicionarAnime.Name = "btnAdicionarAnime";
            btnAdicionarAnime.Size = new Size(94, 29);
            btnAdicionarAnime.TabIndex = 4;
            btnAdicionarAnime.Text = "Adicionar";
            btnAdicionarAnime.UseVisualStyleBackColor = true;
            btnAdicionarAnime.Click += AoClicarEmAdicionarAnime;
            // 
            // formListaBindingSource
            // 
            formListaBindingSource.DataSource = typeof(FormLista);
            // 
            // btnDetalhes
            // 
            btnDetalhes.Location = new Point(530, 84);
            btnDetalhes.Name = "btnDetalhes";
            btnDetalhes.Size = new Size(106, 29);
            btnDetalhes.TabIndex = 5;
            btnDetalhes.Text = "Ver detalhes";
            btnDetalhes.UseVisualStyleBackColor = true;
            btnDetalhes.Click += AoClicarEmVerDetalhes;
            // 
            // txtNomeAnime
            // 
            txtNomeAnime.Location = new Point(3, 37);
            txtNomeAnime.Name = "txtNomeAnime";
            txtNomeAnime.Size = new Size(416, 27);
            txtNomeAnime.TabIndex = 6;
            txtNomeAnime.TextChanged += AoFiltrarPorNomeAnime;
            // 
            // dtpDataLancamento
            // 
            dtpDataLancamento.Format = DateTimePickerFormat.Short;
            dtpDataLancamento.Location = new Point(425, 37);
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
            cbStatusDeExibicao.Location = new Point(549, 36);
            cbStatusDeExibicao.Name = "cbStatusDeExibicao";
            cbStatusDeExibicao.Size = new Size(118, 28);
            cbStatusDeExibicao.TabIndex = 8;
            cbStatusDeExibicao.SelectedIndexChanged += AoSelecionarUmStatusDeExibicao;
            // 
            // btnLimparFiltroAnime
            // 
            btnLimparFiltroAnime.Location = new Point(35, 84);
            btnLimparFiltroAnime.Name = "btnLimparFiltroAnime";
            btnLimparFiltroAnime.Size = new Size(120, 29);
            btnLimparFiltroAnime.TabIndex = 9;
            btnLimparFiltroAnime.Text = "Limpar Filtro";
            btnLimparFiltroAnime.UseVisualStyleBackColor = true;
            btnLimparFiltroAnime.Click += AoClicarEmLimparFiltroAnime;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // contextMenuStrip2
            // 
            contextMenuStrip2.ImageScalingSize = new Size(20, 20);
            contextMenuStrip2.Name = "contextMenuStrip2";
            contextMenuStrip2.Size = new Size(61, 4);
            // 
            // contextMenuStrip3
            // 
            contextMenuStrip3.ImageScalingSize = new Size(20, 20);
            contextMenuStrip3.Name = "contextMenuStrip3";
            contextMenuStrip3.Size = new Size(61, 4);
            // 
            // tabLista
            // 
            tabLista.Controls.Add(pagAnime);
            tabLista.Controls.Add(pagGenero);
            tabLista.Location = new Point(2, 1);
            tabLista.Name = "tabLista";
            tabLista.SelectedIndex = 0;
            tabLista.Size = new Size(690, 500);
            tabLista.TabIndex = 13;
            tabLista.SelectedIndexChanged += AoTrocarDePagina;
            // 
            // pagAnime
            // 
            pagAnime.Controls.Add(txtNomeAnime);
            pagAnime.Controls.Add(dataAnime);
            pagAnime.Controls.Add(btnRemoverAnime);
            pagAnime.Controls.Add(btnEditarAnime);
            pagAnime.Controls.Add(btnLimparFiltroAnime);
            pagAnime.Controls.Add(btnAdicionarAnime);
            pagAnime.Controls.Add(cbStatusDeExibicao);
            pagAnime.Controls.Add(btnDetalhes);
            pagAnime.Controls.Add(dtpDataLancamento);
            pagAnime.Location = new Point(4, 29);
            pagAnime.Name = "pagAnime";
            pagAnime.Padding = new Padding(3);
            pagAnime.Size = new Size(682, 467);
            pagAnime.TabIndex = 0;
            pagAnime.Text = "Anime";
            pagAnime.UseVisualStyleBackColor = true;
            // 
            // pagGenero
            // 
            pagGenero.Controls.Add(textNomeGenero);
            pagGenero.Controls.Add(btnLimparFiltroGenero);
            pagGenero.Controls.Add(btnAdicionarGenero);
            pagGenero.Controls.Add(btnEditarGenero);
            pagGenero.Controls.Add(btnRemoverGenero);
            pagGenero.Controls.Add(dataGenero);
            pagGenero.Location = new Point(4, 29);
            pagGenero.Name = "pagGenero";
            pagGenero.Padding = new Padding(3);
            pagGenero.Size = new Size(682, 467);
            pagGenero.TabIndex = 1;
            pagGenero.Text = "Gênero";
            pagGenero.UseVisualStyleBackColor = true;
            // 
            // textNomeGenero
            // 
            textNomeGenero.Location = new Point(53, 20);
            textNomeGenero.Name = "textNomeGenero";
            textNomeGenero.Size = new Size(571, 27);
            textNomeGenero.TabIndex = 5;
            // 
            // btnLimparFiltroGenero
            // 
            btnLimparFiltroGenero.Location = new Point(53, 66);
            btnLimparFiltroGenero.Name = "btnLimparFiltroGenero";
            btnLimparFiltroGenero.Size = new Size(105, 29);
            btnLimparFiltroGenero.TabIndex = 4;
            btnLimparFiltroGenero.Text = "Limpar Filtro";
            btnLimparFiltroGenero.UseVisualStyleBackColor = true;
            // 
            // btnAdicionarGenero
            // 
            btnAdicionarGenero.Location = new Point(366, 423);
            btnAdicionarGenero.Name = "btnAdicionarGenero";
            btnAdicionarGenero.Size = new Size(94, 29);
            btnAdicionarGenero.TabIndex = 3;
            btnAdicionarGenero.Text = "Adicionar";
            btnAdicionarGenero.UseVisualStyleBackColor = true;
            btnAdicionarGenero.MouseClick += AoClicarEmAdicionarGenero;
            // 
            // btnEditarGenero
            // 
            btnEditarGenero.Location = new Point(466, 423);
            btnEditarGenero.Name = "btnEditarGenero";
            btnEditarGenero.Size = new Size(94, 29);
            btnEditarGenero.TabIndex = 2;
            btnEditarGenero.Text = "Editar";
            btnEditarGenero.UseVisualStyleBackColor = true;
            btnEditarGenero.MouseClick += AoClicarEmEditarGenero;
            // 
            // btnRemoverGenero
            // 
            btnRemoverGenero.Location = new Point(566, 423);
            btnRemoverGenero.Name = "btnRemoverGenero";
            btnRemoverGenero.Size = new Size(94, 29);
            btnRemoverGenero.TabIndex = 1;
            btnRemoverGenero.Text = "Remover";
            btnRemoverGenero.UseVisualStyleBackColor = true;
            btnRemoverGenero.MouseClick += AoClicarEmRemoverGenero;
            // 
            // dataGenero
            // 
            dataGenero.AutoGenerateColumns = false;
            dataGenero.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGenero.Columns.AddRange(new DataGridViewColumn[] { idColumnGenero, nomeColumnGenero });
            dataGenero.DataSource = generoBindingSource;
            dataGenero.Location = new Point(53, 101);
            dataGenero.Name = "dataGenero";
            dataGenero.ReadOnly = true;
            dataGenero.RowHeadersVisible = false;
            dataGenero.RowHeadersWidth = 51;
            dataGenero.RowTemplate.Height = 29;
            dataGenero.Size = new Size(571, 288);
            dataGenero.TabIndex = 0;
            dataGenero.CellMouseDown += AoClicarEmUmItemNoDataGrid;
            // 
            // idColumnGenero
            // 
            idColumnGenero.DataPropertyName = "Id";
            idColumnGenero.HeaderText = "Id";
            idColumnGenero.MinimumWidth = 6;
            idColumnGenero.Name = "idColumnGenero";
            idColumnGenero.ReadOnly = true;
            idColumnGenero.Width = 125;
            // 
            // nomeColumnGenero
            // 
            nomeColumnGenero.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            nomeColumnGenero.DataPropertyName = "Nome";
            nomeColumnGenero.HeaderText = "Nome";
            nomeColumnGenero.MinimumWidth = 6;
            nomeColumnGenero.Name = "nomeColumnGenero";
            nomeColumnGenero.ReadOnly = true;
            // 
            // generoBindingSource
            // 
            generoBindingSource.DataSource = typeof(dominio.Genero);
            // 
            // FormLista
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(690, 494);
            Controls.Add(tabLista);
            MaximizeBox = false;
            Name = "FormLista";
            Text = "Lista de Anime e Gênero";
            Load += FormLista_Load;
            ((System.ComponentModel.ISupportInitialize)dataAnime).EndInit();
            ((System.ComponentModel.ISupportInitialize)animeBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)formListaBindingSource).EndInit();
            tabLista.ResumeLayout(false);
            pagAnime.ResumeLayout(false);
            pagAnime.PerformLayout();
            pagGenero.ResumeLayout(false);
            pagGenero.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGenero).EndInit();
            ((System.ComponentModel.ISupportInitialize)generoBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataAnime;
        private Button btnRemoverAnime;
        private Button btnEditarAnime;
        private Button btnAdicionarAnime;
        private BindingSource animeBindingSource;
        private BindingSource formListaBindingSource;
        private Button btnDetalhes;
        private TextBox txtNomeAnime;
        private DateTimePicker dtpDataLancamento;
        private ComboBox cbStatusDeExibicao;
        private Button btnLimparFiltroAnime;
        private ContextMenuStrip contextMenuStrip1;
        private ContextMenuStrip contextMenuStrip2;
        private ContextMenuStrip contextMenuStrip3;
        private TabControl tabLista;
        private TabPage pagGenero;
        private TabPage pagAnime;
        private Button btnEditarGenero;
        private Button btnRemoverGenero;
        private DataGridView dataGenero;
        private BindingSource generoBindingSource;
        private Button btnAdicionarGenero;
        private TextBox textNomeGenero;
        private Button btnLimparFiltroGenero;
        private DataGridViewTextBoxColumn idColumnGenero;
        private DataGridViewTextBoxColumn nomeColumnGenero;
        private DataGridViewTextBoxColumn idColumnAnime;
        private DataGridViewTextBoxColumn nomeColumnAnime;
        private DataGridViewTextBoxColumn sinopseColumnAnime;
        private DataGridViewTextBoxColumn notaColumnAnime;
        private DataGridViewTextBoxColumn dataLancamentoColumnAnime;
        private DataGridViewTextBoxColumn statusDeExibicaoColumnAnime;
    }
}
