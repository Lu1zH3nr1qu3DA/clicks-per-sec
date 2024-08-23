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

        static ScoreLogic logic = new ScoreLogic();

        public static List<ScoreModel> scorelist = new List<ScoreModel>();

        static double clicks = 0.00;
        static double itime = 0.00;
        static double time = 0.00;
        static double cps = 0.00;

        void ClearScreen()
        {
            time = itime;
            clicks = 0;
            lblclicks.Text = "Número de Cliques";
            lbltime.Text = "Tempo";

            lblclickstxt.Visible = true;
            lblclicks.Visible = false;
            lbltimetxt.Visible = true;
            lbltime.Visible = false;
        }

        public static void SaveData(string name)
        {
            ScoreModel score = new ScoreModel();
            score.Name = name;
            score.Cps = cps.ToString();
            score.Time = Math.Round(Convert.ToDouble(String.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:00,000}", itime)), 0).ToString();
            score.ScoreDt = DateTime.Now.ToString();
            scorelist.Add(score);
            logic.Save(scorelist);
        }
        public void LoadScores()
        {
            scorelist = logic.LoadScores(ref scorelist);
            dgvscores.DataSource = scorelist;
            dgvscores.AutoGenerateColumns = true;
            dgvscores.Columns["Name"].HeaderText = "Nome";
            dgvscores.Columns["Cps"].HeaderText = "c/s";
            dgvscores.Columns["Time"].HeaderText = "Duração (s)";
            dgvscores.Columns["ScoreDt"].HeaderText = "Data";
            dgvscores.AutoResizeColumns();
        }
        public void UpdateScores()
        {
            LoadScores();
            dgvscores.Refresh();
        }

        public frmCps()
        {
            InitializeComponent();
        }

        private void FrmCps_Load(object sender, EventArgs e)
        {
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
            timer.Enabled = true;
            grpduration.Enabled = false;
            btnscores.Enabled = false;
            dgvscores.Enabled = false;
            lblclickstxt.Visible = false;
            lblclicks.Visible = true;
            lbltimetxt.Visible = false;
            lbltime.Visible = true;
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
                        ClearScreen();

                        frmScore frmscore = new frmScore();
                        frmscore.Show();
                    }
                    else
                    {
                        if (msgresult == DialogResult.No)
                        {
                            ClearScreen();
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
