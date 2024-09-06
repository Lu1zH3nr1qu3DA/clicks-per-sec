using DataLogic;
using DataModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace Frms
{
    // O frmCps é o formulário principal.
    public partial class frmCps : Form
    {
        public static List<ScoreModel> scorelist = new List<ScoreModel>();    // Lista das pontuações.

        static ScoreLogic score = new ScoreLogic();    // Objeto das operações.

        static BindingSource bsource = new BindingSource();

        static double time = 0.00;    // Contador do tempo do timer.
        static double itime = 0.00;    // O tempo inicial do timer.
        static double clicks = 0.00;    // Contador dos cliques.
        static double cps = 0.00;    // Resultado dos c/s.

        static int scoreid = 0;    // Id da pontuação.

        static char operation;    // Define a operação.

        // TODO: Continue a comentar...

        void ResetScreen()
        {
            time = itime;
            clicks = 0;

            lblclickstxt.Visible = true;
            lbltimetxt.Visible = true;
            lblclicks.Visible = false;
            lbltime.Visible = false;
        }
        private void ShowScores()
        {
            scorelist = score.Load(ref scorelist);

            bsource.DataSource = scorelist;

            dgvscores.DataSource = bsource;

            dgvscores.AutoGenerateColumns = true;
            dgvscores.Columns["Name"].HeaderText = "Nome";
            dgvscores.Columns["Name"].Width = 304;
            dgvscores.Columns["Cps"].HeaderText = "c/s";
            dgvscores.Columns["Cps"].Width = 116;
            dgvscores.Columns["Cps"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvscores.Columns["Time"].HeaderText = "Duração (s)";
            dgvscores.Columns["Time"].Width = 116;
            dgvscores.Columns["Time"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvscores.Columns["ScoreDt"].HeaderText = "Data";
            dgvscores.Columns["ScoreDt"].Width = 172;
            dgvscores.Columns["ScoreDt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        public static void ExecuteOperation(string name = "")
        {
            switch (operation)
            {
                case 'S':
                    ScoreModel newscore = new ScoreModel();

                    newscore.Name = name;
                    newscore.Cps = cps.ToString();
                    newscore.Time = (itime / 1000).ToString();
                    newscore.ScoreDt = DateTime.Now.ToString();

                    scorelist.Add(newscore);

                    score.Save(scorelist);
                    
                    bsource.ResetBindings(false);
                    break;
                case 'R':
                    score.Rename(ref scorelist, ref scoreid, name);
                    
                    bsource.ResetBindings(false);
                    break;
                case 'D':
                    score.Delete(ref scorelist, ref scoreid);
                    
                    bsource.ResetBindings(false);
                    break;
            }
        }

        public frmCps()
        {
            InitializeComponent();
            
            itime = 15000;
            time = itime;
        }

        private void rdo10sec_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo10sec.Checked)
            {
                itime = 10000;
                time = itime;
            }
        }
        private void rdo15sec_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo15sec.Checked)
            {
                itime = 15000;
                time = itime;
            }
        }
        private void rdo30sec_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo30sec.Checked)
            {
                itime = 30000;
                time = itime;
            }
        }
        private void rdo1min_CheckedChanged(object sender, EventArgs e)
        {
            if (rdo1min.Checked)
            {
                itime = 60000;
                time = itime;
            }
        }

        private void btnclick_Click(object sender, EventArgs e)
        {
            clicks++;
            lblclicks.Text = clicks.ToString();
            if (clicks <= 1)
            {
                timer.Enabled = true;
                grpduration.Enabled = false;
                btnscores.Enabled = false;
                dgvscores.Enabled = false;
                lblclickstxt.Visible = false;
                lblclicks.Visible = true;
                lbltimetxt.Visible = false;
                lbltime.Visible = true;
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (time > 0)
            {
                time = time - 100;
                lbltime.Text = String.Format(CultureInfo.GetCultureInfo("en-US"), "{0:00,000}", time);
            }
            else
            {
                if (time == 0)
                {
                    timer.Enabled = false;
                    grpduration.Enabled = true;
                    btnscores.Enabled = true;
                    dgvscores.Enabled = true;

                    cps = Math.Round(clicks / (itime / 1000), 2);

                    DialogResult msgresult = MessageBox.Show($"Sua velocidade de clique foi de {cps}c/s. Gostaria de salvar sua pontuação?", "Resultado", MessageBoxButtons.YesNo);
                    if (msgresult == DialogResult.Yes)
                    {
                        ResetScreen();

                        operation = 'S';

                        frmSaveScore frmscore = new frmSaveScore();
                        frmscore.Show();
                    }
                    else
                    {
                        if (msgresult == DialogResult.No)
                        {
                            ResetScreen();
                        }
                    }
                }
            }
        }

        private void btnscores_Click(object sender, EventArgs e)
        {
            ShowScores();
            if (dgvscores.Visible == false)
            {

                // TODO: Continua
                dgvscores.Visible = true;
                dgvscores.Enabled = true;

                btnscores.Text = "Fechar";

                btnrename.Visible = true;
                btndelete.Visible = true;
            }
            else
            {
                if (dgvscores.Visible == true)
                {
                    dgvscores.Visible = false;
                    dgvscores.Enabled = false;

                    btnscores.Text = "Placar";

                    btnrename.Enabled = false;
                    btnrename.Visible = false;
                    btndelete.Enabled = false;
                    btndelete.Visible = false;
                }
            }
        }

        private void dgvscores_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvscores.RowCount != 0)
            {
                if (dgvscores.CurrentCell.ColumnIndex == 0)
                {
                    scoreid = dgvscores.CurrentCell.RowIndex;
                    btndelete.Enabled = false;
                    btnrename.Enabled = true;
                }
                else
                {
                    btndelete.Enabled = false;
                    btnrename.Enabled = false;
                }
            }
        }
        private void dgvscores_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            scoreid = dgvscores.CurrentRow.Index;
            btndelete.Enabled = true;
            btnrename.Enabled = true;
        }

        private void btnrename_Click(object sender, EventArgs e)
        {
            operation = 'R';
            frmSaveScore frmname = new frmSaveScore();
            frmname.Show();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            DialogResult msgresult = MessageBox.Show($"Você tem certeza que deseja excluir?", "Excluir", MessageBoxButtons.YesNo);
            if (msgresult == DialogResult.Yes)
            {
                operation = 'D';
                ExecuteOperation();    // TODO: Resolver a questão dos botões que não desabilitam!
                if (dgvscores.RowCount == 0)
                {
                    btndelete.Enabled = false;
                    btnrename.Enabled = false;
                }
            }

        }
    }
}