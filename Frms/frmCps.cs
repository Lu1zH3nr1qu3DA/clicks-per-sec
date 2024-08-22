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
using BLL;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Globalization;

namespace Cps
{
    public partial class frmCps : Form
    {

        static PontuacaoBLL bll = new PontuacaoBLL();
        public static List<PontuacaoMOD> listapontuacao = new List<PontuacaoMOD>();
        static double clicks = 0.00;
        static double tempoi = 0.00;
        static double tempo = 0.00;
        static double cps = 0.00;

        void LimparTela()
        {
            tempo = tempoi;
            clicks = 0;
            lbclicks.Text = "Número de Cliques";
            lbtempo.Text = "Tempo";

            lbclickstxt.Visible = true;
            lbclicks.Visible = false;
            lbtempotxt.Visible = true;
            lbtempo.Visible = false;
        }

        public static void Dados(string nome)
        {
            PontuacaoMOD pontuacao = new PontuacaoMOD();
            pontuacao.Nome = nome;
            pontuacao.Cps = cps;
            pontuacao.Tempo = tempoi;
            pontuacao.DataPontuacao = DateTime.Now;

            listapontuacao.Add(pontuacao);
            bll.Salvar(listapontuacao);
        }
        private void AtualizarPlacar()
        {
            listapontuacao = bll.CarregarPlacar(ref listapontuacao);
            dgvpontuacao.AutoGenerateColumns = true;
            dgvpontuacao.DataSource = listapontuacao;
        }

        public frmCps()
        {
            InitializeComponent();
        }

        private void FormCps_Load(object sender, EventArgs e)
        {
            AtualizarPlacar();
            bll.CarregarPlacar(ref listapontuacao);
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
            gbduracao.Enabled = false;

            lbclickstxt.Visible = false;
            lbclicks.Visible = true;
            lbtempotxt.Visible = false;
            lbtempo.Visible = true;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (tempo > 0)
            {
                tempo = tempo - 100;
                lbtempo.Text = String.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:00,000}", tempo);
            }
            else
            {
                if (tempo == 0)
                {
                    timer.Enabled = false;
                    gbduracao.Enabled = true;
                    cps = Math.Round(clicks / (tempoi / 1000), 2);
                    DialogResult msgresultado = MessageBox.Show($"Sua velocidade de clique foi de {cps}c/s. Gostaria de salvar sua pontuação?", "Resultado", MessageBoxButtons.YesNo);
                    if (msgresultado == DialogResult.Yes)
                    {
                        LimparTela();

                        frmPontuacao frmpontuacao = new frmPontuacao();
                        frmpontuacao.Show();
                    }
                    else
                    {
                        if (msgresultado == DialogResult.No)
                        {
                            LimparTela();
                        }
                    }
                }
            }
        }

        private void btplacar_Click(object sender, EventArgs e)
        {
            AtualizarPlacar();
            if (dgvpontuacao.Visible == false)
            {
                dgvpontuacao.Visible = true;
            }
            else
            {
                if (dgvpontuacao.Visible == true)
                {
                    dgvpontuacao.Visible = false;
                }
            }
        }
    }
}
