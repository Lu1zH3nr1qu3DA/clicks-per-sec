using System;
using System.Windows.Forms;

namespace Frms
{
    public partial class frmSaveScore : Form
    {
        public frmSaveScore()
        {
            InitializeComponent();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            string name = txtname.Text;
            frmCps.ExecuteOperation(name);
            Close();
        }
    }
}
