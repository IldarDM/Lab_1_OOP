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
    public partial class Form2 : Form
    {
        private FormMenu menu;
        public Form2()
        {
            InitializeComponent();
        }

        public Form2(FormMenu fm)
        {
            InitializeComponent();
            menu = fm;
            menu.Hide(); 
        }

        private void Previous_task_button4_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1(menu);
            form1.Show();
            this.Close();

        }

        private void Back_to_menu_button1_Click(object sender, EventArgs e)
        {
            menu.Show();
            this.Close();
        }

        private void Next_task_button3_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(menu);
            form3.Show();
            this.Close();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(textBox1.Text, out var check)
                | !double.TryParse(textBox2.Text, out check))
            {
                MessageBox.Show("Вводите действительные числа, а не всякую ерунду!");
            }
            else
            {
                double a = double.Parse(textBox1.Text);
                double b = double.Parse(textBox2.Text);
                if (a <= b)
                {
                    textBox3.Text = "0";
                    textBox4.Text = textBox2.Text;
                }
                else
                {
                    textBox3.Text = textBox1.Text;
                    textBox4.Text = textBox2.Text;
                }
            }
        }
    }
}
