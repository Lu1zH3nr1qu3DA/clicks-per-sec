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
        static DateTime datapontuacao = DateTime.MinValue;

        void LimparTela()
        {
            tempo = tempoi;
            clicks = 0;
            lbclicks.Text = "Número de Cliques";
            lbtempo.Text = "Tempo";
        }

        public static void Dados(ref string nome)
        {
            datapontuacao = DateTime.Now;

            PontuacaoMOD pontuacao = new PontuacaoMOD(ref nome, ref cps, ref tempoi, ref datapontuacao);
            listapontuacao.Add(pontuacao);
            bll.Salvar(listapontuacao);
        }
        private void AtualizarPlacar()
        {
            lstpontuacao.Items.Clear();
            foreach (var pontuacao in listapontuacao)
            {
                lstpontuacao.Items.Add(pontuacao.ToString());
            }
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
            if (lstpontuacao.Visible == false)
            {
                lstpontuacao.Visible = true;
            }
            else
            {
                if (lstpontuacao.Visible == true)
                {
                    lstpontuacao.Visible = false;
                }
            }
        }
    }
}
