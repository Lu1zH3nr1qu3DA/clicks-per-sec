using DataLogic;
using Frms;
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
        private void LoadScores()
        {
            scorelist = score.LoadScores(ref scorelist);

            dgvscores.DataSource = scorelist;
            dgvscores.AutoGenerateColumns = true;
            dgvscores.Columns["Name"].HeaderText = "Nome";
            dgvscores.Columns["Name"].Width = 304;
            dgvscores.Columns["Cps"].HeaderText = "c/s";
            dgvscores.Columns["Cps"].Width = 104;
            dgvscores.Columns["Cps"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvscores.Columns["Time"].HeaderText = "Duração (s)";
            dgvscores.Columns["Time"].Width = 104;
            dgvscores.Columns["Time"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvscores.Columns["ScoreDt"].HeaderText = "Data";
            dgvscores.Columns["ScoreDt"].Width = 172;
            dgvscores.Columns["ScoreDt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvscores.Refresh();
        }
        public static void SaveData(string name)
        {
            ScoreModel score = new ScoreModel();

            score.Name = name;
            score.Cps = cps.ToString();
            score.Time = (itime / 1000).ToString();
            score.ScoreDt = DateTime.Now.ToString();
            
            scorelist.Add(score);
            frmCps.score.Save(scorelist);
        }
        public void RemoveData(ref int scoreid)
        {
            ScoreModel delscore = new ScoreModel();
            delscore = scorelist[scoreid];

            ScoreLogic score = new ScoreLogic();
            score.Delete(delscore, scorelist);
        }
        public void UpdateData()
        {

        }

        public frmCps()
        {
            InitializeComponent();
        }

        private void FrmCps_Load(object sender, EventArgs e)
        {
            LoadScores();
            if (rdo10sec.Checked)
            {
                itime = 10000;
                time = itime;
            }
            else
            {
                if (rdo15sec.Checked)
                {
                    itime = 15000;
                    time = itime;
                }
                else
                {
                    if (rdo30sec.Checked)
                    {
                        itime = 30000;
                        time = itime;
                    }
                    else
                    {
                        if (rdo1min.Checked)
                        {
                            itime = 60000;
                            time = itime;
                        }
                    }
                }
            }
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
                lbltime.Text = String.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:00,000}", time);
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

                        frmScore frmscore = new frmScore();
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
            LoadScores();
            if (dgvscores.Visible == false)
            {
                dgvscores.Visible = true;
                dgvscores.Enabled = true;
            }
            else
            {
                if (dgvscores.Visible == true)
                {
                    dgvscores.Visible = false;
                    dgvscores.Enabled = false;
                }
            }
        }
    }
}
