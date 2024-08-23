namespace Cps
{
    partial class frmCps
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
            this.lblclicks = new System.Windows.Forms.Label();
            this.btclick = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.lbltime = new System.Windows.Forms.Label();
            this.grpduration = new System.Windows.Forms.GroupBox();
            this.rdo1min = new System.Windows.Forms.RadioButton();
            this.rdo30sec = new System.Windows.Forms.RadioButton();
            this.rdo15sec = new System.Windows.Forms.RadioButton();
            this.rdo10sec = new System.Windows.Forms.RadioButton();
            this.btnscores = new System.Windows.Forms.Button();
            this.lblclickstxt = new System.Windows.Forms.Label();
            this.lbltimetxt = new System.Windows.Forms.Label();
            this.dgvscores = new System.Windows.Forms.DataGridView();
            this.grpduration.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvscores)).BeginInit();
            this.SuspendLayout();
            // 
            // lbclicks
            // 
            this.lblclicks.AutoSize = true;
            this.lblclicks.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblclicks.Location = new System.Drawing.Point(391, 151);
            this.lblclicks.Name = "lbclicks";
            this.lblclicks.Size = new System.Drawing.Size(18, 20);
            this.lblclicks.TabIndex = 0;
            this.lblclicks.Text = "0";
            this.lblclicks.Visible = false;
            // 
            // btclick
            // 
            this.btclick.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btclick.Location = new System.Drawing.Point(350, 206);
            this.btclick.Name = "btclick";
            this.btclick.Size = new System.Drawing.Size(101, 39);
            this.btclick.TabIndex = 0;
            this.btclick.Text = "Clique Aqui";
            this.btclick.UseVisualStyleBackColor = true;
            this.btclick.Click += new System.EventHandler(this.btnclick_Click);
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // lbtempo
            // 
            this.lbltime.AutoSize = true;
            this.lbltime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbltime.Location = new System.Drawing.Point(371, 270);
            this.lbltime.Name = "lbtempo";
            this.lbltime.Size = new System.Drawing.Size(58, 20);
            this.lbltime.TabIndex = 0;
            this.lbltime.Text = "00.000";
            this.lbltime.Visible = false;
            // 
            // gbduracao
            // 
            this.grpduration.Controls.Add(this.rdo1min);
            this.grpduration.Controls.Add(this.rdo30sec);
            this.grpduration.Controls.Add(this.rdo15sec);
            this.grpduration.Controls.Add(this.rdo10sec);
            this.grpduration.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.grpduration.Location = new System.Drawing.Point(35, 151);
            this.grpduration.Name = "gbduracao";
            this.grpduration.Size = new System.Drawing.Size(200, 155);
            this.grpduration.TabIndex = 1;
            this.grpduration.TabStop = false;
            this.grpduration.Text = "Duração";
            // 
            // rb1min
            // 
            this.rdo1min.AutoSize = true;
            this.rdo1min.Location = new System.Drawing.Point(6, 115);
            this.rdo1min.Name = "rb1min";
            this.rdo1min.Size = new System.Drawing.Size(88, 24);
            this.rdo1min.TabIndex = 5;
            this.rdo1min.TabStop = true;
            this.rdo1min.Text = "1 minuto";
            this.rdo1min.UseVisualStyleBackColor = true;
            this.rdo1min.CheckedChanged += new System.EventHandler(this.rdo1min_CheckedChanged);
            // 
            // rb30seg
            // 
            this.rdo30sec.AutoSize = true;
            this.rdo30sec.Location = new System.Drawing.Point(6, 85);
            this.rdo30sec.Name = "rb30seg";
            this.rdo30sec.Size = new System.Drawing.Size(119, 24);
            this.rdo30sec.TabIndex = 4;
            this.rdo30sec.TabStop = true;
            this.rdo30sec.Text = "30 segundos";
            this.rdo30sec.UseVisualStyleBackColor = true;
            this.rdo30sec.CheckedChanged += new System.EventHandler(this.rdo30sec_CheckedChanged);
            // 
            // rb15seg
            // 
            this.rdo15sec.AutoSize = true;
            this.rdo15sec.Checked = true;
            this.rdo15sec.Location = new System.Drawing.Point(6, 55);
            this.rdo15sec.Name = "rb15seg";
            this.rdo15sec.Size = new System.Drawing.Size(119, 24);
            this.rdo15sec.TabIndex = 3;
            this.rdo15sec.TabStop = true;
            this.rdo15sec.Text = "15 segundos";
            this.rdo15sec.UseVisualStyleBackColor = true;
            this.rdo15sec.CheckedChanged += new System.EventHandler(this.rdo15sec_CheckedChanged);
            // 
            // rb10seg
            // 
            this.rdo10sec.AutoSize = true;
            this.rdo10sec.Location = new System.Drawing.Point(6, 25);
            this.rdo10sec.Name = "rb10seg";
            this.rdo10sec.Size = new System.Drawing.Size(119, 24);
            this.rdo10sec.TabIndex = 2;
            this.rdo10sec.TabStop = true;
            this.rdo10sec.Text = "10 segundos";
            this.rdo10sec.UseVisualStyleBackColor = true;
            this.rdo10sec.CheckedChanged += new System.EventHandler(this.rdo10sec_CheckedChanged);
            // 
            // btplacar
            // 
            this.btnscores.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnscores.Location = new System.Drawing.Point(350, 355);
            this.btnscores.Name = "btplacar";
            this.btnscores.Size = new System.Drawing.Size(101, 39);
            this.btnscores.TabIndex = 6;
            this.btnscores.Text = "Placar";
            this.btnscores.UseVisualStyleBackColor = true;
            this.btnscores.Click += new System.EventHandler(this.btnscores_Click);
            // 
            // lbclickstxt
            // 
            this.lblclickstxt.AutoSize = true;
            this.lblclickstxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblclickstxt.Location = new System.Drawing.Point(329, 151);
            this.lblclickstxt.Name = "lbclickstxt";
            this.lblclickstxt.Size = new System.Drawing.Size(143, 20);
            this.lblclickstxt.TabIndex = 0;
            this.lblclickstxt.Text = "Número de Cliques";
            // 
            // lbtempotxt
            // 
            this.lbltimetxt.AutoSize = true;
            this.lbltimetxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbltimetxt.Location = new System.Drawing.Point(371, 270);
            this.lbltimetxt.Name = "lbtempotxt";
            this.lbltimetxt.Size = new System.Drawing.Size(58, 20);
            this.lbltimetxt.TabIndex = 0;
            this.lbltimetxt.Text = "Tempo";
            // 
            // dgvpontuacao
            // 
            this.dgvscores.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvscores.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvscores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvscores.Enabled = false;
            this.dgvscores.Location = new System.Drawing.Point(35, 50);
            this.dgvscores.Name = "dgvpontuacao";
            this.dgvscores.Size = new System.Drawing.Size(731, 256);
            this.dgvscores.TabIndex = 7;
            this.dgvscores.Visible = false;
            // 
            // frmCps
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvscores);
            this.Controls.Add(this.btnscores);
            this.Controls.Add(this.btclick);
            this.Controls.Add(this.grpduration);
            this.Controls.Add(this.lblclicks);
            this.Controls.Add(this.lblclickstxt);
            this.Controls.Add(this.lbltime);
            this.Controls.Add(this.lbltimetxt);
            this.Name = "frmCps";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cliques por Segundo";
            this.Load += new System.EventHandler(this.FrmCps_Load);
            this.grpduration.ResumeLayout(false);
            this.grpduration.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvscores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblclicks;
        private System.Windows.Forms.Button btclick;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label lbltime;
        private System.Windows.Forms.GroupBox grpduration;
        private System.Windows.Forms.RadioButton rdo1min;
        private System.Windows.Forms.RadioButton rdo30sec;
        private System.Windows.Forms.RadioButton rdo15sec;
        private System.Windows.Forms.RadioButton rdo10sec;
        private System.Windows.Forms.Button btnscores;
        private System.Windows.Forms.Label lblclickstxt;
        private System.Windows.Forms.Label lbltimetxt;
        private System.Windows.Forms.DataGridView dgvscores;
    }
}

