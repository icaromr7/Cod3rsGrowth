using Cod3rsGrowth.dominio;

namespace Cod3rsGrowth.forms
{
    public partial class Form1
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
            dataAnime = new DataGridView();
            dataGenero = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataAnime).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGenero).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            //
            dataAnime.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataAnime.Location = new Point(21, 12);
            dataAnime.Name = "dataAnime";
            dataAnime.RowHeadersWidth = 51;
            dataAnime.Size = new Size(853, 284);
            dataAnime.TabIndex = 0;
            dataAnime.CellContentClick += dataGridView1_CellContentClick;
            // 
            // dataGridView2
            // 
            dataGenero.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGenero.Location = new Point(21, 362);
            dataGenero.Name = "dataGenero";
            dataGenero.RowHeadersWidth = 51;
            dataGenero.RowTemplate.Height = 29;
            dataGenero.Size = new Size(853, 188);
            dataGenero.TabIndex = 1;
            dataGenero.CellContentClick += dataGridView2_CellContentClick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(896, 610);
            Controls.Add(dataGenero);
            Controls.Add(dataAnime);
            Text = "Tabelas";
            ((System.ComponentModel.ISupportInitialize)dataAnime).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGenero).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataAnime;
        private DataGridView dataGenero;
    }
}
