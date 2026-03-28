using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fariscal_IT_201_Midterm_LabActivity1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            textBox2.ReadOnly = true;
            textBox5.ReadOnly = true;
            textBox8.ReadOnly = true;
            textBox11.ReadOnly = true;
            textBox13.ReadOnly = true;
            textBox14.ReadOnly = true;
            textBox15.ReadOnly = true;
            textBox16.ReadOnly = true;
            textBox17.ReadOnly = true;
            textBox20.ReadOnly = true;
            textBox21.ReadOnly = true;
            textBox22.ReadOnly = true;
            textBox23.ReadOnly = true;
            textBox24.ReadOnly = true;
            textBox25.ReadOnly = true;
            textBox32.ReadOnly = true;
        }

        private void label33_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // First: Check if fields are empty (nested)
            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Please fill Basic Income Rate.");
            }
            else if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Please fill Basic Income Hours.");
            }
            else
            {
                if (string.IsNullOrWhiteSpace(textBox6.Text))
                {
                    MessageBox.Show("Please fill Honorarium Rate.");
                }
                else if (string.IsNullOrWhiteSpace(textBox7.Text))
                {
                    MessageBox.Show("Please fill Honorarium Hours.");
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(textBox9.Text))
                    {
                        MessageBox.Show("Please fill Other Income Rate.");
                    }
                    else if (string.IsNullOrWhiteSpace(textBox10.Text))
                    {
                        MessageBox.Show("Please fill Other Income Hours.");
                    }
                    else
                    {
                        // Second: Check if all inputs are valid numbers
                        if (double.TryParse(textBox3.Text.Trim(), out double num1) &&
                            double.TryParse(textBox4.Text.Trim(), out double num2) &&
                            double.TryParse(textBox6.Text.Trim(), out double num3) &&
                            double.TryParse(textBox7.Text.Trim(), out double num4) &&
                            double.TryParse(textBox9.Text.Trim(), out double num5) &&
                            double.TryParse(textBox10.Text.Trim(), out double num6))
                        {
                            // Basic Income
                            double basicIncome = num1 * num2;
                            textBox5.Text = basicIncome.ToString();

                            // Honorarium Income
                            double honorariumIncome = num3 * num4;
                            textBox8.Text = honorariumIncome.ToString();

                            // Other Income
                            double otherIncome = num5 * num6;
                            textBox11.Text = otherIncome.ToString();

                            // Total Gross Income
                            double grossIncome = basicIncome + honorariumIncome + otherIncome;
                            textBox12.Text = grossIncome.ToString();

                            // SSS Contribution
                            double sssContribution = grossIncome * 0.15;
                            textBox22.Text = sssContribution.ToString();

                            // PhilHealth Contribution
                            double philHealthContribution = grossIncome * 0.05; // FIXED (was 0.5 = 50%)
                            textBox23.Text = philHealthContribution.ToString();

                            // Pag-IBIG Contribution
                            textBox24.Text = "200.00";

                            // Income Tax
                            double annualGrossIncome = grossIncome * 12;
                            double tax;

                            if (annualGrossIncome <= 250000)
                                tax = 0;
                            else if (annualGrossIncome <= 400000)
                                tax = annualGrossIncome * 0.15;
                            else if (annualGrossIncome <= 800000)
                                tax = annualGrossIncome * 0.20;
                            else if (annualGrossIncome <= 2000000)
                                tax = annualGrossIncome * 0.25;
                            else if (annualGrossIncome <= 8000000)
                                tax = annualGrossIncome * 0.30;
                            else
                                tax = annualGrossIncome * 0.35;

                            textBox25.Text = tax.ToString();
                        }
                        else
                        {
                            MessageBox.Show("Please enter valid numeric values.");
                        }
                    }
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            // Regular Deductions
            double sssContribution = Convert.ToDouble(textBox22.Text);
            double philHealthContribution = Convert.ToDouble(textBox23.Text);
            double pagIbigContribution = Convert.ToDouble(textBox24.Text);
            double incomeTaxContribution = Convert.ToDouble(textBox25.Text);

            // Other Deductions 
            double sssLoan = Convert.ToDouble(textBox26.Text);
            double pagIbigLoan = Convert.ToDouble(textBox27.Text);
            double facultySavingsDeposit = Convert.ToDouble(textBox28.Text);
            double facultySavingsLoan = Convert.ToDouble(textBox29.Text);
            double salaryLoan = Convert.ToDouble(textBox30.Text);
            double otherLoans = Convert.ToDouble(textBox31.Text);

            // Total Deductions
            double totalDeductions = new double[] {
                sssContribution, philHealthContribution, pagIbigContribution,
                incomeTaxContribution, sssLoan, pagIbigLoan,
                facultySavingsDeposit, facultySavingsLoan, salaryLoan, otherLoans
            }.Sum();

            textBox32.Text = totalDeductions.ToString();

            // Net Income
            double grossIncome = Convert.ToDouble(textBox12.Text);
            double netIncome = grossIncome - totalDeductions;
            textBox13.Text = netIncome.ToString();
        }
            
        private void button3_Click(object sender, EventArgs e)
        {
            // First, sum textBox22–25
            if (double.TryParse(textBox22.Text, out double v1) &&
                double.TryParse(textBox23.Text, out double v2) &&
                double.TryParse(textBox24.Text, out double v3) &&
                double.TryParse(textBox25.Text, out double v4) &&

                // Sum textBox26–31
                double.TryParse(textBox26.Text, out double w1) &&
                double.TryParse(textBox27.Text, out double w2) &&
                double.TryParse(textBox28.Text, out double w3) &&
                double.TryParse(textBox29.Text, out double w4) &&
                double.TryParse(textBox30.Text, out double w5) &&
                double.TryParse(textBox31.Text, out double w6))
            {
                double totalContributions = v1 + v2 + v3 + v4;
                double totalAdditional = w1 + w2 + w3 + w4 + w5 + w6;

                // Pass all values to Form2
                Form2 form2 = new Form2(
                    textBox5.Text,                        // Basic Income
                    textBox8.Text,                        // Honorarium
                    textBox11.Text,                       // Other Income
                    textBox12.Text,                       // Gross Income
                    totalContributions.ToString("N2"),    // Sum 22–25
                    totalAdditional.ToString("N2"),        // Sum 26–31
                    textBox32.Text,
                    textBox13.Text
                );

                form2.Show();
            }
            else
            {
                MessageBox.Show("Invalid values detected. Please check textBox22–31.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
            "Are you sure you want to create a new record?",
            "Confirmation",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

            if (result == DialogResult.Yes) {
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();
                textBox9.Clear();
                textBox10.Clear();
                textBox11.Clear();
                textBox12.Clear();
                textBox13.Clear();
                textBox14.Clear();
                textBox15.Clear();
                textBox16.Clear();
                textBox17.Clear();
                textBox18.Clear();
                textBox19.Clear();
                textBox20.Clear();
                textBox21.Clear();
                textBox22.Clear();
                textBox23.Clear();
                textBox24.Clear();
                textBox25.Clear();
                textBox26.Clear();
                textBox27.Clear();
                textBox28.Clear();
                textBox29.Clear();
                textBox30.Clear();
                textBox31.Clear();
                textBox32.Clear();
                textBox1.Focus();
            }
        }
    }
}
