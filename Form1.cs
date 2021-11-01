using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicEditor
{
    public partial class Form1 : Form
    {
        private App app;

        private int lastX = -1;
        private int lastY = -1;
        public Form1()
        {
            InitializeComponent();
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                app.LeftMouseDown(e.X, e.Y);
            }
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            app.LeftMouseUp();
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            lastX = e.X;
            lastY = e.Y;
            pictureBox1.Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.White;
            DoubleBuffered = true;
            app = new App(shapesContainer, colorsContainer);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (lastX == -1 || lastY == -1) return;
            app.ProcessDraw(e.Graphics, lastX, lastY);
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var mouse = (MouseEventArgs)e;
            app.ClickShape(mouse.X, mouse.Y);
            pictureBox1.Invalidate();
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            app.SetLineWidth(trackBar1.Value);
            
        }

        private void saveAsJPG_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "JPG(*.JPG)|*.jpg";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                pictureBox1.DrawToBitmap(bmp, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height));
                bmp.Save(saveFileDialog1.FileName);
            }
           
        }
        private void saveAsPNG_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "PNG(*.PNG)|*.png";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                pictureBox1.DrawToBitmap(bmp, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height));
                bmp.Save(saveFileDialog1.FileName);
            }

        }
        private void saveAsGEF_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "GEF(*.GEF)|*.gef";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                app.SaveAsGEF(saveFileDialog1.FileName);
            }
        }
        private void appErrors_Click(object sender, EventArgs e)
        {
            string text = "Известные ошибки:\n";
            text += "1. Неправильная формула для нахождении точки треугольника\n";
            text += "2. Неправильная формула для отрисовки круга\n";
            text += "3. Нет возможности удалять фигуры\n";
            MessageBox.Show(text);
        }
        private void appInfo_Click(object sender, EventArgs e)
        {
            string text = "Graphic Editor:\n";
            text += "v 0.0.1\n";
            text += "Разработчик: Николай Слезенко\n";
            text += "E-mail: slezenkonikolay@mail.ru\n";
            MessageBox.Show(text);
        }
        private void appFeature_Click(object sender, EventArgs e)
        {
            string text = "Планы на следующее обновление:\n";
            text += "1. Исправление известных ошибок\n";
            text += "2. Добавление возможности открывать файлы формата GEF\n";
            text += "3. Добавление геометрических фигур(Ломанная и Произвоьная фигуры) \n";
            MessageBox.Show(text);
        }

    }
}
