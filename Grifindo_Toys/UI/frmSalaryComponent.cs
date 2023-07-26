using Grifindo_Toys.DAL;
using Grifindo_Toys.Models;
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
    public partial class frmSalaryComponent : Form
    {
        public frmSalaryComponent()
        {
            InitializeComponent();
        }

        private void frmSalaryComponent_Load(object sender, EventArgs e)
        {
            this.LoadCombData();

        }

        private bool isCmbBox = false;

        private decimal totalSalary;
        private int salaryCycleDateRange;
        private int numberOfAbsentDays;
        private decimal allowances;
        private decimal overTimeRate;
        private int noOfOvertimeHours;
        private decimal govermentTaxRate;

        private void LoadCombData()
        {
            cmbFullName.DataSource = Salary.GetUserData();
            cmbFullName.ValueMember = "UserId";
            cmbFullName.DisplayMember = "FullName";
            cmbFullName.SelectedIndex = -1;
            isCmbBox = true;
        }

        private void cmbFullName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isCmbBox)
            {
                int selectedId = (int)cmbFullName.SelectedValue;
                txtId.Text = selectedId.ToString();
                SalaryDetails salary = Salary.GetEmployeeSalaryDetails(selectedId);
                txtMonthlySalary.Text = salary.MonthlySalary.ToString();
                totalSalary = (decimal)salary.MonthlySalary;
                txtOverTimeRate.Text = salary.OverTimeRate.ToString();
                overTimeRate = (decimal)salary.OverTimeRate;
                txtAllowances.Text = salary.Allowances.ToString();
                allowances = (decimal)salary.Allowances;
            }
        }

        private void dpToDate_CloseUp(object sender, EventArgs e)
        {
            DateTime fromDate = dpFromDate.Value;
            DateTime toDate = dpToDate.Value;
            // Check if the dates are valid (e.g., not DateTime.MinValue or DateTime.MaxValue)
            if (fromDate == DateTime.MinValue || toDate == DateTime.MinValue || fromDate == DateTime.MaxValue || toDate == DateTime.MaxValue)
            {
                lblDates.Text = "Invalid date";
            }
            else
            {
                // Check if toDate is not before fromDate
                if (toDate >= fromDate)
                {
                    TimeSpan difference = toDate - fromDate;
                    if (difference.Days <= 30)
                    {
                        lblDates.Text = $"{difference.Days} days";
                        salaryCycleDateRange = difference.Days;
                    }
                    else
                    {
                        lblDates.Text = "Invalid date range. More than 30 days";
                    }
                }
                else
                {
                    lblDates.Text = "Invalid date range";
                }
            }
        }
        private void isCalculateButtonTrue()
        {
            if (string.IsNullOrEmpty(txtOvertimeHours.Text) && string.IsNullOrEmpty(txtLeaveDate.Text))
            {
                btnCalculate.Enabled = false;
            }
            else
            {
                btnCalculate.Enabled = true;
            }
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (salaryCycleDateRange == 0)
            {
                MessageBox.Show("Please enter valid values in Date.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (int.TryParse(txtLeaveDate.Text, out int numberOfAbsentDays) &&
               int.TryParse(txtOvertimeHours.Text, out int noOfOvertimeHours) &&
               decimal.TryParse(txtGovTaxtRate.Text, out decimal govermentTaxRate))
                {
                    decimal noPayValue;
                    decimal basePayValue;
                    decimal grossPay;

                    govermentTaxRate = govermentTaxRate / 100;

                    noPayValue = (totalSalary / salaryCycleDateRange) * numberOfAbsentDays;
                    lblNoPayValue.Text = noPayValue.ToString("N2");

                    basePayValue = totalSalary + allowances + (overTimeRate * noOfOvertimeHours);
                    lblBasePayValue.Text = basePayValue.ToString();

                    grossPay = basePayValue - (noPayValue + basePayValue * govermentTaxRate);
                    lblGrossPay.Text = grossPay.ToString("N2");
                }
                else
                {
                    // Display an error message in the UI for invalid or empty input fields
                    MessageBox.Show("Please enter valid values in all the input fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }



        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMain frm = new frmMain();
            frm.ShowDialog();
            this.Dispose();

        }
    }
}
