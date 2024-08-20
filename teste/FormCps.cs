﻿using System;
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
        static int clicks = 0;
        static int tempoi = 0;
        static int tempo = 0;
        static double cps = 0.00;

        public FormCps()
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
                    DialogResult msgresultado = MessageBox.Show("Sua velocidade de clique foi de " + cps + "c/s");
                    if (msgresultado == DialogResult.OK)
                    {
                        tempo = 0;
                    }
                }
            }
        }
    }
}
