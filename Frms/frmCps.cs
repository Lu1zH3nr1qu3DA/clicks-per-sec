using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Diagnostics;
using System.Windows.Forms;
using Frms;
using MOD;

namespace Cps
{
    public partial class frmCps : Form
    {
        static double clicks = 0.00;
        static double tempoi = 0.00;
        static double tempo = 0.00;
        static double cps = 0.00;

        public frmCps()
        {
            InitializeComponent();
        }

        private void FormCps_Load(object sender, EventArgs e)
        {
            if (rb10seg.Checked)
            {
                tempoi = 10000;
                tempo = tempoi;
            }
            else
            {
                if (rb15seg.Checked)
                {
                    tempoi = 15000;
                    tempo = tempoi;
                }
                else
                {
                    if (rb30seg.Checked)
                    {
                        tempoi = 30000;
                        tempo = tempoi;
                    }
                    else
                    {
                        if (rb1min.Checked)
                        {
                            tempoi = 60000;
                            tempo = tempoi;
                        }
                    }
                }
            }
        }

        private void rb10seg_CheckedChanged(object sender, EventArgs e)
        {
            if (rb10seg.Checked)
            {
                tempoi = 10000;
                tempo = tempoi;
            }
        }

        private void rb15seg_CheckedChanged(object sender, EventArgs e)
        {
            if (rb15seg.Checked)
            {
                tempoi = 15000;
                tempo = tempoi;
            }
        }

        private void rb30seg_CheckedChanged(object sender, EventArgs e)
        {
            if (rb30seg.Checked)
            {
                tempoi = 30000;
                tempo = tempoi;
            }
        }

        private void rb1min_CheckedChanged(object sender, EventArgs e)
        {
            if (rb1min.Checked)
            {
                tempoi = 60000;
                tempo = tempoi;
            }
        }

        private void btclick_Click(object sender, EventArgs e)
        {
            clicks++;
            lbclicks.Text = clicks.ToString();
            timer.Enabled = true;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (tempo > 0)
            {
                tempo = tempo - 100;
                lbtempo.Text = String.Format("{00:000}", tempo);
            }
            else
            {
                if (tempo == 0)
                {
                    timer.Enabled = false;
                    cps = clicks / (tempoi / 1000);
                    DialogResult msgresultado = MessageBox.Show("Sua velocidade de clique foi de " + Math.Round(cps, 2) + "c/s. Gostaria de salvar sua pontuação?", "Resultado", MessageBoxButtons.YesNo);
                    if (msgresultado == DialogResult.Yes)
                    {
                        tempo = tempoi;
                        clicks = 0;
                        lbclicks.Text = "Número de Cliques";
                        lbtempo.Text = "Tempo";
                        frmPontuacao frmpontuacao = new frmPontuacao();
                        PontuacaoMOD pontuacao = new PontuacaoMOD();
                        pontuacao.Cps = cps;
                        pontuacao.Tempo = DateTime.Now;
                        frmpontuacao.Show();
                    }
                    else
                    {
                        if (msgresultado == DialogResult.No)
                        {
                            tempo = tempoi;
                            clicks = 0;
                            lbclicks.Text = "Número de Cliques";
                            lbtempo.Text = "Tempo";
                        }
                    }
                }
            }
        }
    }
}
