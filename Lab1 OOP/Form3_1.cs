using System.Collections.Generic;
using System.Windows.Forms;

namespace Lab1_OOP
{
    public partial class Form3_1 : Form
    {
        private Button button;
        public Form3_1()
        {
            InitializeComponent();
        }
        public Form3_1(List<List<int>> result, Button button)
        {
            InitializeComponent();
            dataGridView1.RowCount = result.Count;
            dataGridView1.ColumnCount = result[0].Count;
            for (int i = 0; i < result.Count; i++)
            {
                for (int j = 0; j < result[i].Count; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = result[i][j];
                }
            }
            this.button = button;
            Show();
        }

        private void enable_button(object sender, FormClosedEventArgs e)
        {
            button.Enabled = true;
        }
    }
}
