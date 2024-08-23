using Cps;
using System;
using System.Windows.Forms;

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
