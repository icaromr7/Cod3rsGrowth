namespace Cod3rsGrowth.forms
{
    partial class FormConfirmarDelecao
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
            lblMensagemConfirmacao = new Label();
            btnConfirmar = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // lblMensagemConfirmacao
            // 
            lblMensagemConfirmacao.AutoSize = true;
            lblMensagemConfirmacao.Location = new Point(201, 87);
            lblMensagemConfirmacao.Name = "lblMensagemConfirmacao";
            lblMensagemConfirmacao.Size = new Size(215, 20);
            lblMensagemConfirmacao.TabIndex = 0;
            lblMensagemConfirmacao.Text = "Deseja mesmo excluir o anime:";
            // 
            // btnConfirmar
            // 
            btnConfirmar.Location = new Point(84, 224);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(137, 41);
            btnConfirmar.TabIndex = 1;
            btnConfirmar.Text = "Confirmar";
            btnConfirmar.UseVisualStyleBackColor = true;
            btnConfirmar.Click += AoClicarEmConfirmar;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(435, 224);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(137, 41);
            btnCancelar.TabIndex = 2;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += AoClicarEmCancelar;
            // 
            // FormConfirmarDelecao
            // 
            AcceptButton = btnConfirmar;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancelar;
            ClientSize = new Size(638, 281);
            Controls.Add(btnCancelar);
            Controls.Add(btnConfirmar);
            Controls.Add(lblMensagemConfirmacao);
            Name = "FormConfirmarDelecao";
            Text = "FormConfirmarDelecao";
            Load += FormConfirmarDelecao_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblMensagemConfirmacao;
        private Button btnConfirmar;
        private Button btnCancelar;
    }
}