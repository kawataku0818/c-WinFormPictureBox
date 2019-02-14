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
    public partial class Form1 : Form
    {
        Form2 form2 = new Form2();
        event EventHandler GetPoint;


        public Worker[] worker { get; set; } = new Worker[3] { new Worker(), new Worker(), new Worker()};
        public Form1()
        {
            InitializeComponent();
            form2.Show();
            var temp = new Bitmap(10, 10);
            var g = Graphics.FromImage(temp);
            g.DrawEllipse(Pens.Blue, 0, 0, temp.Width, temp.Height);
            worker[0].bitmap = new Bitmap(temp);
            g.Clear(Color.White);
            g.DrawEllipse(Pens.Yellow, 0, 0, temp.Width, temp.Height);
            worker[1].bitmap = new Bitmap(temp);
            g.Clear(Color.White);
            g.DrawEllipse(Pens.Red, 0, 0, temp.Width, temp.Height);
            worker[2].bitmap = new Bitmap(temp);
            g.Dispose();
            temp.Dispose();
        }

        Random random = new Random();
        private async void button1_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                while (true)
                {
                    worker[0].point.X = random.Next(0, pictureBox1.Width);
                    worker[0].point.Y = random.Next(0, pictureBox1.Height);
                    worker[1].point.X = random.Next(0, pictureBox1.Width);
                    worker[1].point.Y = random.Next(0, pictureBox1.Height);
                    worker[2].point.X = random.Next(0, pictureBox1.Width);
                    worker[2].point.Y = random.Next(0, pictureBox1.Height);
                }
            });

            await Task.Run(() =>
            {
                while (true)
                {
                    update();
                    //System.Threading.Thread.Sleep(10);
                }
            });
        }

        void update()
        {
            // グリッドの更新
            form2.SetDataGridView1(1, 1, worker[0].point.X);
            form2.SetDataGridView1(1, 1, worker[0].point.Y);
            form2.SetDataGridView1(1, 1, worker[1].point.X);
            form2.SetDataGridView1(1, 1, worker[1].point.Y);
            form2.SetDataGridView1(1, 1, worker[2].point.X);
            form2.SetDataGridView1(1, 1, worker[2].point.Y);

            Bitmap bitmap;

            bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            var g = Graphics.FromImage(bitmap);
            g.Clear(Color.White);
            g.DrawImage(worker[0].bitmap, worker[0].point);
            g.DrawImage(worker[1].bitmap, worker[1].point);
            g.DrawImage(worker[2].bitmap, worker[2].point);

            if (InvokeRequired)
            {
                Invoke(new Action<Bitmap>(updatePicture),bitmap);
            }
            else
            {
                updatePicture(bitmap);
            }
            g.Dispose();
            bitmap.Dispose();
            //System.Threading.Thread.Sleep(100);

        }

        void updatePicture(Bitmap bitmap)
        {
            pictureBox1.Image?.Dispose();
            pictureBox1.Image = bitmap;
            pictureBox1.Refresh();
        }

        


    }
}
