using GraphicEditor.Shapes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicEditor.Visitors
{
    public class ShapeButtonVisitor : IBaseVisitor
    {
        private FlowLayoutPanel shapesContainer;
        public Type currentSelectedShape { get; private set; }
        public ShapeButtonVisitor(FlowLayoutPanel shapesContainer)
        {
            this.shapesContainer = shapesContainer;
            currentSelectedShape = typeof(Line);
        }
        public void Visit(Line line)
        {
            Button button = new Button();
            button.BackColor = Color.White;
            button.Size = new Size(20, 20);
            Bitmap image = new Bitmap(20,20);

            Pen pen = new Pen(Color.Black);

            Graphics g = Graphics.FromImage(image);
            g.DrawLine(new Pen(Color.Black), 5, 5, 15, 15);

            button.MouseClick += new MouseEventHandler(delegate (object sender, MouseEventArgs e) {
                currentSelectedShape = typeof(Line);
            });
            button.Image = image;
            shapesContainer.Controls.Add(button);
        }
        public void Visit(GraphicEditor.Shapes.Rectangle rectangle)
        {
            Button button = new Button();
            button.BackColor = Color.White;
            button.Size = new Size(20, 20);
            Bitmap image = new Bitmap(20, 20);

            Pen pen = new Pen(Color.Black);

            Graphics g = Graphics.FromImage(image);
            g.DrawRectangle(new Pen(Color.Black), 5, 5, 10, 10);
           

            button.MouseClick += new MouseEventHandler(delegate (object sender, MouseEventArgs e) {
                currentSelectedShape = typeof(GraphicEditor.Shapes.Rectangle);
            });
            button.Image = image;
            shapesContainer.Controls.Add(button);
        }
        public void Visit(Triangle triangle)
        {
            Button button = new Button();
            button.BackColor = Color.White;
            button.Size = new Size(20, 20);
            Bitmap image = new Bitmap(20, 20);

            Pen pen = new Pen(Color.Black);

            Graphics g = Graphics.FromImage(image);
            g.DrawLine(new Pen(Color.Black),5,15,15,15);
            g.DrawLine(new Pen(Color.Black),10,5,15,15);
            g.DrawLine(new Pen(Color.Black),10,5,5,15);
            
            button.MouseClick += new MouseEventHandler(delegate (object sender, MouseEventArgs e) {
                currentSelectedShape = typeof(Triangle);
            });
            button.Image = image;
            shapesContainer.Controls.Add(button);
        }
        public void Visit(Circle circle)
        {
            Button button = new Button();
            button.BackColor = Color.White;
            button.Size = new Size(20, 20);
            Bitmap image = new Bitmap(20, 20);

            Pen pen = new Pen(Color.Black);

            Graphics g = Graphics.FromImage(image);
            g.DrawEllipse(new Pen(Color.Black), 5, 5, 10, 10);

            button.MouseClick += new MouseEventHandler(delegate (object sender, MouseEventArgs e) {
                currentSelectedShape = typeof(Circle);
            });
            button.Image = image;
            shapesContainer.Controls.Add(button);
        }
    }
}
