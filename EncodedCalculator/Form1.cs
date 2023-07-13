using System;
using System.Windows.Forms;

namespace EncodedCalculator
    {
        public partial class EncodedCalculator : Form
        {
            public EncodedCalculator()
            {
                InitializeComponent();
            }


            double num1;
            double num2;
            double result;
            string operation;
            string encodedResult;

            private void button1_Click(object sender, EventArgs e)
            {
                textBox1.Text = textBox1.Text + button1.Text;
                encodedTextBox.Text = encodedTextBox.Text + "i";
            }

            private void button2_Click(object sender, EventArgs e)
            {
                textBox1.Text = textBox1.Text + button2.Text;
                encodedTextBox.Text = encodedTextBox.Text + "m";
            }

            private void button3_Click(object sender, EventArgs e)
            {
                textBox1.Text = textBox1.Text + button3.Text;
                encodedTextBox.Text = encodedTextBox.Text + "p";
            }

            private void button4_Click(object sender, EventArgs e)
            {
                textBox1.Text = textBox1.Text + button4.Text;
                encodedTextBox.Text = encodedTextBox.Text + "o";
            }

            private void button5_Click(object sender, EventArgs e)
            {
                textBox1.Text = textBox1.Text + button5.Text;
                encodedTextBox.Text = encodedTextBox.Text + "r";
            }

            private void button6_Click(object sender, EventArgs e)
            {
                textBox1.Text = textBox1.Text + button6.Text;
                encodedTextBox.Text = encodedTextBox.Text + "t";
            }

            private void button7_Click(object sender, EventArgs e)
            {
                textBox1.Text = textBox1.Text + button7.Text;
                encodedTextBox.Text = encodedTextBox.Text + "a";
            }

            private void button8_Click(object sender, EventArgs e)
            {
                textBox1.Text = textBox1.Text + button8.Text;
                encodedTextBox.Text = encodedTextBox.Text + "n";
            }

            private void button9_Click(object sender, EventArgs e)
            {
                textBox1.Text = textBox1.Text + button9.Text;
                encodedTextBox.Text = encodedTextBox.Text + "c";
            }

            private void button10_Click(object sender, EventArgs e)     // Button 0
            {
                textBox1.Text = textBox1.Text + button10.Text;
                encodedTextBox.Text = encodedTextBox.Text + "e";
            }

            private void button13_Click(object sender, EventArgs e)     // Plus Operator
            {
                operation = "+";

                num1 = int.Parse(textBox1.Text);
                textBox1.Clear();

                encodedTextBox.Clear();
            }

            private void button14_Click(object sender, EventArgs e)     // Minus Operator
            {
                operation = "-";

                num1 = int.Parse(textBox1.Text);
                textBox1.Clear();

                encodedTextBox.Clear();
            }

            private void button15_Click(object sender, EventArgs e)     // Multiplication Operator
            {
                operation = "*";

                num1 = int.Parse(textBox1.Text);
                textBox1.Clear();

                encodedTextBox.Clear();
            }

            private void button16_Click(object sender, EventArgs e)     // Division Operator
            {
                operation = "/";

                num1 = int.Parse(textBox1.Text);
                textBox1.Clear();

                encodedTextBox.Clear();
            }

            private void button11_Click(object sender, EventArgs e)     // Equals Operator
            {
                num2 = int.Parse(textBox1.Text);

                if (operation == "+")
                    result = num1 + num2;

                if (operation == "-")
                    result = num1 - num2;

                if (operation == "*")
                    result = num1 * num2;

                if (operation == "/")
                {
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                    }
                    else
                    {
                        textBox1.Text = "Division by Zero Error";
                        return;

                    }
                }

                textBox1.Text = result + "";
                encodedResult = EncodeResult(result);
                encodedTextBox.Text = encodedResult + "";
            }

            /*
             ---------------------- USING SWITCH CASE -------------------------

            private string EncodeResult(double value)
            {
                string encodedResult = "";
                string digits = value.ToString();

                foreach (char digit in digits)
                {
                    switch (digit)
                    {
                        case '0':
                            encodedResult += "e";
                            break;
                        case '1':
                            encodedResult += "i";
                            break;
                        case '2':
                            encodedResult += "m";
                            break;
                        case '3':
                            encodedResult += "p";
                            break;
                        case '4':
                            encodedResult += "o";
                            break;
                        case '5':
                            encodedResult += "r";
                            break;
                        case '6':
                            encodedResult += "t";
                            break;
                        case '7':
                            encodedResult += "a";
                            break;
                        case '8':
                            encodedResult += "n";
                            break;
                        case '9':
                            encodedResult += "c";
                            break;
                        default:
                            encodedResult += "INVALID RESULT";
                            break;
                    }
                }

                return encodedResult;
            }

            ---------------------- USING ARRAYS -------------------------

            private string EncodeResult(double value)
            {
                string encodedResult = "";
                string digits = value.ToString();

                // Define the encoding mapping using arrays
                string[] encodingMap = { "e", "i", "m", "p", "o", "r", "t", "a", "n", "c" };

                foreach (char digit in digits)
                {
                    int index = digit - '0';

                    if (index >= 0 && index < encodingMap.Length)
                    {
                        encodedResult += encodingMap[index];
                    }
                    else
                    {
                        encodedResult += "INVALID RESULT";
                    }
                }

                return encodedResult;
            }
            */

            // --------------- USING ARRAYS & LOOP and SPLITTING DECIMAL VALUE OF THE RESULT -------------------

            private string EncodeResult(double value)
            {
                string encodedResult = "";

                string resultString = value.ToString();

                if (resultString.Contains("."))
                {
                    string[] parts = resultString.Split('.');
                    string integerPart = parts[0];
                    string decimalPart = parts[1];

                    encodedResult += EncodeIntegerPart(integerPart);
                    encodedResult += "d";
                    encodedResult += EncodeDecimalPart(decimalPart);
                }
                else
                {
                    encodedResult = EncodeIntegerPart(resultString);
                }

                return encodedResult;
            }

            private string EncodeIntegerPart(string value)
            {
                string encodedResult = "";
                string digits = value.ToString();

                string[] encodingMap = { "e", "i", "m", "p", "o", "r", "t", "a", "n", "c" };

                foreach (char digit in digits)
                {
                    int index = digit - '0';

                    if (index >= 0 && index < encodingMap.Length)
                    {
                        encodedResult += encodingMap[index];
                    }
                    else
                    {
                        encodedResult += "INVALID VALUE";
                    }
                }

                return encodedResult;
            }

            private string EncodeDecimalPart(string value)
            {
                string encodedResult = "";
                string digits = value.ToString();

                string[] encodingMap = { "e", "i", "m", "p", "o", "r", "t", "a", "n", "c" };

                foreach (char digit in digits)
                {
                    int index = digit - '0';

                    if (index >= 0 && index < encodingMap.Length)
                    {
                        encodedResult += encodingMap[index];
                    }
                    else
                    {
                        encodedResult += "INVALID VALUE";
                    }
                }

                return encodedResult;
            }

            private void button12_Click(object sender, EventArgs e)     // Clear Button
            {
                textBox1.Clear();
                encodedTextBox.Clear();
                encodedResult = "";
                result = 0;
                num1 = 0;
                num2 = 0;
            }

            private void textBox1_TextChanged(object sender, EventArgs e)       // Display Box
            {

            }

            private void encodedTextBox_TextChanged(object sender, EventArgs e)
            {

            }
        }
    }

