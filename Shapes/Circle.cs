using GraphicEditor.Visitors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicEditor.Shapes
{
    public class Circle : CircleShapes
    {
        public Circle()
        {
            SetStartPoint(new Point2D());
            SetEndPoint(new Point2D());
        }
        public Circle(List<Point2D> points)
        {
            SetStartPoint(points[0]);
            SetEndPoint(points[1]);
        }
        public override void Accept(BaseVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override void MoveEndPoint(int X, int Y)
        {
            Point2D end = GetEndPoint();
            end.SetCoordinates(X, Y);
        }
    }
}
