namespace Cod3rsGrowth.forms
{
    partial class FormEditarGenero
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
            txtId = new TextBox();
            textNome = new TextBox();
            label2 = new Label();
            btnCancelar = new Button();
            btnAtualizar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(59, 35);
            label1.Name = "label1";
            label1.Size = new Size(27, 20);
            label1.TabIndex = 0;
            label1.Text = "ID:";
            // 
            // txtId
            // 
            txtId.Enabled = false;
            txtId.Location = new Point(92, 32);
            txtId.Name = "txtId";
            txtId.Size = new Size(67, 27);
            txtId.TabIndex = 1;
            // 
            // textNome
            // 
            textNome.Location = new Point(92, 70);
            textNome.Name = "textNome";
            textNome.Size = new Size(269, 27);
            textNome.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(33, 70);
            label2.Name = "label2";
            label2.Size = new Size(53, 20);
            label2.TabIndex = 3;
            label2.Text = "Nome:";
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(267, 171);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(94, 29);
            btnCancelar.TabIndex = 4;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += AoClicarEmCancelar;
            // 
            // btnAtualizar
            // 
            btnAtualizar.Location = new Point(33, 171);
            btnAtualizar.Name = "btnAtualizar";
            btnAtualizar.Size = new Size(138, 29);
            btnAtualizar.TabIndex = 5;
            btnAtualizar.Text = "Atualizar Gênero";
            btnAtualizar.UseVisualStyleBackColor = true;
            btnAtualizar.Click += AoClicarEmAtualizarGenero;
            // 
            // FormEditarGenero
            // 
            AcceptButton = btnAtualizar;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancelar;
            ClientSize = new Size(385, 221);
            Controls.Add(btnAtualizar);
            Controls.Add(btnCancelar);
            Controls.Add(label2);
            Controls.Add(textNome);
            Controls.Add(txtId);
            Controls.Add(label1);
            Name = "FormEditarGenero";
            Text = "Atualização de Gênero";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtId;
        private TextBox textNome;
        private Label label2;
        private Button btnCancelar;
        private Button btnAtualizar;
    }
}