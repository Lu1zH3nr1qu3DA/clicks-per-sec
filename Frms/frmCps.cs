using Frms;
using DataLogic;
using DataModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace Cps
{
    public partial class frmCps : Form
    {
        static ScoreLogic score = new ScoreLogic();

        public static List<ScoreModel> scorelist = new List<ScoreModel>();

        static char operation;

        static int scoreid = 0;

        static double clicks = 0.00;
        static double itime = 0.00;
        static double time = 0.00;
        static double cps = 0.00;

        void ResetScreen()
        {
            time = itime;
            clicks = 0;
            lblclicks.Text = "Número de Cliques";
            lbltime.Text = "Tempo";

            lblclickstxt.Visible = true;
            lbltimetxt.Visible = true;
            lblclicks.Visible = false;
            lbltime.Visible = false;
        }
        private void ShowScores()
        {
            scorelist = score.Load(ref scorelist);

            dgvscores.DataSource = scorelist;
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
        public void RefreshDgv()
        {
            if (dgvscores.Visible && dgvscores.Enabled)
            {
                dgvscores.Visible = false;
                dgvscores.Enabled = false;
                dgvscores.Visible = true;
                dgvscores.Enabled = true;
            }
            else
            {
                if (dgvscores.Visible == false &&  dgvscores.Enabled == false)
                {
                    dgvscores.Visible = true;
                    dgvscores.Enabled = true;
                    dgvscores.Visible = false;
                    dgvscores.Enabled = false;
                }
            }
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
                    break;
                case 'R':
                    score.Rename(ref scorelist, ref scoreid, name);
                    break;
                case 'D':
                    score.Delete(ref scorelist, ref scoreid);
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
                        RefreshDgv();
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
            ShowScores();
            RefreshDgv();
        }
        private void btndelete_Click(object sender, EventArgs e)
        {
            DialogResult msgresult = MessageBox.Show($"Você tem certeza que deseja excluir?", "Excluir", MessageBoxButtons.YesNo);
            if (msgresult == DialogResult.Yes)
            {
                operation = 'D';
                ExecuteOperation();
                ShowScores();
                RefreshDgv();
            }
        }
    }
}