using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace HelloCSharp
{
    

    public partial class SampleSciCal : Form
    {
       
        public int buttonToggle = 0; 
        public double ans = 0;
        public bool enterButtonPressed = false;
        public bool exceptionThrown = false;
        public List<string> memory = new List<string>();
        public int memIndex = 0;
        public bool scieng = false;
        public bool degrad = true;
        public bool flo = true;
        public bool sci = false;
        public bool eng = false;
        
        
        public SampleSciCal()
        {
            InitializeComponent();
        }

        

        //Retrieves equation from text box


        public void Answer(string s)
        {
            AnswerBox.Text = s;
        }

        public void SetTextToInvisible()
        {
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
        }
        
        private void button15_Click(object sender, EventArgs e)
        {
            ClearForNewEquation();
            EquationBox.Text += "*";
        }

        private void button25_Click(object sender, EventArgs e)
        {
            ClearForNewEquation();
            if (EquationBox.Text.Length!=0)
            {
                if (EquationBox.Text[EquationBox.Text.Length - 1] >= 48 && EquationBox.Text[EquationBox.Text.Length - 1] < 58)
                    EquationBox.Text += "*";
            }
            if (buttonToggle == 1)
            {
                if (Program.hyp == true)
                {
                    EquationBox.Text += "sinh⁻¹(";
                }
                else
                    EquationBox.Text += "sin⁻¹(";
            }
            else
            if (Program.hyp == true)
            {
                EquationBox.Text += "sinh(";
            }
            else
            EquationBox.Text += "sin(";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ClearForNewEquation();
            if (buttonToggle == 1)
            {
                memory.Clear();
                EquationBox.Text = "Memory Cleared";
            }
            else
            {
                if (EquationBox.Text != "" && EquationBox.Text != "0" && EquationBox.Text[EquationBox.Text.Length - 1] != ')')
                {
                    EquationBox.Text += "0";
                }
            }
               
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ClearForNewEquation();
            EquationBox.Text += "1";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ClearForNewEquation();
            EquationBox.Text += "2";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ClearForNewEquation();
            EquationBox.Text += "3";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ClearForNewEquation();
            EquationBox.Text += "4";
        }

        private void cosButton_Click(object sender, EventArgs e)
        {
            ClearForNewEquation();
            if (EquationBox.Text.Length != 0)
            {
                if (EquationBox.Text[EquationBox.Text.Length - 1] >= 48 && EquationBox.Text[EquationBox.Text.Length - 1] < 58)
                    EquationBox.Text += "*";
            }
            if (buttonToggle == 1)
            {
                if (Program.hyp == true)
                {
                    EquationBox.Text += "cosh⁻¹(";
                }
                else
                    EquationBox.Text += "cos⁻¹(";
            }
            else
if (Program.hyp == true)
            {
                EquationBox.Text += "cosh(";
            }
            else
                EquationBox.Text += "cos(";
        }

        private void tanButton_Click(object sender, EventArgs e)
        {
            ClearForNewEquation();
            if (EquationBox.Text.Length != 0)
            {
                if (EquationBox.Text[EquationBox.Text.Length - 1] >= 48 && EquationBox.Text[EquationBox.Text.Length - 1] < 58)
                    EquationBox.Text += "*";
            }
            if (buttonToggle == 1)
            {
                if (Program.hyp == true)
                {
                    EquationBox.Text += "tanh⁻¹(";
                }
                else
                    EquationBox.Text += "tan⁻¹(";
            }
            else
            if (Program.hyp == true)
            {
                EquationBox.Text += "tanh(";
            }
            else
                EquationBox.Text += "tan(";
        }

        private void open_parButton_Click(object sender, EventArgs e)
        {
            ClearForNewEquation();
            if (buttonToggle == 1)
            {
                EquationBox.Text += "%";
            }
            else
            EquationBox.Text += "(";
        }

        private void closed_parButton_Click(object sender, EventArgs e)
        {
            ClearForNewEquation();
            EquationBox.Text += ")";
        }

        private void expButton_Click(object sender, EventArgs e)
        {
            ClearForNewEquation();
            EquationBox.Text += "^";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ClearForNewEquation();
            EquationBox.Text += "5";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ClearForNewEquation();
            EquationBox.Text += "6";
        }

        private void helloButton_Click(object sender, EventArgs e)
        {
            ClearForNewEquation();
            EquationBox.Text += "7";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearForNewEquation();
            EquationBox.Text += "8";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClearForNewEquation();
            EquationBox.Text += "9";
        }

        private void subButton_Click(object sender, EventArgs e)
        {
            ClearForNewEquation();
            EquationBox.Text += "\x2212";
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            SetTextToInvisible();
            EquationBox.Text ="";
            AnswerBox.Text = "";

        }

        private void button10_Click(object sender, EventArgs e)
        {
            ClearForNewEquation();
            EquationBox.Text = EquationBox.Text + ".";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            ClearForNewEquation();
            if (buttonToggle == 1)
            {
                EquationBox.Text += ans;
            }
            else
            EquationBox.Text += "-";
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            EquationBox.Text = EquationBox.Text + "+";
        }

        private void divButton_Click(object sender, EventArgs e)
        {

            EquationBox.Text = EquationBox.Text + "/";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            
            if (scieng == true)
            {
                if (textBox2.ForeColor == Color.Lime)
                {
                    flo = true; sci = false; eng = false;

                }

                else if (textBox3.ForeColor == Color.Lime)
                {
                    flo = false; sci = true; eng = false;
                }

                else if (textBox4.ForeColor == Color.Lime)
                {
                    flo = false; sci = false; eng = true;
                }
                scieng = false;
                textBox2.Visible = false;
                textBox3.Visible = false;
                textBox4.Visible = false;
            }
            else
            {
                int po_count = 0, pc_count = 0;
                foreach (char eq in EquationBox.Text)
                {
                    if (eq == '(')
                    {
                        po_count++;
                    }

                    if (eq == ')')
                    {
                        pc_count++;
                    }

                }

                if (pc_count < po_count)
                {
                    for (int i = 0; i < po_count - pc_count; i++)
                    {
                        EquationBox.Text += ")";
                    }
                }

                //Solve Equation
                double temp_ans;
                if (sci == true)
                {
                    temp_ans = double.Parse(Program.Evaluate(EquationBox.Text));
                    AnswerBox.Text = Program.ScientificNotation(temp_ans);
                }
                else if (eng == true)
                {
                    temp_ans = double.Parse(Program.Evaluate(EquationBox.Text));
                    AnswerBox.Text = Program.EngineeringNotation(temp_ans);
                }
                else
                AnswerBox.Text = Program.Evaluate(EquationBox.Text);

                if (AnswerBox.Text != "Error" && Program.dtof==false)
                {
                    ans = Double.Parse(Program.Evaluate(EquationBox.Text));
                }

                memory.Add(EquationBox.Text);
                memIndex = memory.Count;
                enterButtonPressed = true;
                Program.dtof = false;
            }
            
        }

        private void lnButton_Click(object sender, EventArgs e)
        {
            ClearForNewEquation();
            if (EquationBox.Text.Length != 0)
            {
                if (EquationBox.Text[EquationBox.Text.Length - 1] >= 48 && EquationBox.Text[EquationBox.Text.Length - 1] < 58)
                    EquationBox.Text += "*";
            }
            if (buttonToggle == 1)
            {
                EquationBox.Text += "e^(";
            }
            else
            EquationBox.Text += "ln(";
        }

        private void piButton_Click(object sender, EventArgs e)
        {
            ClearForNewEquation();
            if (buttonToggle == 1)
            {
                if (Program.hyp == false)
                {
                    Program.hyp = true;
                }
                else Program.hyp = false;
                
            }
            else
            {
                if (EquationBox.Text.Length != 0)
                {
                    if (EquationBox.Text[EquationBox.Text.Length - 1] >= 48 && EquationBox.Text[EquationBox.Text.Length - 1] < 58)
                        EquationBox.Text += "*";
                }
                EquationBox.Text += "π";
            }
        }

        private void button37_Click(object sender, EventArgs e)
        {
            
            if (buttonToggle == 0) buttonToggle = 1;
            else buttonToggle = 0; 

            if (buttonToggle == 1)
            {
                sinButton.Text = "SIN\x207B\xB9";
                cosButton.Text = "COS\x207B\xB9";
                tanButton.Text = "TAN\x207B\xB9";
                logButton.Text = "10\x207F";
                lnButton.Text = "e\x207F";
                expButton.Text = "\x207F\x221A";
                squareButton.Text = "\x221A";
                invButton.Text = "EE";
                open_parButton.Text = "%";
                closed_parButton.Text = ",";
                negButton.Text = "ANS";
                negButton.Font = new System.Drawing.Font("Arial", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                DRGbutton.Text = "SCI/ENG";
                fractionButton.Text = "A b/c \x23F4\x23F4 d/e";
                delButton.Text="INS";
                PRBbutton.Text = "F\x23F4\x23F5D";
                memvarButton.Text = "CLRVAR";
                stoButton.Text = "RCL";
                piButton.Text = "HYP";
                button0.Text = "RESET";
                button0.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                textBox1.Visible = true;
            }

            else 
            {
                sinButton.Text = "SIN";
                cosButton.Text = "COS";
                tanButton.Text = "TAN";
                logButton.Text = "LOG";
                lnButton.Text = "LN";
                expButton.Text = "^";
                squareButton.Text = "x\xB2";
                invButton.Text = "x\x207B\xB9";
                open_parButton.Text = "(";
                closed_parButton.Text = ")";
                negButton.Text = "(-)";
                negButton.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                DRGbutton.Text = "DRG";
                fractionButton.Text = "A b/c";
                delButton.Text = "DEL";
                PRBbutton.Text = "PRB";
                memvarButton.Text = "MEMVAR";
                piButton.Text = "π";
                stoButton.Text = "STO\x23F5";
                button0.Text="0";
                button0.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                textBox1.Visible = false;

            }
        }

        private void logButton_Click(object sender, EventArgs e)
        {
            ClearForNewEquation();
            if (buttonToggle == 1)
            {
                EquationBox.Text += "10^(";
            }
            else
            EquationBox.Text+="log(";
        }

        private void button19_Click(object sender, EventArgs e)
        {
            ClearForNewEquation();
            if (buttonToggle == 1)
            {
                EquationBox.Text += "\x221A(";
            }
            else 
            EquationBox.Text += "²";
        }

        private void EquationBox_TextChanged(object sender, EventArgs e)
        {
            /*if (EquationBox.Text.Length > 10)
            {
                EquationBox.Font = new System.Drawing.Font("Consolas", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                EquationBox.Size = new System.Drawing.Size(254, 50);
            }*/
        }

        private void button29_Click(object sender, EventArgs e)
        {
            ClearForNewEquation();
            EquationBox.Text = EquationBox.Text + "!";
        }
        //Delete Button
        private void button39_Click(object sender, EventArgs e)
        {
            ClearForNewEquation();
            if (EquationBox.Text.Length>=1)
            EquationBox.Text = EquationBox.Text.Remove(EquationBox.Text.Length - 1);

        }


        public void ClearForNewEquation()
        {
            if (enterButtonPressed == true)
            EquationBox.Text = null;
            enterButtonPressed = false;
        }

        private void invButton_Click(object sender, EventArgs e)
        {
            if (buttonToggle == 1)
            {
                EquationBox.Text += "E";
            }
            else
            {
                if (EquationBox.Text == "")
                {
                    EquationBox.Text += "Ans⁻¹";
                }
                else
                {
                    EquationBox.Text += "⁻¹";
                }
            }
        }

        private void AnswerBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button30_Click(object sender, EventArgs e)
        {
            EquationBox.Text += "> F <-> D";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void DRGbutton_Click(object sender, EventArgs e)
        {
            if (buttonToggle == 1)
            {
                textBox2.Text = "FLO";
                textBox3.Text = "SCI";
                textBox4.Text = "ENG";
                textBox2.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;
                scieng = true;

                if (flo == true)
                {
                    textBox2.ForeColor = Color.Lime;
                }
                else if (sci == true)
                {
                    textBox3.ForeColor = Color.Lime;
                }
                else if (eng == true)
                {
                    textBox4.ForeColor = Color.Lime;
                }
            }
            else
            {
                textBox2.Text = "DEG";
                textBox3.Text = "RAD";
                textBox4.Text = "GRD";
                textBox2.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;
                degrad = true;

                if (flo == true)
                {
                    textBox2.ForeColor = Color.Lime;
                }
                else if (sci == true)
                {
                    textBox3.ForeColor = Color.Lime;
                }
                else if (eng == true)
                {
                    textBox4.ForeColor = Color.Lime;
                }
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            if (scieng == true ||degrad==true)
            {
                if (textBox2.ForeColor == Color.Lime)
                {
                    textBox4.ForeColor = Color.Lime;
                    textBox2.ForeColor = Color.Black;
                }

                else if (textBox3.ForeColor == Color.Lime)
                {
                    textBox2.ForeColor = Color.Lime;
                    textBox3.ForeColor = Color.Black;
                }

                else if (textBox4.ForeColor == Color.Lime)
                {
                    textBox3.ForeColor = Color.Lime;
                    textBox4.ForeColor = Color.Black;
                }
            }
        }

        private void upButton_Click(object sender, EventArgs e)
        {
            if (memIndex > 0)
            {
                memIndex--;
                EquationBox.Text = memory[memIndex];
            }
        }

        private void downButton_Click(object sender, EventArgs e)
        {
            if (memIndex < memory.Count-1)
            {
                memIndex++;
                EquationBox.Text = memory[memIndex];
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void rightButton_Click(object sender, EventArgs e)
        {
            if (scieng == true || degrad==true)
            {
                if (textBox2.ForeColor==Color.Lime)
                {
                    textBox3.ForeColor = Color.Lime;
                    textBox2.ForeColor = Color.Black;
                }

                else if (textBox3.ForeColor == Color.Lime)
                {
                    textBox4.ForeColor = Color.Lime;
                    textBox3.ForeColor = Color.Black;
                }

                else if (textBox4.ForeColor == Color.Lime)
                {
                    textBox2.ForeColor = Color.Lime;
                    textBox4.ForeColor = Color.Black;
                }
            }
        }

        private void PRBbutton_Click(object sender, EventArgs e)
        {
            if (buttonToggle == 1)
            {
                EquationBox.Text += ">>FD";
            }
            else
            {
                textBox2.Text = "nPr";
                textBox3.Text = "nCr";
                textBox4.Text = "!";
                textBox5.Text = "RAND";
                textBox6.Text = "RANDI";
                textBox2.Visible = true;
                textBox3.Visible = true;
                textBox4.Visible = true;
                textBox5.Visible = true;
                textBox6.Visible = true;
             
                textBox2.ForeColor = Color.Lime;
              
            }
        }
    }
}
