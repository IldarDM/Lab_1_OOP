using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1_OOP
{
    public partial class Form5 : Form
    {
        private FormMenu menu;
        private List<List<double>> matrix { get; set; }
        private List<List<double>> t_matrix { get; set; }
        public Form5()
        {
            InitializeComponent();
        }

        public Form5(FormMenu fm)
        {
            InitializeComponent();
            menu = fm;
            this.matrix = new List<List<double>>();
            this.t_matrix = new List<List<double>>();
            menu.Hide();
        }

        private void Back_to_menu_click(object sender, EventArgs e)
        {
            menu.Show();
            this.Close();
        }

        private void Previous_task_click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4(menu);
            form4.Show();
            this.Close();
        }

        private void show_task_button(object sender, EventArgs e)
        {
            MessageBox.Show("Написать программу, выполняющую транспонирование неквадратной\r\nматрицы. Матрицы должны храниться в памяти в виде двумерного\r\nдинамического массива, размерности матриц вводятся пользователем с\r\nклавиатуры. Предусмотреть генерацию значений матриц как\r\nслучайных вещественных чисел в диапазоне от -2.0 до 2.0", "Задание на работу");
        }

        private void create_table_button(object sender, EventArgs e)
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
                    if (row_num == col_num)
                    {
                        MessageBox.Show("Матрица должна быть не квадратной!", "Ашипка");
                        return;
                    }
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
        private void generate_table_values(object sender, EventArgs e)
        {
            Random random = new Random();
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = Math.Round(random.NextDouble() * (2.0 + 2.0) - 2.0, 3);
                }
            }
        }
        private void do_task_button(object sender, EventArgs e)
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
            if (matrix.Count != 0)
            {
                matrix.Clear();
            }
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                List<double> row = new List<double>();
                this.matrix.Add(row);
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                {
                    this.matrix[i].Add(Convert.ToDouble(dataGridView1.Rows[i].Cells[j].Value));
                }
            }
            if (t_matrix.Count != 0)
            {
                t_matrix.Clear();
            }
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                List<double> t_row = new List<double>();
                this.t_matrix.Add(t_row);
                for (int j = 0; j < dataGridView1.RowCount; j++)
                {
                    this.t_matrix[i].Add(matrix[j][i]);
                }
            }
            Form5_1 answer = new Form5_1(this.t_matrix);
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
