using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Text;

namespace HelloCSharp
{
    public static class Program
    {
        public static double ans = 0; //answer
        public static string answer = "";
        public static string equation;  //equation
        public static int dec_counter = 0;
        public static double rad = Math.PI / 180; //radian conversion factor
        public static List<string> func = new List<string>();
        public static List<char> operators = new List<char>(); //stores operators extracted from equations
        public static List<double> num = new List<double>(); //stores numbers extracted from equation
        public static bool exceptionThrown = false;
        public static bool hyp = false;
        public static bool dtof = false;


        [STAThread]
        //main method
        static void Main()
        {
            //initiates calculator application
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SampleSciCal());
        }

        public static string Evaluate(string s)
        {
            s = Parenthesis(s);
            try
            {
                num = Extract(s);
                answer = Solve(ans, num);
            }

            //returns error message if a number is typed in incorrectly
            //(i.e. double decimal, negative sign after number, etc.)
            catch (Exception)
            {
                answer = "Error";
            }

            //ans = Solve(ans, num);
            //return ans.ToString();
            return answer;
        }





        //Calculates factorial
        public static double Factorial(double x)
        {
            double f = 1;
            for (int i = 1; i <= x; i++)
            {
                f = f * i;
            }

            return f;
        }

        public static void ParseNum(string n)
        {
            if (n != null)
                num.Add(double.Parse(n));


        }


        //converts a decimal to a simplified fraction
        public static string DecimaltoFraction(double x)
        {
            string f="";
            int w;
            double n, d;//whole no, numerator, denominator
            int gcd=1;
            if (x < 0)
            {
                w = int.Parse(Math.Ceiling(x).ToString());
            }
            else
            {
                w = int.Parse(Math.Floor(x).ToString());
            }
            //else w = 0;

            x = x-w;

            if (x * 1000 < 1000)
            {
                n = Math.Round(x * 1000); d = 1000;
                for (int i = 1; i <= n; i++)
                {
                    if (n % i == 0 && d % i == 0)
                    {
                        gcd = i;
                    }
                }
                n /= gcd; d /= gcd;
                f = w + " " + n + "/" + d;
            }

            else f = w.ToString();
            return f;
        }

        public static double Permutation(double n, double r)
        {
            double p;
            p = Factorial(n) / (Factorial(n - r));
            return p;
           
        }

        public static double Combination(double n, double r)
        {
            double c;
            c = Factorial(n) / (Factorial(r)*(Factorial(n - r)));
            return c;

        }

        //returns floating point decimal in scientific notation
        public static string ScientificNotation(double n)
        {
            string s="";
            int power_counter = 0;
            if (Math.Abs(n) < 1)
            {
                while (Math.Abs(n) < 1)
                {
                    n *= 10;
                    power_counter--;
                }
            }
            else
            {
                while (Math.Abs(n) >= 10)
                {
                    n /= 10;
                    power_counter++;
                }
            }
            s = n.ToString() + "+e" + power_counter;
            return s;
        }
        //returns floating point number in engineering notation
        public static string EngineeringNotation(double n)
        {
            string s = "";
            int power_counter = 0;
            if (Math.Abs(n) < .001)
            {
                while (Math.Abs(n) < .001)
                {
                    n *= .001;
                    power_counter-=3;
                }
            }
            else
            {
                while (Math.Abs(n) >= 1000)
                {
                    n /= 1000;
                    power_counter+=3;
                }
            }
            s = n.ToString() + "+e" + power_counter;
            return s;
        }

