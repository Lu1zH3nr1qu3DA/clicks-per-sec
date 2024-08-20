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

namespace teste
{
    public partial class FormCps : Form
    {
        int clicks = 0;
        int tempoi = 15000;
        int tempo = 0;
        double cps = 0;

        public FormCps()
        {
            InitializeComponent();
        }

        private void FormCps_Load(object sender, EventArgs e)
        {
            tempo = tempoi;
        }

        private void rb10seg_CheckedChanged(object sender, EventArgs e)
        {
            if (rb10seg.Checked)
            {
                tempoi = 10000;
            }
        }

        private void rb15seg_CheckedChanged(object sender, EventArgs e)
        {
            if (rb15seg.Checked)
            {
                tempoi = 15000;
            }
        }

        private void rb30seg_CheckedChanged(object sender, EventArgs e)
        {
            if (rb30seg.Checked)
            {
                tempoi = 30000;
            }
        }

        private void rb1min_CheckedChanged(object sender, EventArgs e)
        {
            if (rb1min.Checked)
            {
                tempoi = 60000;
            }
        }

        private void btclick_Click(object sender, EventArgs e)
        {
            clicks++;
            lbclicks.Text = clicks.ToString();
            timer.Enabled = true;
            if (tempo == 0)
            {
                cps = clicks / (tempoi / 1000);
                MessageBox.Show("Sua velocidade de clique é de " + cps + "c/s");
                tempo--;
                Close();
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (tempo > 0)
            {
                tempo = tempo - 100;
                lbtempo.Text = String.Format("{00:000}", tempo);
            }
        }
    }
}
