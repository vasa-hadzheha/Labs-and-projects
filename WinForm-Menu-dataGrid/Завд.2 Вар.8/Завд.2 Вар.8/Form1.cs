using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Завд._2_Вар._8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.RowCount= (int)Rows.Value;
            dataGridView1.ColumnCount = (int)Columns.Value;
        }

        private void Rows_ValueChanged(object sender, EventArgs e)
        {
            dataGridView1.RowCount = (int)Rows.Value;
            згенеруватиМасивToolStripMenuItem_Click(this, e);
        }

        private void Columns_ValueChanged(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = (int)Columns.Value;
            згенеруватиМасивToolStripMenuItem_Click(this, e);
        }

        private void згенеруватиМасивToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Random rand = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                for (int j = 0; j < dataGridView1.RowCount; j++)
                {
                    dataGridView1[i,j].Value= rand.Next(-100, 100);
                }
            }
        }

        private void знайтиНайбільшийЕлементToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //створюємо новий масий в який копіюємо всі елементи dataGridView1
            double[,] arr = new double[dataGridView1.ColumnCount, dataGridView1.RowCount];
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                for (int j = 0; j < dataGridView1.RowCount; j++)
                {
                    arr[i, j] = Convert.ToDouble(dataGridView1[i, j].Value);
                }
            }
            //знаходимо найбільший елемент динамічно створеного масиву
            double maxEl=arr[0,0];
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                for (int j = 0; j < dataGridView1.RowCount; j++)
                {
                    if (maxEl < arr[i, j])
                    {
                        maxEl = arr[i, j];
                    }
                }
            }
            //Виводимо найбільший елемент у textBox
            textBox1.Text = maxEl.ToString();
        }

        private void зберегтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sr = new StreamWriter(saveFileDialog1.FileName);
                sr.WriteLine(dataGridView1.ColumnCount);
                sr.WriteLine(dataGridView1.RowCount);
                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    for (int j = 0; j < dataGridView1.RowCount; j++)
                    {
                        sr.WriteLine(dataGridView1[i, j].Value);
                    }
                    //sr.WriteLine("-----------------------");
                }
                sr.Close();
            }
        }

        private void завантажитиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(openFileDialog1.FileName);
                Columns.Value = Convert.ToInt32(sr.ReadLine());
                Rows.Value = Convert.ToInt32(sr.ReadLine());
                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    for (int j = 0; j < dataGridView1.RowCount; j++)
                    {
                        dataGridView1[i, j].Value = sr.ReadLine();
                    }
                }
                sr.Close();
            }
        }
    }
}
