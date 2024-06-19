namespace Cod3rsGrowth.forms
{
    partial class FormAdicionarGenero
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
            label1 = new Label();
            textNome = new TextBox();
            btnAdicionarGenero = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(39, 50);
            label1.Name = "label1";
            label1.Size = new Size(53, 20);
            label1.TabIndex = 0;
            label1.Text = "Nome:";
            // 
            // textNome
            // 
            textNome.Location = new Point(98, 50);
            textNome.Name = "textNome";
            textNome.Size = new Size(247, 27);
            textNome.TabIndex = 1;
            // 
            // btnAdicionarGenero
            // 
            btnAdicionarGenero.Location = new Point(12, 144);
            btnAdicionarGenero.Name = "btnAdicionarGenero";
            btnAdicionarGenero.Size = new Size(153, 29);
            btnAdicionarGenero.TabIndex = 2;
            btnAdicionarGenero.Text = "Adicionar Gênero";
            btnAdicionarGenero.UseVisualStyleBackColor = true;
            btnAdicionarGenero.Click += AoClicarEmAdicionarGenero;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(263, 144);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(94, 29);
            btnCancelar.TabIndex = 3;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // FormAdicionarGenero
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(369, 185);
            Controls.Add(btnCancelar);
            Controls.Add(btnAdicionarGenero);
            Controls.Add(textNome);
            Controls.Add(label1);
            Name = "FormAdicionarGenero";
            Text = "Cadastro Gênero";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textNome;
        private Button btnAdicionarGenero;
        private Button btnCancelar;
    }
}