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
    public partial class Form5_1 : Form
    {
        public Form5_1()
        {
            InitializeComponent();
        }
        public Form5_1(List<List<double>> t_matrix)
        {
            InitializeComponent();
            dataGridView1.RowCount = t_matrix.Count;
            dataGridView1.ColumnCount = t_matrix[0].Count;
            for (int i = 0; i < t_matrix.Count; i++)
            {
                for (int j = 0; j < t_matrix[i].Count; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = t_matrix[i][j];
                }
            }
            this.Show();
        }
    }
}
