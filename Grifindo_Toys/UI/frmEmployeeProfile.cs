using Grifindo_Toys.DAL;
using Grifindo_Toys.Models;
using System;
using System.Windows.Forms;

namespace Grifindo_Toys.UI
{
    public partial class frmEmployeeProfile : Form
    {
        public frmEmployeeProfile()
        {
            InitializeComponent();
        }

        private void frmEmployeeProfile_Load(object sender, EventArgs e)
        {
            this.LoadCmb();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidateInputFields())
            {
                if (txtPassword.Text == txtConfirmPassword.Text)
                {
                    MessageBox.Show("Password does not match", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                UserModels userModels = new UserModels
                {
                    FullName = txtFullName.Text,
                    dob = dpDob.Value,
                    Address = txtAddress.Text,
                    UserName = txtUserName.Text,
                    Password = txtPassword.Text,
                    UserRoleId = (int)cmbUserRole.SelectedValue,
                    MonthlySalary = Convert.ToDecimal(txtMonthlySalary.Text),
                    OverTimeRate = Convert.ToDecimal(txtOverTimeRate.Text),
                    Allowances = Convert.ToDecimal(txtAllowances.Text)
                };
                if (User.AddNewUserData(userModels))
                {
                    MessageBox.Show("\"Message\", \"Success full add\"");
                }
                else
                {
                    MessageBox.Show("\"Message\", \"Fail\"");
                }
            }          
        }

        private void LoadCmb()
        {
            cmbUserRole.DataSource = User.GetUserRole();
            cmbUserRole.ValueMember = "RoleId";
            cmbUserRole.DisplayMember = "RoleName";

            dataGridView1.DataSource = User.GetUserDetail();
            dataGridView1.Columns[0].HeaderText = "EmpId";
            dataGridView1.Columns[1].HeaderText = "FullName";
            dataGridView1.Columns[2].HeaderText = "Dob";
            dataGridView1.Columns[3].HeaderText = "Address";
            dataGridView1.Columns[4].HeaderText = "UserName";
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].HeaderText = "Role";
            dataGridView1.Columns[8].HeaderText = "MonthlySalary";
            dataGridView1.Columns[9].HeaderText = "OverTimeRate";
            dataGridView1.Columns[10].HeaderText = "Allowances";
        }

        private bool ValidateInputFields()
        {
            if (string.IsNullOrEmpty(txtFullName.Text))
            {
                MessageBox.Show("Please enter a valid Full Name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (dpDob.Value == DateTime.MinValue) 
            {
                MessageBox.Show("Please select a valid Date of Birth.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(txtAddress.Text))
            {
                MessageBox.Show("Please enter a valid Address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                MessageBox.Show("Please enter a valid User Name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Please enter a valid Password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (cmbUserRole.SelectedValue == null)
            {
                MessageBox.Show("Please select a valid User Role.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(txtMonthlySalary.Text) || !decimal.TryParse(txtMonthlySalary.Text, out _))
            {
                MessageBox.Show("Please enter a valid Monthly Salary.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(txtOverTimeRate.Text) || !decimal.TryParse(txtOverTimeRate.Text, out _))
            {
                MessageBox.Show("Please enter a valid Overtime Rate.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(txtAllowances.Text) || !decimal.TryParse(txtAllowances.Text, out _))
            {
                MessageBox.Show("Please enter valid Allowances.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true; 
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtFullName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMain main = new frmMain();
            main.ShowDialog();
            this.Dispose();


        }
    }
}
