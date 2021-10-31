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
    public class ShapeButtonVisitor : BaseVisitor
    {
        private FlowLayoutPanel shapesContainer;
        public Type currentSelectedShape { get; private set; }
        public ShapeButtonVisitor(FlowLayoutPanel shapesContainer)
        {
            this.shapesContainer = shapesContainer;
            currentSelectedShape = null;
        }
        public void Visit(Line line)
        {
            Button button = new Button();
            button.BackColor = Color.White;
            button.Size = new Size(20, 20);
            Bitmap image = new Bitmap(20,20);
            
            for(int i = 5; i < 15; i++)
            {
                image.SetPixel(i, i, Color.Black);
            }
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

            for (int i = 0; i < 20; i++)
            {
                image.SetPixel(i, 0, Color.Black);
                image.SetPixel(i, 19, Color.Black);
            }
            for (int i = 0; i < 20; i++)
            {
                image.SetPixel(0, i, Color.Black);
                image.SetPixel(19, i, Color.Black);
            }
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

            for (int i = 5; i < 15; i++)
            {
                image.SetPixel(i, i, Color.Black);
            }
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

            for (int i = 5; i < 15; i++)
            {
                image.SetPixel(i, i, Color.Red);
            }
            button.MouseClick += new MouseEventHandler(delegate (object sender, MouseEventArgs e) {
                currentSelectedShape = typeof(Circle);
            });
            button.Image = image;
            shapesContainer.Controls.Add(button);
        }
    }
}
