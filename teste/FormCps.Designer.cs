namespace teste
{
    partial class FormCps
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lbclicks = new System.Windows.Forms.Label();
            this.btclick = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.lbtempo = new System.Windows.Forms.Label();
            this.gbduracao = new System.Windows.Forms.GroupBox();
            this.rb1min = new System.Windows.Forms.RadioButton();
            this.rb30seg = new System.Windows.Forms.RadioButton();
            this.rb15seg = new System.Windows.Forms.RadioButton();
            this.rb10seg = new System.Windows.Forms.RadioButton();
            this.gbduracao.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbclicks
            // 
            this.lbclicks.AutoSize = true;
            this.lbclicks.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbclicks.Location = new System.Drawing.Point(328, 151);
            this.lbclicks.Name = "lbclicks";
            this.lbclicks.Size = new System.Drawing.Size(143, 20);
            this.lbclicks.TabIndex = 0;
            this.lbclicks.Text = "Número de Cliques";
            // 
            // btclick
            // 
            this.btclick.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btclick.Location = new System.Drawing.Point(350, 206);
            this.btclick.Name = "btclick";
            this.btclick.Size = new System.Drawing.Size(101, 39);
            this.btclick.TabIndex = 1;
            this.btclick.Text = "Clique Aqui";
            this.btclick.UseVisualStyleBackColor = true;
            this.btclick.Click += new System.EventHandler(this.btclick_Click);
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // lbtempo
            // 
            this.lbtempo.AutoSize = true;
            this.lbtempo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbtempo.Location = new System.Drawing.Point(367, 273);
            this.lbtempo.Name = "lbtempo";
            this.lbtempo.Size = new System.Drawing.Size(58, 20);
            this.lbtempo.TabIndex = 2;
            this.lbtempo.Text = "Tempo";
            // 
            // gbduracao
            // 
            this.gbduracao.Controls.Add(this.rb1min);
            this.gbduracao.Controls.Add(this.rb30seg);
            this.gbduracao.Controls.Add(this.rb15seg);
            this.gbduracao.Controls.Add(this.rb10seg);
            this.gbduracao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.gbduracao.Location = new System.Drawing.Point(35, 151);
            this.gbduracao.Name = "gbduracao";
            this.gbduracao.Size = new System.Drawing.Size(200, 155);
            this.gbduracao.TabIndex = 4;
            this.gbduracao.TabStop = false;
            this.gbduracao.Text = "Duração";
            // 
            // rb1min
            // 
            this.rb1min.AutoSize = true;
            this.rb1min.Location = new System.Drawing.Point(6, 115);
            this.rb1min.Name = "rb1min";
            this.rb1min.Size = new System.Drawing.Size(88, 24);
            this.rb1min.TabIndex = 3;
            this.rb1min.TabStop = true;
            this.rb1min.Text = "1 minuto";
            this.rb1min.UseVisualStyleBackColor = true;
            this.rb1min.CheckedChanged += new System.EventHandler(this.rb1min_CheckedChanged);
            // 
            // rb30seg
            // 
            this.rb30seg.AutoSize = true;
            this.rb30seg.Location = new System.Drawing.Point(6, 85);
            this.rb30seg.Name = "rb30seg";
            this.rb30seg.Size = new System.Drawing.Size(119, 24);
            this.rb30seg.TabIndex = 2;
            this.rb30seg.TabStop = true;
            this.rb30seg.Text = "30 segundos";
            this.rb30seg.UseVisualStyleBackColor = true;
            this.rb30seg.CheckedChanged += new System.EventHandler(this.rb30seg_CheckedChanged);
            // 
            // rb15seg
            // 
            this.rb15seg.AutoSize = true;
            this.rb15seg.Checked = true;
            this.rb15seg.Location = new System.Drawing.Point(6, 55);
            this.rb15seg.Name = "rb15seg";
            this.rb15seg.Size = new System.Drawing.Size(119, 24);
            this.rb15seg.TabIndex = 1;
            this.rb15seg.TabStop = true;
            this.rb15seg.Text = "15 segundos";
            this.rb15seg.UseVisualStyleBackColor = true;
            this.rb15seg.CheckedChanged += new System.EventHandler(this.rb15seg_CheckedChanged);
            // 
            // rb10seg
            // 
            this.rb10seg.AutoSize = true;
            this.rb10seg.Location = new System.Drawing.Point(6, 25);
            this.rb10seg.Name = "rb10seg";
            this.rb10seg.Size = new System.Drawing.Size(119, 24);
            this.rb10seg.TabIndex = 0;
            this.rb10seg.TabStop = true;
            this.rb10seg.Text = "10 segundos";
            this.rb10seg.UseVisualStyleBackColor = true;
            this.rb10seg.CheckedChanged += new System.EventHandler(this.rb10seg_CheckedChanged);
            // 
            // FormCps
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btclick);
            this.Controls.Add(this.gbduracao);
            this.Controls.Add(this.lbtempo);
            this.Controls.Add(this.lbclicks);
            this.Name = "FormCps";
            this.Text = "Cliques por Segundo";
            this.Load += new System.EventHandler(this.FormCps_Load);
            this.gbduracao.ResumeLayout(false);
            this.gbduracao.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbclicks;
        private System.Windows.Forms.Button btclick;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label lbtempo;
        private System.Windows.Forms.GroupBox gbduracao;
        private System.Windows.Forms.RadioButton rb1min;
        private System.Windows.Forms.RadioButton rb30seg;
        private System.Windows.Forms.RadioButton rb15seg;
        private System.Windows.Forms.RadioButton rb10seg;
    }
}

