using GraphicEditor.Visitors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicEditor.Shapes
{
    public class Triangle : PointsShape
    {
        public Triangle()
        {
            AddPoint(new Point2D());
            AddPoint(new Point2D());
            AddPoint(new Point2D());
        }
        public Triangle(List<Point2D> points)
        {
            Point2D start = points[0];
            Point2D end = points[1];
            start.SetCoordinates(start.X, end.Y);
            Point2D middle = FindUpPoint(start, end);
            AddPoint(start);
            AddPoint(middle);
            AddPoint(end);
        }
        public override void Accept(IBaseVisitor visitor)
        {
            visitor.Visit(this);
        }
        private Point2D FindUpPoint(Point2D start, Point2D end)
        {
            int length = Math.Abs(end.X - start.X);
            int x = length / 2 + start.X;
            int y = length * 2 / 3;
            return new Point2D(x, y);
        }
        public override void MoveEndPoint(int X, int Y)
        {
            Point2D start = GetPoint(0);
            Point2D middle = GetPoint(1);
            Point2D end = GetPoint(2);
            start.SetCoordinates(start.X, end.Y);
            end.SetCoordinates(X, Y);
            Point2D calcMiddle = FindUpPoint(start, end);
            middle.SetCoordinates(calcMiddle.X, calcMiddle.Y);
        }
    }
}
