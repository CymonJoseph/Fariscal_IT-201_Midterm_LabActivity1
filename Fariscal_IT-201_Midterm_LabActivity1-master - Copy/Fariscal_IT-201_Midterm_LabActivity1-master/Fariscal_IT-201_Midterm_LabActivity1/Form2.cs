using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fariscal_IT_201_Midterm_LabActivity1
{
    public partial class Form2 : Form
    {
        public Form2(string basicIncome, string honorariumIncome, string otherIncome, string grossIncome, string totalRegularDeductions, string totalOtherDeductions, string totalDeductionSummary, string netPay)
        {
            InitializeComponent();

            label7.Text = basicIncome;       // from textBox5
            label8.Text = honorariumIncome;  // from textBox8
            label9.Text = otherIncome;       // from textBox11
            label10.Text = grossIncome;      // from textBox12
            label13.Text = totalRegularDeductions;  // sum of textBox22–25
            label14.Text = totalOtherDeductions;   // sum of 26–31
            label16.Text = totalDeductionSummary;
            label18.Text = grossIncome; 
            label21.Text = totalDeductionSummary;
            label22.Text = netPay;

        }

        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
