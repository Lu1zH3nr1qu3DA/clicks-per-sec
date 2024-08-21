namespace Frms
{
    partial class frmPontuacao
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
            this.lbnome = new System.Windows.Forms.Label();
            this.tbnome = new System.Windows.Forms.TextBox();
            this.btsalvar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbnome
            // 
            this.lbnome.AutoSize = true;
            this.lbnome.Location = new System.Drawing.Point(110, 58);
            this.lbnome.Name = "lbnome";
            this.lbnome.Size = new System.Drawing.Size(35, 13);
            this.lbnome.TabIndex = 0;
            this.lbnome.Text = "Nome";
            // 
            // tbnome
            // 
            this.tbnome.Location = new System.Drawing.Point(113, 74);
            this.tbnome.Name = "tbnome";
            this.tbnome.Size = new System.Drawing.Size(253, 20);
            this.tbnome.TabIndex = 1;
            // 
            // btsalvar
            // 
            this.btsalvar.Location = new System.Drawing.Point(204, 152);
            this.btsalvar.Name = "btsalvar";
            this.btsalvar.Size = new System.Drawing.Size(75, 23);
            this.btsalvar.TabIndex = 1;
            this.btsalvar.Text = "Salvar";
            this.btsalvar.UseVisualStyleBackColor = true;
            this.btsalvar.Click += new System.EventHandler(this.btsalvar_Click);
            // 
            // frmPontuacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 251);
            this.Controls.Add(this.btsalvar);
            this.Controls.Add(this.tbnome);
            this.Controls.Add(this.lbnome);
            this.Name = "frmPontuacao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Placar de Pontos";
            this.Load += new System.EventHandler(this.frmPontuacao_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbnome;
        private System.Windows.Forms.TextBox tbnome;
        private System.Windows.Forms.Button btsalvar;
    }
}