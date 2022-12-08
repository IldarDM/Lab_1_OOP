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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Money money = new Money(long.Parse(textBox1.Text), int.Parse(textBox2.Text));
                double num = double.Parse(textBox3.Text);
                textBox4.Text = money.Summary(num).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "АШИБГА");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Money money = new Money(long.Parse(textBox1.Text), int.Parse(textBox2.Text));
                double num = double.Parse(textBox3.Text);
                textBox4.Text = money.Minus(num).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "АШИБГА");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Money money = new Money(long.Parse(textBox1.Text), int.Parse(textBox2.Text));
                double num = double.Parse(textBox3.Text);
                textBox4.Text = money.Delenie(num).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "АШИБГА");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Money money = new Money(long.Parse(textBox1.Text), int.Parse(textBox2.Text));
                double num = double.Parse(textBox3.Text);
                textBox4.Text = money.Umnozhit(num).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "АШИБГА");
            }
        }
    }
    public class Money
    {
        public long rub;
        public int kop;
        public double sum;

        public Money(long rub, int kop)
        {
            if (kop > 99)
            {
                throw new Exception("Копейки - это от 0 до 100");
            }
            this.rub = rub;
            this.kop = kop;
            if (rub > 0)
            {
                sum = kop;
            }
            else
            {
                sum = -kop;
            }
            sum /= 100;
            sum += rub;
        }
    
        public double Summary(double num)
        {
            return sum += num;
        }

        public double Minus(double num)
        {
            return sum -= num;
        }

        public double Umnozhit(double num)
        {
            return sum *= num;
        }

        public double Delenie(double num)
        {
            return sum / num;
        }
    }
        
}
