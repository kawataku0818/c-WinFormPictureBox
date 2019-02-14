// https://www.sejuku.net/blog/58436
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        public Worker[] Workers { get; set; } = new Worker[3];
        
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // カラム数を指定
            dataGridView1.ColumnCount = 3;

            // カラム名を指定
            dataGridView1.Columns[0].HeaderText = "作業員";
            dataGridView1.Columns[1].HeaderText = "X";
            dataGridView1.Columns[2].HeaderText = "Y";

            // データを追加
            dataGridView1.Rows.Add("Aさん", 1, 2);
            dataGridView1.Rows.Add("Bさん", 3, 4);
            dataGridView1.Rows.Add("Cさん", 5, 6);
        }

        public void SetDataGridView1(int row, int column, double num)
        {
            dataGridView1[row, column].Value = num;
        }
    }
}
