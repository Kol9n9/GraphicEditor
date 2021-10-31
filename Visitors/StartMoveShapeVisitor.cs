using GraphicEditor.Helpers;
using GraphicEditor.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicEditor.Visitors
{
    public class StartMoveShapeVisitor : BaseVisitor
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsMovedShape { get; set; }
        public BaseShape CurrentShape { get; private set; }
        public Point2D Offset { get; set; }
        public void Visit(Line line)
        {
            Point2D start = line.GetPoint(0);
            Point2D end = line.GetPoint(1);
            Offset = new Point2D();

            if(GeometryFunctions.IsPointAffilationLine(start,end, new Point2D(X, Y)))
            {
                Offset.SetCoordinates(X - start.X, Y - start.Y);
                CurrentShape = line;
                IsMovedShape = true;
            }
        }

        public void Visit(Rectangle rectangle)
        {
            Point2D start = rectangle.GetPoint(0);
            Point2D end = rectangle.GetPoint(1);
            Offset = new Point2D();

            if (GeometryFunctions.IsPointInRectangle(start, end, new Point2D(X, Y)))
            {
                Offset.SetCoordinates(start.X - X, start.Y - Y);
                CurrentShape = rectangle;
                IsMovedShape = true;
            }
        }
        public void Visit(Triangle triangle)
        {
            Point2D start = triangle.GetPoint(0);
            Point2D middle = triangle.GetPoint(1);
            Point2D end = triangle.GetPoint(2);
            Offset = new Point2D();

            if (GeometryFunctions.IsPointInTriangle(start,middle, end, new Point2D(X, Y)))
            {
                Offset.SetCoordinates(start.X - X, start.Y - Y);
                CurrentShape = triangle;
                IsMovedShape = true;
            }
        }
        public void Visit(Circle circle)
        {
            Point2D start = circle.GetStartPoint();
            Point2D end = circle.GetEndPoint();
            Offset = new Point2D();
            if(GeometryFunctions.IsPointInCircle(start,end,new Point2D(X, Y)))
            {
                Offset.SetCoordinates(start.X - X, start.Y - Y);
                CurrentShape = circle;
                IsMovedShape = true;
            }
        }
    }
}
