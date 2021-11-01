using GraphicEditor.Visitors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicEditor.Shapes
{
    public class Rectangle : PointsShape
    {
        public Rectangle()
        {
            AddPoint(new Point2D());
            AddPoint(new Point2D());
        }
        public Rectangle(List<Point2D> points)
        {
            AddPoint(points[0]);
            AddPoint(points[1]);
        }
        public override void Accept(IBaseVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override void MoveEndPoint(int X, int Y)
        {
            Point2D end = GetPoint(1);
            end.SetCoordinates(X, Y);
        }
    }
}
