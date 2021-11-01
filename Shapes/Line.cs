using GraphicEditor.Visitors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicEditor.Shapes
{
    /// <summary>
    /// Фигура - линия
    /// </summary>
    public class Line : PointsShape
    {
        public Line()
        {
            AddPoint(new Point2D());
            AddPoint(new Point2D());
        }
        public Line(Point2D start, Point2D end)
        {
            AddPoint(start);
            AddPoint(end);
        }
        public Line(List<Point2D> points)
        {
            AddPoint(points[0]);
            AddPoint(points[1]);
        }
        /// <summary>
        /// Передвинуть конечную точку
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        public override void MoveEndPoint(int X, int Y)
        {
            Point2D end = GetPoint(1);
            end.SetCoordinates(X, Y);
        }
        public override void Accept(IBaseVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
