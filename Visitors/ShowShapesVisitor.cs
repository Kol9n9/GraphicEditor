using GraphicEditor.Helpers;
using GraphicEditor.Shapes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicEditor.Visitors
{
    public class ShowShapesVisitor : BaseVisitor
    {
        public Graphics graphics { get;  set; }
        public ShowShapesVisitor()
        {
        }
        public void Visit(Line line)
        {
            List<Point2D> points = line.GetPoints();
            Point2D start = points[0];
            Point2D end = points[1];
            Pen pen = new Pen(line.ShapeColor, line.ShapeLineWidth);
            graphics.DrawLine(pen, start.X, start.Y, end.X, end.Y);
            if (line.IsSelected)
            {
                graphics.DrawRectangle(new Pen(Color.Blue), new System.Drawing.Rectangle(start.X - 2, start.Y - 2, 5, 5));
                graphics.DrawRectangle(new Pen(Color.Blue), new System.Drawing.Rectangle(end.X, end.Y - 2, 5, 5));
            }
        }
        public void Visit(Shapes.Rectangle rectangle)
        {
            Pen pen = new Pen(rectangle.ShapeColor, rectangle.ShapeLineWidth);
            List<Point2D> points = rectangle.GetPoints();
            Point2D start = points[0];
            Point2D end = points[1];

            graphics.DrawLine(pen, start.X, start.Y, end.X, start.Y);
            graphics.DrawLine(pen, end.X, start.Y, end.X, end.Y);
            graphics.DrawLine(pen, end.X, end.Y, start.X, end.Y);
            graphics.DrawLine(pen, start.X, end.Y, start.X, start.Y);

            if (rectangle.IsSelected)
            {
                graphics.DrawRectangle(new Pen(Color.Blue), new System.Drawing.Rectangle(start.X - 2, start.Y - 2, 5, 5));
                graphics.DrawRectangle(new Pen(Color.Blue), new System.Drawing.Rectangle(end.X, end.Y - 2, 5, 5));
            }
        }
        public void Visit(Triangle triangle)
        {
            List<Point2D> points = triangle.GetPoints();
            Point2D start = points[0];
            Point2D middle = points[1];
            Point2D end = points[2];
            Pen pen = new Pen(triangle.ShapeColor, triangle.ShapeLineWidth);
            graphics.DrawLine(pen, start.X, start.Y, middle.X, middle.Y);
            graphics.DrawLine(pen, middle.X, middle.Y, end.X, end.Y);
            graphics.DrawLine(pen, start.X, start.Y, end.X, end.Y);
            if (triangle.IsSelected)
            {
                graphics.DrawRectangle(new Pen(Color.Blue), new System.Drawing.Rectangle(start.X - 2, start.Y - 2, 5, 5));
                graphics.DrawRectangle(new Pen(Color.Green), new System.Drawing.Rectangle(middle.X - 2, middle.Y - 2, 5, 5));
                graphics.DrawRectangle(new Pen(Color.Blue), new System.Drawing.Rectangle(end.X, end.Y - 2, 5, 5));
            }
        }
        public void Visit(Circle circle)
        {
            Point2D start = circle.GetStartPoint();
            Point2D end = circle.GetEndPoint();
            double radius = GeometryFunctions.GetCircleRadius(start, end);
                
            Pen pen = new Pen(circle.ShapeColor, circle.ShapeLineWidth);
            graphics.DrawEllipse(pen, start.X, start.Y, (float)radius * 2, (float)radius * 2);

            if (circle.IsSelected)
            {
                graphics.DrawRectangle(new Pen(Color.Blue), new System.Drawing.Rectangle(start.X - 2, start.Y - 2, 5, 5));
                graphics.DrawRectangle(new Pen(Color.Blue), new System.Drawing.Rectangle(end.X, end.Y - 2, 5, 5));
            }
        }
    }
}
