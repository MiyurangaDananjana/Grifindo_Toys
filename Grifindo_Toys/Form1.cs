using Grifindo_Toys.DAL;
using Grifindo_Toys.UI;
using System;
using System.Windows.Forms;

namespace Grifindo_Toys
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text;
            string Password = txtPassword.Text;
            if (string.IsNullOrEmpty(userName))
            {
                MessageBox.Show("Please enter a valid username.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(Password))
            {
                MessageBox.Show("Please enter a valid password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }

            if (User.Login(userName, Password))
            {
                this.Hide();
                frmMain frm = new frmMain();
                frm.ShowDialog();
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Please enter a valid Data.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
