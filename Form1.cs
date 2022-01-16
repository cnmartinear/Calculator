using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScientificCalculator
{
    public partial class SciCal : Form
    {
        bool alt = false;
        string ans = string.Empty;

        public SciCal()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            //clear display after evaluation
            if (!string.IsNullOrEmpty(result.Text))
            {
                ClearDisplay();
                result.Text = string.Empty;
            }
            
            if (display.Text == "0" && btn.Name != "dec" && btn.Name != "")
                display.Text = string.Empty;

            switch (btn.Name)
            {
                //digit
                case "dig0":
                case "dig1":
                case "dig2":
                case "dig3":
                case "dig4":
                case "dig5":
                case "dig6":
                case "dig7":
                case "dig8":
                case "dig9":
                    display.Text += btn.Name.Replace("dig", "");
                    break;
                case "pi":
                    display.Text += Math.PI.ToString();
                    break;
                //operator
                case "plus":
                case "minus":
                case "mult":
                case "div":
                case "exp":
                case "oppar":
                case "clpar":
                    display.Text += btn.Text;
                    break;
                case "squ":
                    display.Text += "^2";
                    break;
                //clear
                case "clear":
                    ClearDisplay();
                    break;
                case "neg":
                    if (alt) display.Text += ans;
                    else
                        display.Text.Insert(0, "-");
                    break;
                //decimal
                case "dec":
                    if (!display.Text.Contains("."))
                        display.Text += ".";
                    break;
                case "equ":
                    result.Text = Evaluate(display.Text);
                    ans = result.Text;
                    break;
                //trig
                case "sin":
                case "cos":
                case "tan":
                    display.Text += btn.Name + (alt ? "⁻¹(" : "(");
                    break;
                case "log":
                    display.Text += (alt ? "10^(" : btn.Name + "(");
                    break;
                case "ln":
                    display.Text += (alt ? Math.E.ToString() + "^(" : btn.Name + "(");
                    break;
                //toggle func
                case "func2":
                    ToggleFunctions();
                    break;

            }
        }

        private void ClearDisplay()
        {
            display.Text = "0";
        }

        private string Evaluate(string equation)
        {
            string result = string.Empty;
            char[] op = { '+', '-', '*', '/', '^', '%' };

            List<char> operators = new List<char>();
            List<double> numbers = new List<double>();

            foreach (char c in equation)
            {
                if (op.Contains(c))
                    operators.Add(c);
            }

            try
            {
                string[] parse = equation.Split(op);
                foreach (string s in parse)
                {
                    numbers.Add(Double.Parse(s));
                }

                int idx = 0;
                while (operators.Count > 0)
                {
                    if (operators.Contains('^')) //Exponent
                    {
                        idx = operators.IndexOf('^');
                    }
                    else if (operators.Contains('*')) //Multiply
                    {
                        idx = operators.IndexOf('*');
                    }
                    else if (operators.Contains('/')) //Division
                    {
                        idx = operators.IndexOf('/');
                    }
                    else if (operators.Contains('%')) //Mod
                    {
                        idx = operators.IndexOf('%');
                    }
                    else if (operators.Contains('+')) //Addition
                    {
                        idx = operators.IndexOf('+');
                    }
                    else if (operators.Contains('-')) //Subtraction
                    {
                        idx = operators.IndexOf('-');
                    }

                    char c = operators[idx];
                    double num1 = numbers[idx], num2 = numbers[idx + 1];

                    switch (c)
                    {
                        case '^': numbers[idx] = Math.Pow(num1, num2); break;
                        case '*': numbers[idx] = num1 * num2; break;
                        case '/': numbers[idx] = num1 / num2; break;
                        case '%': numbers[idx] = num1 % num2; break;
                        case '+': numbers[idx] = num1 + num2; break;
                        case '-': numbers[idx] = num1 - num2; break;
                    }
                    numbers.RemoveAt(idx + 1);
                    operators.RemoveAt(idx);
                }

                result = numbers[0].ToString();
            }
            catch
            {
                result = "Error";
            }

            return result;
        }

        private void ToggleFunctions()
        {
            alt = !alt;

            if (alt)
            {
                neg.Text = "ANS";
                log.Text = "10ˣ";
                ln.Text = "eˣ";
                exp.Text = "ˣ√";
                pi.Text = "HYP";
                memvar.Text = "CLRVAR";
                squ.Text = "√";
                oppar.Text = "%";
                clpar.Text = ",";
                sin.Text = "SIN⁻¹";
                cos.Text = "COS⁻¹";
                tan.Text = "TAN⁻¹";
                data.Text = "STAT";
                del.Text = "INS";
                

            }
            else
            {
                neg.Text = "(-)";
                log.Text = "LOG";
                ln.Text = "LN";
                exp.Text = "^";
                pi.Text = "π";
                memvar.Text = "MEMVAR";
                squ.Text = "x²";
                oppar.Text = "(";
                clpar.Text = ")";
                sin.Text = "SIN";
                cos.Text = "COS";
                tan.Text = "TAN";
                data.Text = "DATA";
                del.Text = "DEL";
            }
        }

    }
}
