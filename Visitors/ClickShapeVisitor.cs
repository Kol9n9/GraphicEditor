using GraphicEditor.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphicEditor.Helpers;
namespace GraphicEditor.Visitors
{
    public class ClickShapeVisitor : IBaseVisitor
    {
        public int X { get; set; }
        public int Y { get; set; }
        public void Visit(Line line)
        {
            List<Point2D> points = line.GetPoints();
            Point2D start = points[0];
            Point2D end = points[1];
            if(GeometryFunctions.IsPointAffilationLine(start,end,new Point2D(X, Y)))
            {
                line.SetSelected(true);
            }
        }

        public void Visit(Rectangle rectangle)
        {
            List<Point2D> points = rectangle.GetPoints();
            Point2D start = points[0];
            Point2D end = points[1];
            if(GeometryFunctions.IsPointInRectangle(start,end, new Point2D(X, Y)))
            {
                rectangle.SetSelected(true);
            }
        }

        public void Visit(Triangle triangle)
        {
            List<Point2D> points = triangle.GetPoints();
            Point2D start = points[0];
            Point2D middle = points[1];
            Point2D end = points[2];
            if(GeometryFunctions.IsPointInTriangle(start, middle, end, new Point2D(X, Y)))
            {
                triangle.SetSelected(true);
            }
        }
        public void Visit(Circle circle)
        {
            Point2D start = circle.GetStartPoint();
            Point2D end = circle.GetEndPoint();

            if(GeometryFunctions.IsPointInCircle(start,end,new Point2D(X, Y)))
            {
                circle.SetSelected(true);
            }
        }
    }
}
