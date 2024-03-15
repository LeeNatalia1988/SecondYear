namespace CalculatorForm
{
    public partial class MyCalculator : Form
    {
        public MyCalculator()
        {
            InitializeComponent();
        }

        float x, y = 0;
        string operation = "";
        bool sing = true;
       
        /*buttons for numbers and C*/
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" && textBox1.Text != null)
            {
                textBox1.Text = "1";
            }
            else
            {
                textBox1.Text = textBox1.Text + "1";
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" && textBox1.Text != null)
            {
                textBox1.Text = "2";
            }
            else
            {
                textBox1.Text = textBox1.Text + "2";
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" && textBox1.Text != null)
            {
                textBox1.Text = "3";
            }
            else
            {
                textBox1.Text = textBox1.Text + "3";
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" && textBox1.Text != null)
            {
                textBox1.Text = "4";
            }
            else
            {
                textBox1.Text = textBox1.Text + "4";
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" && textBox1.Text != null)
            {
                textBox1.Text = "5";
            }
            else
            {
                textBox1.Text = textBox1.Text + "5";
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" && textBox1.Text != null)
            {
                textBox1.Text = "6";
            }
            else
            {
                textBox1.Text = textBox1.Text + "6";
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" && textBox1.Text != null)
            {
                textBox1.Text = "7";
            }
            else
            {
                textBox1.Text = textBox1.Text + "7";
            }
        }
        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" && textBox1.Text != null)
            {
                textBox1.Text = "8";
            }
            else
            {
                textBox1.Text = textBox1.Text + "8";
            }
        }
        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" && textBox1.Text != null)
            {
                textBox1.Text = "9";
            }
            else
            {
                textBox1.Text = textBox1.Text + "9";
            }
        }
        private void button10_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" && textBox1.Text != null)
            {
                textBox1.Text = "0";
            }
            else
            {
                textBox1.Text = textBox1.Text + "0";
            }
        }
        private void button11_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" && textBox1.Text != null)
            {
                textBox1.Text = "0,";
            }
            else
            {
                textBox1.Text = textBox1.Text + ",";
            }
        }
        private void button12_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            label1.Text = "";
        }

        /*button for operation*/
        private void button20_Click(object sender, EventArgs e)
        {
            if (sing)
            {
                if (textBox1.Text == "0" && textBox1.Text != null)
                {
                    label1.Text = "+";
                }
                else
                {
                    x = float.Parse(textBox1.Text);
                    textBox1.Clear();
                    operation = "+";
                    label1.Text = x.ToString() + "+";
                }
            }
            else
            {
                x = float.Parse(textBox1.Text);
                textBox1.Clear();
                operation = "+";
                label1.Text = "-" + x.ToString() + "+";
            }
        }
        private void button21_Click(object sender, EventArgs e)
        {
            if (sing)
            {
                if (textBox1.Text == "0" && textBox1.Text != null)
                {
                    label1.Text = "-";
                    sing = false;
                }
                else
                {
                    x = float.Parse(textBox1.Text);
                    textBox1.Clear();
                    operation = "-";
                    label1.Text = x.ToString() + "-";
                }
            }
            else
            {
                x = float.Parse(textBox1.Text);
                textBox1.Clear();
                operation = "-";
                if (x != 0)
                {
                    label1.Text = "-" + x.ToString();
                }
                else
                {
                    label1.Text = "-";
                }
            }
        }
        private void button22_Click(object sender, EventArgs e)
        {

            if (sing)
            {
                if (textBox1.Text == "0" && textBox1.Text != null)
                {
                    label1.Text = "*";

                }
                else
                {
                    x = float.Parse(textBox1.Text);
                    textBox1.Clear();
                    operation = "*";
                    label1.Text = x.ToString() + "*";
                }
            }
            else
            {
                x = float.Parse(textBox1.Text);
                textBox1.Clear();
                operation = "*";
                label1.Text = "-" + x.ToString() + "*";
            }
        }
        private void button23_Click(object sender, EventArgs e)
        {

            if (sing)
            {
                if (textBox1.Text == "0" && textBox1.Text != null)
                {
                    label1.Text = "/";

                }
                else
                {
                    x = float.Parse(textBox1.Text);
                    textBox1.Clear();
                    operation = "/";
                    label1.Text = x.ToString() + "/";

                }
            }
            else
            {
                x = float.Parse(textBox1.Text);
                textBox1.Clear();
                operation = "/";
                label1.Text = "-" + x.ToString() + "/";

            }
        }
        private void button24_Click(object sender, EventArgs e)
        {
            if (int.Parse(textBox1.Text) == 0)
            {
                textBox1.Clear();
                textBox1.Text = "ERROR";
                label1.Text = "";
            }
            else
            {
                Calculate();
                label1.Text = "";
                sing = true;
            }
        }
        
        /*function for calculate*/
        private void Calculate()
        {
            switch (operation)
            {
                case "+":
                    if (sing)
                    {
                        y = x + float.Parse(textBox1.Text);
                        textBox1.Text = y.ToString();
                        label1.Text = "";
                    }
                    else
                    {
                        y = -x + float.Parse(textBox1.Text);
                        textBox1.Text = y.ToString();
                        label1.Text = "";
                    }
                    break;
                case "-":
                    if (sing)
                    {
                        y = x - float.Parse(textBox1.Text);
                        textBox1.Text = y.ToString();
                        label1.Text = "";
                    }
                    else
                    {
                        y = -x - float.Parse(textBox1.Text);
                        textBox1.Text = y.ToString();
                        label1.Text = "";
                    }
                    break;
                case "*":
                    if (sing)
                    {
                        y = x * float.Parse(textBox1.Text);
                        textBox1.Text = y.ToString();
                        label1.Text = "";
                    }
                    else
                    {
                        y = -x * float.Parse(textBox1.Text);
                        textBox1.Text = y.ToString();
                        label1.Text = "";
                    }
                    break;
                case "/":
                    if (sing)
                    {
                        y = x / float.Parse(textBox1.Text);
                        textBox1.Text = y.ToString();
                        label1.Text = "";
                    }
                    else
                    {
                        y = -x / float.Parse(textBox1.Text);
                        textBox1.Text = y.ToString();
                        label1.Text = "";
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
