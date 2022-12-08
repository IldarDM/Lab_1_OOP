using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1_OOP
{
    public partial class Form4 : Form
    {
        private FormMenu menu;
        private List<double> arr;
        public Form4()
        {
            InitializeComponent();
        }

        public Form4(FormMenu fm)
        {
            InitializeComponent();
            menu = fm;
            arr = new List<double>();
            menu.Hide();
        }

        private void Previous_task_button4_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(menu);
            form3.Show();
            this.Close();
        }

        private void Back_to_menu_click(object sender, EventArgs e)
        {
            menu.Show();
            this.Close();
        }

        private void Next_task_click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5(menu);
            form5.Show();
            this.Close();
        }

        private void show_task_button(object sender, EventArgs e)
        {
            MessageBox.Show("Записать элементов прямоугольной матрицы в одномерный массив в\r\nпорядке следования столбцов.", "Задание на работу");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text, out var check)
                | !int.TryParse(textBox2.Text, out check))
            {
                MessageBox.Show("Вводите целые числа больше 1, а не всякую ерунду!", "Ашипка");
            }
            else
            {
                if (int.Parse(textBox1.Text) < 2
                    | int.Parse(textBox2.Text) < 2)
                {
                    MessageBox.Show("Вводите целые числа больше 1, а не всякую ерунду!", "Ашипка");
                }
                else
                {
                    int row_num = int.Parse(textBox1.Text);
                    int col_num = int.Parse(textBox2.Text);
                    if (dataGridView1.Columns.Count < col_num)
                    {
                        for (int i = dataGridView1.Columns.Count; i < col_num; i++)
                        {
                            dataGridView1.Columns.Add($"Column{i + 1}", $"Столбец {i + 1}");
                        }
                    }
                    else if (dataGridView1.Columns.Count > col_num)
                    {
                        for (int i = dataGridView1.Columns.Count; i > col_num; i--)
                        {
                            dataGridView1.Columns.RemoveAt(i - 1);
                        }
                    }
                    dataGridView1.RowCount = row_num;
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Проверка, что таблица существует
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Кто будет таблицу создавать, Печкин?", "Ашипка");
                return;
            }
            // Проверка на отсутствие пустых ячеек
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value == null)
                    {
                        MessageBox.Show("Таблицу создал, а ячейки кто будет заполнять, Пушкин?", "Ашипка");
                        return;
                    }
                }
            }
            if (arr.Count != 0)
            {
                arr.Clear();
            }
            if (textBox3.Text != "")
            {
                textBox3.Text = "";
            }
            // Задание
            for(int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                for(int j = 0; j < dataGridView1.RowCount; j++)
                {
                    arr.Add(Convert.ToDouble(dataGridView1.Rows[j].Cells[i].Value));
                    textBox3.Text += $"{Convert.ToString(arr[j + i*dataGridView1.RowCount])}   ";
                }
            }

        }

        private void cell_value_validate(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (!double.TryParse(e.FormattedValue.ToString(), out var check))
            {
                MessageBox.Show("Вводите действительные числа, а не всякую ерунду!", "Ашипка");
                e.Cancel = true;
            }
        }

    }
}
