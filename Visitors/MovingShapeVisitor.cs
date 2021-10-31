using GraphicEditor.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicEditor.Visitors
{
    public class MovingShapeVisitor : BaseVisitor
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Point2D Offset { get; set; }
        public void Visit(Line line)
        {
            Point2D start = line.GetPoint(0);
            Point2D end = line.GetPoint(1);

            int newStartX = X - Offset.X;
            int newStartY = Y - Offset.Y;

            int offsetX = newStartX - start.X;
            int offsetY = newStartY - start.Y;

            start.SetCoordinates(newStartX, newStartY);
            end.SetCoordinates(end.X + offsetX, end.Y + offsetY);
        }

        public void Visit(Rectangle rectangle)
        {
            Point2D start = rectangle.GetPoint(0);
            Point2D end = rectangle.GetPoint(1);

            int newStartX = X + Offset.X;
            int newStartY = Y + Offset.Y;

            int offsetX = newStartX - start.X;
            int offsetY = newStartY - start.Y;

            start.SetCoordinates(newStartX, newStartY);
            end.SetCoordinates(end.X + offsetX, end.Y + offsetY);
        }

        public void Visit(Triangle triangle)
        {
            Point2D start = triangle.GetPoint(0);
            Point2D end = triangle.GetPoint(2);

            int newStartX = X + Offset.X;
            int newStartY = Y + Offset.Y;

            int offsetX = newStartX - start.X;
            int offsetY = newStartY - start.Y;

            start.SetCoordinates(newStartX, newStartY);
            triangle.MoveEndPoint(end.X + offsetX, end.Y + offsetY);
        }
        public void Visit(Circle circle)
        {
            Point2D start = circle.GetStartPoint();
            Point2D end = circle.GetEndPoint();

            int newStartX = X + Offset.X;
            int newStartY = Y + Offset.Y;

            int offsetX = newStartX - start.X;
            int offsetY = newStartY - start.Y;

            start.SetCoordinates(newStartX, newStartY);
            end.SetCoordinates(end.X + offsetX, end.Y + offsetY);
        }
    }
}
