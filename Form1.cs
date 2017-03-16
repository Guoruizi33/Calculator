using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        double num1, num2;
        //myFlag: 初始值为false， 输入一个符号后将其设置为true， 第二个数字输入以后有设置回false
        bool myFlag = false, myFlag2 = false;
        bool SymbolFlag = false;
        bool DotFlag = false;
        string myOperator, myOperator2;
        bool ClearFlag = false;
        bool EquFalg = false;

        public Form1()
        {
            InitializeComponent();
        }

        public void NumClick(int myNumber)
        {
            if(EquFalg)
            {
                textResults.Text = "";
                EquFalg = false;
            }
            if (textResults.Text == "0"||textResults.Text=="")
            {
                textResults.Text = myNumber.ToString();
            }
            else if (myFlag)
            {
                textResults.Clear();
                textResults.Text = myNumber.ToString();
                SymbolFlag = false;
                myFlag = false;
            }
            else
                textResults.Text = textResults.Text + myNumber;
            ClearFlag = true;
        }
        public void SymClick(string mySymbol)
        {
            if (!SymbolFlag)
            {
                myOperator = mySymbol;
                myFlag = true;
                DotFlag = false;
                num2 = Convert.ToDouble(textResults.Text);
                if (myFlag2)
                {
                    if (myOperator2 == "/" && num2 == 0)
                    {
                        textInput.Clear();
                        textResults.Text = "Cannot divide by zero!";
                        return;
                    }
                    CalResult(myOperator2);
                }
                myFlag2 = true;
                num1 = Convert.ToDouble(textResults.Text);
                textInput.Text = textInput.Text + num2.ToString() + " " + mySymbol + " ";
                myOperator2 = myOperator;
            }
            SymbolFlag = true;
            ClearFlag = false;
        }
        public void CalResult(string mySymbol)
        {
            string myOperator3 = mySymbol;
            num2 = Convert.ToDouble(textResults.Text);
            if (myOperator2 == "/" && num2 == 0)
            {
                textInput.Clear();
                textResults.Text = "Cannot divide by zero!";
                return;
            }
            switch (myOperator3)
            {
                case "+": textResults.Text = (num1 + num2).ToString(); break;
                case "-": textResults.Text = (num1 - num2).ToString(); break;
                case "*": textResults.Text = (num1 * num2).ToString(); break;
                case "/": textResults.Text = (num1 / num2).ToString(); break;
                case "%": textResults.Text = (num1 % num2).ToString(); break;
            }
        }
        public void DotClick(string mySymbol)
        {
            myOperator = mySymbol;
            if (!DotFlag)
            {
                if (textResults.Text == "0" || myFlag)
                {
                    textResults.Text = "0" + myOperator;
                }
                else
                    textResults.Text += myOperator;
                myFlag = false;
                DotFlag = true;
                SymbolFlag = false;
            }
        }
        private void butReturn_Click(object sender, EventArgs e)
        {
            if (textResults.Text != "")
                if (ClearFlag)
                {
                    textResults.Text = textResults.Text.Substring(0, textResults.Text.Length - 1);
                    if (textResults.Text == "")
                        textResults.Text = "0";
                }
        }
        //Click Quele symbol
        private void butEqu_Click(object sender, EventArgs e)
        {
            CalResult(myOperator2);
            num1 = 0;
            num2 = 0;
            textInput.Text = " ";
            myFlag = false;
            myFlag2 = false;
            ClearFlag = false;
            EquFalg = true;
        }
        //Click . symbol
        private void butDot_Click(object sender, EventArgs e)
        {
            DotClick(".");
        }
        private void butClear_Click(object sender, EventArgs e)
        {
            num1 = 0;
            num2 = 0;
            myFlag = false;
            myFlag2 = false;
            SymbolFlag = false;
            DotFlag = false;
            ClearFlag = false;
            myOperator = "";
            myOperator2 = "";
            textInput.Text = "";
            textResults.Text = "0";
        }
        //Click number 0-9
        private void butNum0_Click(object sender, EventArgs e)
        {
            NumClick(0);
        }
        private void butNum1_Click(object sender, EventArgs e)
        {
            NumClick(1);
        }
        private void butNum2_Click(object sender, EventArgs e)
        {
            NumClick(2);
        }
        private void butNum3_Click(object sender, EventArgs e)
        {
            NumClick(3);
        }
        private void butNum4_Click(object sender, EventArgs e)
        {
            NumClick(4);
        }
        private void butNum5_Click(object sender, EventArgs e)
        {
            NumClick(5);
        }
        private void butNum6_Click(object sender, EventArgs e)
        {
            NumClick(6);
        }
        private void butNum7_Click(object sender, EventArgs e)
        {
            NumClick(7);
        }
        private void butNum8_Click(object sender, EventArgs e)
        {
            NumClick(8);
        }
        private void butNum9_Click(object sender, EventArgs e)
        {
            NumClick(9);
        }
        //Click operators 
        private void butAdd_Click(object sender, EventArgs e)
        {
            SymClick("+");
        }
        private void butSub_Click(object sender, EventArgs e)
        {
            SymClick("-");
        }
        private void butMul_Click(object sender, EventArgs e)
        {
            SymClick("*");
        }
        private void butDiv_Click(object sender, EventArgs e)
        {
            SymClick("/");
        }
        private void butMod_Click(object sender, EventArgs e)
        {
            SymClick("%");
        }
    }
}
