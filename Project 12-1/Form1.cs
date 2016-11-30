using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_12_1
{
    public partial class Form1 : Form
    {
        Double resultValue = 0; //initialize value for textbox
        String operationPerformed = ""; 
        bool isOperationPerformed = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void button_click(object sender, EventArgs e)
        {
            if ((txtResult.Text == "0") || (isOperationPerformed))
                txtResult.Clear();
            isOperationPerformed = false;
            Button button = (Button)sender;
            if(button.Text == ".")
            {
                if (!txtResult.Text.Contains("."))
                    txtResult.Text = txtResult.Text + button.Text;
            }
                else
            txtResult.Text = txtResult.Text + button.Text;
        }

        private void operator_click(object sender, EventArgs e) //
        {
            Button button = (Button)sender;

            if (resultValue != 0)
            {
                btnEquals.PerformClick();
                operationPerformed = button.Text;
                resultValue = Double.Parse(txtResult.Text);
                lblCurrentOperation.Text = resultValue + " " + operationPerformed;
                isOperationPerformed = true;
            }
            else
            {
                operationPerformed = button.Text;
                resultValue = Double.Parse(txtResult.Text);
                lblCurrentOperation.Text = resultValue + " " + operationPerformed;
                isOperationPerformed = true;
            }
        }

        private void btnClear_Click(object sender, EventArgs e) //clear button
        {
            txtResult.Text = "0";
            resultValue = 0;
        }

        private void btnEquals_Click(object sender, EventArgs e) //equals button
        {
            switch(operationPerformed)
            {
                case "+":
                    txtResult.Text = (resultValue + Double.Parse(txtResult.Text)).ToString();
                    break;
                case "-":
                    txtResult.Text = (resultValue - Double.Parse(txtResult.Text)).ToString();
                    break;
                case "/":
                    txtResult.Text = (resultValue / Double.Parse(txtResult.Text)).ToString();
                    break;
                case "*":
                    txtResult.Text = (resultValue * Double.Parse(txtResult.Text)).ToString();
                    break;
                default:
                    break;
            }
            resultValue = Double.Parse(txtResult.Text);
            lblCurrentOperation.Text = "";
        }

        private void btnBack_Click(object sender, EventArgs e) //back button
        {
            int lengtht = txtResult.TextLength - 1; //initialize variables 
            string text = txtResult.Text;
            txtResult.Clear();
            for (int i = 0; i < lengtht; i++)
                txtResult.Text = txtResult.Text + text[i];
        }

        private void btnExit_Click(object sender, EventArgs e) //exit button
        {
            this.Close(); //close
        }

        private void btnSqrt_Click(object sender, EventArgs e) //square root button
        {
            double opr1; //initialize variable
            if (double.TryParse(txtResult.Text, out opr1))
            {
                txtResult.Text = (Math.Sqrt(opr1)).ToString(); //square root equation into textbox
            }
        }

        private void btnReciprocal_Click(object sender, EventArgs e) //reciprocal button
        {
            if (txtResult.Text != string.Empty) 
            {
                double chk = Convert.ToDouble("1") / Convert.ToDouble(txtResult.Text); //initialize equation to find reciprocal
                txtResult.Text = chk.ToString(); //plugging equation into textbox
            }
        }

        private void Negate (object sender, EventArgs e) //negate button
        {
            if (txtResult.Text.StartsWith("-"))
            {
                txtResult.Text = txtResult.Text.ToString();
            }
            else if
                (!string.IsNullOrEmpty(txtResult.Text) && decimal.Parse(txtResult.Text) != 0)
            {
                txtResult.Text = "-" + txtResult.Text;
            }
        }
    }
}