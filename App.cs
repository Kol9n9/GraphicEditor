using GraphicEditor.Helpers;
using GraphicEditor.Shapes;
using GraphicEditor.Visitors;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicEditor
{
    public class App
    {
        private List<BaseShape> shapes;
        private ResizeShapeVisitor resizeShapeVisitor;
        private BaseShape currentShape;
        private ShapeButtonVisitor shapeButtonVisitor;
        private StartMoveShapeVisitor startMoveShapeVisitor;
        private MovingShapeVisitor movingShapeVisitor;
        private DrawShapeVisitor  drawShapeVisitor;
        private Color currentColor;
        private float lineWidth;

        private bool IsDrawing;
        private bool IsStartDrawing;

        public App(FlowLayoutPanel shapesContainer, FlowLayoutPanel colorsContainer)
        {
            shapes = new List<BaseShape>();
            resizeShapeVisitor = new ResizeShapeVisitor();
            shapeButtonVisitor = new ShapeButtonVisitor(shapesContainer);
            startMoveShapeVisitor = new StartMoveShapeVisitor();
            movingShapeVisitor = new MovingShapeVisitor();
            drawShapeVisitor = new DrawShapeVisitor();
            currentColor = Color.Black;
            lineWidth = 1f;
            IsDrawing = false;
            DrawShapesButton();
            FillColorsContainers(colorsContainer);
        }
        private void DrawShapesButton()
        {
            Line line = new Line();
            Shapes.Rectangle rectangle = new Shapes.Rectangle();
            Triangle triangle = new Triangle();
            Circle circle = new Circle();
            line.Accept(shapeButtonVisitor);
            rectangle.Accept(shapeButtonVisitor);
            triangle.Accept(shapeButtonVisitor);
            circle.Accept(shapeButtonVisitor);
        }
        private void FillColorsContainers(FlowLayoutPanel colorsContainer)
        {
            foreach(var color in ColorsEnum.colors)
            {
                Button button = new Button();
                button.BackColor = color;
                button.Size = new Size(20, 20);
                button.Click += new EventHandler(delegate (object sender, EventArgs e)
                {
                    currentColor = color;
                });
                colorsContainer.Controls.Add(button);
            }
        }
        private void StartDraw(int X, int Y)
        {
            Type type = shapeButtonVisitor.currentSelectedShape;
            if (type == null) return;
            List<Point2D> typeParam = new List<Point2D>();
            typeParam.Add(new Point2D(X, Y));
            typeParam.Add(new Point2D(X+1, Y));
            currentShape = (BaseShape)Activator.CreateInstance(type,typeParam);
            currentShape.ShapeColor = currentColor;
            currentShape.ShapeLineWidth = lineWidth;
            shapes.Add(currentShape);
            IsStartDrawing = false;
        }
        private void Draw(int X, int Y)
        {
            if (IsStartDrawing)
            {
                StartDraw(X, Y);
            } 
            else
            {
                drawShapeVisitor.X = X;
                drawShapeVisitor.Y = Y;
                currentShape.Accept(drawShapeVisitor);
            }
        }
        private void ResizeShape(int X, int Y)
        {
            resizeShapeVisitor.CurrentPoint.SetCoordinates(X, Y);
        }
        private void MoveShape(int X, int Y)
        {
            movingShapeVisitor.X = X;
            movingShapeVisitor.Y = Y;
            movingShapeVisitor.Offset = startMoveShapeVisitor.Offset;
            startMoveShapeVisitor.CurrentShape.Accept(movingShapeVisitor);
            
        }
        public void ProcessDraw(Graphics graphics, int X, int Y)
        {
            graphics.Clear(Color.White);
            var showShapesVisitor = new ShowShapesVisitor(graphics);

            if (IsDrawing) Draw(X, Y);
            if (resizeShapeVisitor.IsShapeResized) ResizeShape(X, Y);
            if (startMoveShapeVisitor.IsMovedShape) MoveShape(X, Y);

            foreach (var shape in shapes)
            {
                shape.Accept(showShapesVisitor);
            }
        }
        public void ClickShape(int X, int Y)
        {
            var clickShapeVisitor = new ClickShapeVisitor(X, Y);
            foreach (var shape in shapes)
            {
                shape.SetSelected(false);
            }
            foreach(var shape in shapes)
            {
                shape.Accept(clickShapeVisitor);
                if (shape.IsSelected) break;
            }
        }
        public void SetLineWidth(float width)
        {
            lineWidth = width;
        }
        public void SaveAsGEF(string fileName)
        {
            
            using(StreamWriter sw = File.CreateText(fileName))
            {
                var saveVisitor = new SaveShapesVisitor(sw);
                foreach (var shape in shapes)
                {
                    shape.Accept(saveVisitor);
                }
            }
        }
        public void LeftMouseDown(int X, int Y)
        {

            resizeShapeVisitor.X = X;
            resizeShapeVisitor.Y = Y;

            foreach(var shape in shapes)
            {
                shape.Accept(resizeShapeVisitor);
                if (resizeShapeVisitor.IsShapeResized) return;
            }
            startMoveShapeVisitor.X = X;
            startMoveShapeVisitor.Y = Y;

            foreach(var shape in shapes)
            {
                shape.Accept(startMoveShapeVisitor);
                if (startMoveShapeVisitor.IsMovedShape) return;
            }

            IsDrawing = true;
            IsStartDrawing = true;
        }
        public void LeftMouseUp()
        {
            IsDrawing = false;
            resizeShapeVisitor.IsShapeResized = false;
            startMoveShapeVisitor.IsMovedShape = false;
        }
    }
    
}
