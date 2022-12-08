using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lab1_OOP
{
    public partial class Form1 : Form
    {

        private FormMenu menu;
        public Form1()
        {
            InitializeComponent();
        }

        public Form1(FormMenu fm)
        {
            InitializeComponent();
            menu = fm;
            fm.Hide();

        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            menu.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(textBox1.Text, out var check)
                | !double.TryParse(textBox2.Text, out check) | !double.TryParse(textBox3.Text, out check))
            {
                MessageBox.Show("Вводите действительные числа, а не всякую ерунду!");
            }
            else
            {
                double a = double.Parse(textBox1.Text);
                double b = double.Parse(textBox2.Text);
                double c = double.Parse(textBox3.Text);
                if (a > 0 & b > 0 & c > 0)
                {
                    textBox4.Text = "Среднее арифметическое: " + Convert.ToString((a + b + c) / 3);
                }
                else if (a == 0 | b == 0 | c == 0)
                {
                    MessageBox.Show("Ноль не положителен и не отрицателен, давайте без него)");
                }
                else if (a < 0 | b < 0 | c < 0)
                {
                    textBox4.Text = "Результат произведения: " + Convert.ToString(a * b * c);
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(menu);
            form2.Show();
            this.Close();
        }
    }
}
    

