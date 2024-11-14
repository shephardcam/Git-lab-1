using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3
{
    public partial class Form1 : Form
    {
        private decimal totalPayments = 0;

        private const int MINYEARS = 5;

        private const string name = "Cameron Shephard";
        public Form1()
        {
            InitializeComponent();
        }
        /* Name: Cameron Shephard
* Date: october 27, 2024
* This program calculates an annuity */

        private void picHelp_Click(object sender, EventArgs e)
        {
            const string helpText = "This program reads in 2 numbers:\n\tFuture Value: amount of \"$\"\n\tYears: must be at least 5\nand calculates payments based on:\n\tYearly interest rate of 7.5%";
            MessageBox.Show(helpText, name);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            string exitText = "Thanks for using the program!\nTotal payments = $" + totalPayments + ".";
            MessageBox.Show(exitText, name);
            Close();
        }
        /* hide solution groupbox reset text boxes and set cursor to top
        */
        private void ResetAll()
        {
            grpSolution.Hide();
            txtFutureValue.Text = string.Empty;
            txtYears.Text = string.Empty;
            txtFutureValue.Focus();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ResetAll();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetAll();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                // Read input values
                decimal futureValue = decimal.Parse(txtFutureValue.Text);
                int years = int.Parse(txtYears.Text);

                // Check if years is valid
                if (years < MINYEARS)
                {
                    MessageBox.Show("Years must be at least " + MINYEARS + ".", name);
                    txtYears.Text = string.Empty;
                    txtYears.Focus();
                    return;
                }

                // Constants
                const decimal interestRate = 0.075m; // 7.5%

                // Calculate the payment
                decimal payment = (futureValue * (interestRate / 12)) / (decimal)(Math.Pow((double)(1 + (interestRate / 12)), years * 12) - 1);


                // Display the result
                lblPaymentAmount.Text = $"Payment Amount:" + Math.Round(payment, 2);

                // Update total payments
                totalPayments += payment;

                // Show the solution group
                grpSolution.Show();
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Message encountered.\nInput string was not in a correct format." + ex.Message, name);
                txtFutureValue.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error encountered");
            }
        }

    }
}
