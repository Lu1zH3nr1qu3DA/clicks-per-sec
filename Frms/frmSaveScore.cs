using Cps;
using System;
using System.Windows.Forms;

namespace Frms
{
    public partial class frmScore : Form
    {
        public frmScore()
        {
            InitializeComponent();
        }

        private void btsalvar_Click(object sender, EventArgs e)
        {
            string nome = tbnome.Text;
            frmCps.SaveData(nome);
            Close();
        }

        private void frmPontuacao_Load(object sender, EventArgs e)
        {
            btsalvar.Focus();
        }
    }
}
