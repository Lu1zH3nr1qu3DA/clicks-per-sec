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

        private void btnsave_Click(object sender, EventArgs e)
        {
            string name = txtname.Text;
            frmCps.SaveData(name);
            Close();
        }

        private void frmSaveScore_Load(object sender, EventArgs e)
        {
            txtname.Focus();
        }
    }
}
