using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grifindo_Toys.UI
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmEmployeeProfile frm = new frmEmployeeProfile();
            frm.ShowDialog();
            this.Dispose();
        }

        private void btnSalary_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmSalaryComponent frm = new frmSalaryComponent();
            frm.ShowDialog();
            this.Dispose();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 frm = new Form1();
            frm.ShowDialog();
            this.Dispose();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }
    }
}
