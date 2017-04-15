using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculator
{
    public partial class Form1 : Form
    {
        Double num1 = 0.0;
        String operation = "";
        bool opPressed = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnNum_Click(object sender, EventArgs e)
        {
            Button btnNum = (Button)sender;
            if ("0" == textResult.Text || true == opPressed)
            {
                textResult.Clear();
                opPressed = false;   //pop stack
            }
            if ("." == btnNum.Text)
            {
                if (false == textResult.Text.Contains("."))
                {
                    if (0 == textResult.Text.Length)
                    {
                        textResult.Text = "0";
                    }
                    textResult.Text += btnNum.Text;
                }
            }
            else
            {
                textResult.Text += btnNum.Text;
            }

            
        }

        private void btnOperator_Click(object sender, EventArgs e)
        {
            if (false == opPressed && 0 != operation.Length) {
                btnEqual.PerformClick();
            }

            num1 = Double.Parse(textResult.Text);
            
            Button btOpertion = (Button)sender;
            operation = btOpertion.Text;
            opPressed = true;        //push stack
            labelEquation.Text = textResult.Text + " " + operation + " ";
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            Double num2 = Double.Parse(textResult.Text);
            Double numResult=0.0;
            switch (operation)
            {
                case "+":
                    numResult = num1 + num2;
                    break;
                case "-":
                    numResult = num1 - num2;
                    break;
                case "*":
                    numResult = num1 * num2;
                    break;
                case "/":
                    if (0 != num2){
                        numResult = num1 / num2;
                    }else{
                        MessageBox.Show(" Can't be divided by 0 ! \n"); 
                        numResult = 0;
                    }
                    break;
                default:
                    break;
            }
            btnClear.PerformClick();
            textResult.Text = numResult.ToString();
            opPressed = true;   // to input new num later on
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            num1 = 0;
            operation = "";
            opPressed = false;
            textResult.Text = "0";
            labelEquation.Text = "";
        }

        private void btnCE_Click(object sender, EventArgs e)
        {
            textResult.Text = "0";
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case '0':
                    btn0.PerformClick();
                    break;
                case '1':
                    btn1.PerformClick();
                    break;
                case '2':
                    btn2.PerformClick();
                    break;
                case '3':
                    btn3.PerformClick();
                    break;
                case '4':
                    btn4.PerformClick();
                    break;
                case '5':
                    btn5.PerformClick();
                    break;
                case '6':
                    btn6.PerformClick();
                    break;
                case '7':
                    btn7.PerformClick();
                    break;
                case '8':
                    btn8.PerformClick();
                    break;
                case '9':
                    btn9.PerformClick();
                    break;
                case '.':
                    btnDot.PerformClick();
                    break;
                case '+':
                    btnAdd.PerformClick();
                    break;
                case '-':
                    btnMinus.PerformClick();
                    break;
                case '*':
                    btnMulti.PerformClick();
                    break;
                case '/':
                    btnDiv.PerformClick();
                    break;
                case '=':
                    btnEqual.PerformClick();
                    break;
                default:
                    break;
            }
        }

    }
}
