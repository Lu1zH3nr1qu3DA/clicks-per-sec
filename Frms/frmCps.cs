using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Cps
{
    public partial class frmCps : Form
    {
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

            lblclicks.Visible = false;
            lbltime.Visible = false;
            lblclickstxt.Visible = true;
            lbltimetxt.Visible = true;
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
            lblclicks.Visible = true;
            lbltime.Visible = true;
            lblclickstxt.Visible = false;
            lbltimetxt.Visible = false;

            clicks++;
            lblclicks.Text = clicks.ToString();

            timer.Enabled = true;
            grpduration.Enabled = false;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (time > 0)
            {
                time = time - 100;
                lbltime.Text = String.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:00,000}", time);
                lbltime.TextAlign = ContentAlignment.MiddleCenter;
            }
            else
            {
                if (time == 0)
                {
                    timer.Enabled = false;
                    grpduration.Enabled = true;

                    cps = Math.Round(clicks / (itime / 1000), 2);
                    
                    DialogResult msgresult = MessageBox.Show($"Sua velocidade de clique foi de {cps}c/s.", "Resultado");
                    if (msgresult == DialogResult.OK)
                    {
                        ClearScreen();
                    }
                }
            }
        }
    }
}
