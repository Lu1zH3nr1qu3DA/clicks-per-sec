using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cps;
using MOD;

namespace Frms
{
    public partial class frmPontuacao : Form
    {
        public frmPontuacao()
        {
            InitializeComponent();
        }

        private void btsalvar_Click(object sender, EventArgs e)
        {
            string nome = tbnome.Text;
            frmCps.Dados(nome);
            Close();
        }

        private void frmPontuacao_Load(object sender, EventArgs e)
        {
            btsalvar.Focus();
        }
    }
}