        //evaluates all expressions within parentheses
        public static string Parenthesis(string s)
        {
            int po_count = 0, pc_count = 0;
            double temp_ans = 0;
            string pp = null; //stores expression inside parentheses
            int ito_count; //inter to outer parentheses counter
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(') po_count++;
                if (s[i] == ')') pc_count++;
            }

            while (po_count > 0)
            {
                ito_count = 0;
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] == '(')
                    {
                        ito_count++;

                        if (ito_count == po_count)
                        {
                            pp = null;
                            for (int j = i + 1; s[j] != ')'; j++)
                            {
                                pp += s[j];
                            }

                            List<double> temp_num = Extract(pp);
                            temp_ans = double.Parse(Solve(temp_ans, temp_num));
                            s=s.Insert(i, temp_ans.ToString());
                            s=s.Remove(startIndex: i + temp_ans.ToString().Length, count: pp.Length + 2);
                            po_count--;
                        }

                    }
                }


               
            }
            return s;
        }

        //solves equation input by user
        public static string Solve(double a, List<double> num)
        {
            //string error = null;
            bool ftod = false;
            string b = null;
            if (num.Count == 1 && operators.Count == 0) { a = num.ElementAt(0); b = a.ToString(); }
            else
                //while (operators.Count>0)
                //{
                try
                {

                    
                    //Factorial
                    for (int i = 0; i < operators.Count; i++)
                    {
                        if (operators[i] == '!') { a = Factorial(num[i]); num[i] = a; operators.Remove(operators[i]); }


                    }

                    //Trig functions
                    for (int i = 0; i < operators.Count; i++)
                    {
                        if (hyp == false)//evaluates non-hyperbolic trig functions
                        {
                            if (operators[i] == 'i') { a = Math.Sin(num[i] * rad); num[i] = a; operators.Remove(operators[i]); }
                            else if (operators[i] == 'c') { a = Math.Cos(num[i] * rad); num[i] = a; operators.Remove(operators[i]); }
                            else if (operators[i] == 't') { a = Math.Tan(num[i] * rad); num[i] = a; operators.Remove(operators[i]); }
                        }
                        else //evaluates hyperbolic trig functions
                        {
                            if (operators[i] == 'i') { a = Math.Sinh(num[i] * rad); num[i] = a; operators.Remove(operators[i]); }
                            else if (operators[i] == 'c') { a = Math.Cosh(num[i] * rad); num[i] = a; operators.Remove(operators[i]); }
                            else if (operators[i] == 't') { a = Math.Tanh(num[i] * rad); num[i] = a; operators.Remove(operators[i]); }
                        }
                    }

                    //logarithmic functions
                    for (int i = 0; i < operators.Count; i++)
                    {
                        if (operators[i] == 'g') { a = Math.Log10(num[i]); num[i] = a; operators.Remove(operators[i]); }
                    }


                    //Square, Square Root, Inverse
                    for (int i = 0; i < operators.Count; i++)
                    {
                        if (operators[i] == '²') { a = num[i] * num[i]; num[i] = a; operators.Remove(operators[i]); }
                        else if (operators[i] == '⁻') { a = 1 / num[i]; num[i] = a; operators.Remove(operators[i]); }
                        else if (operators[i] == '√') { a = Math.Sqrt(num[i]); num[i] = a; operators.Remove(operators[i]); }
                    }

                    //Scientific notation
                    for (int i = 0; i < operators.Count; i++)
                    {
                        if (operators[i] == 'E') { a =  num[i]*Math.Pow(10,num[i+1]); num.RemoveAt(i + 1); operators.RemoveAt(i); i--; }

                    }

                    //Exponent
                    for (int i = 0; i < operators.Count; i++)
                    {
                        if (operators[i] == '^') { a = Math.Pow(num[i], num[i + 1]); num[i] = a; num.RemoveAt(i + 1); operators.RemoveAt(i); i--; }

                    }

                    //Multiplication, Division, Modular, Permuation, Combination
                    for (int i = 0; i < operators.Count; i++)
                    {
                        if (operators[i] == 'P') { a = Permutation(num[i], num[i + 1]); num.RemoveAt(i + 1); num[i] = a; operators.Remove(operators[i]); }
                        else if (operators[i] == 'C') { a = Combination(num[i], num[i + 1]); num.RemoveAt(i + 1); num[i] = a; operators.Remove(operators[i]); }
                        else if (operators[i] == '*') { a = num[i] * num[i + 1]; num[i] = a; num.RemoveAt(i + 1); operators.RemoveAt(i); i--; }
                        else if (operators[i] == '/') { a = num[i] / num[i + 1]; num[i] = a; num.RemoveAt(i + 1); operators.RemoveAt(i); i--; }
                        else if (operators[i] == '%') { a = num[i] % num[i + 1]; num[i] = a; num.RemoveAt(i + 1); operators.RemoveAt(i); i--; }

                    }

                    //Addition, Subtraction
                    for (int i = 0; i < operators.Count; i++)
                    {

                        if (operators[i] == '+') { a = num[i] + num[i + 1]; num[i] = a; num.RemoveAt(i + 1); operators.RemoveAt(i); i--; }
                        else if (operators[i] == '−') { a = num[i] - num[i + 1]; num[i] = a; num.RemoveAt(i + 1); operators.RemoveAt(i); i--; }



                    }

                    for (int i = 0; i < operators.Count; i++)
                    {
                        if (operators[i] == 'F') { a = num[i]; dtof = true; }
                        
                    }

                    if (dtof== true)
                    {
                        b = DecimaltoFraction(a);
                    }
                    else
                    b = a.ToString();
                    
                }

                //prints error message if equation is entered incorrectly
                catch (ArgumentOutOfRangeException)
                {
                    b = "Error";
                    operators.Clear();
                    // break;

                }

            return b;
        }

        //extracts numerals and operators from equation input by user
        public static List<double> Extract(string eval)
        {

                List<double> num = new List<double>();
                string temp_num = null; //temporarily stores numeric values until non-numeric value is reached in string

                for (int i = 0; i < eval.Length; i++)
                {
                    if (eval[i] >= 48 && eval[i] < 58 || eval[i] == 46 || eval[i]=='-')
                    {
                        //adds digit or decimal to number
                        temp_num += eval[i];
                    }

                    else if (eval[i] == 'e')
                    {
                        if (temp_num != null)
                            num.Add(double.Parse(temp_num));
                        temp_num = null;

                        num.Add(Math.E); //add constant e to number vector
                    }

                    else if (eval[i] == 'π')
                    {
                        if (temp_num != null)
                            num.Add(double.Parse(temp_num));
                        temp_num = null;
                      
                        num.Add(Math.PI); //add constant pi to number list
                    }


                    else if (eval[i] == '+' || eval[i]=='−' || eval[i] == '*' || eval[i] == '/' || eval[i] == '%' || eval[i] == '^'|| eval[i] == '!' || eval[i] == '²' || eval[i]== '√' || eval[i]== '⁻' || eval[i]=='P' || eval[i]=='C' || eval[i]== 'E' || eval[i]=='F')
                    {
                        if (temp_num != null)
                        num.Add(double.Parse(temp_num));
                        temp_num = null;
                    
                        operators.Add(eval[i]); //adds operator to operator list

                    }

                    else if (eval[i]=='i'|| eval[i] == 'c' || eval[i] == 't'|| eval[i] == 'l' || eval[i]=='g')
                    {

                        if (temp_num != null)
                            num.Add(double.Parse(temp_num));
                        temp_num = null;
                     
                        if (eval[i] == 'i')
                        operators.Add(eval[i]);
                        else if (eval[i] == 'c')
                            operators.Add(eval[i]);
                        else if (eval[i] == 't')
                            operators.Add(eval[i]);
                       // else if (eval[i] == 'l')
                         //   operators.Add(eval[i]);
                        else if (eval[i] == 'g')
                            operators.Add(eval[i]);
                    }


                    else
                    {
                        //puts number into number list if non-operator value found
                        if (temp_num != null)
                            num.Add(double.Parse(temp_num));
                        temp_num = null;
                      
                    }

                }
                //places last number found into number list
                if (temp_num != null)
                    num.Add(double.Parse(temp_num));
                temp_num = null;
          

                //returns number list
                return num;
            
        }
    }
}

