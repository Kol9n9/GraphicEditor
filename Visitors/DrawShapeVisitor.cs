using GraphicEditor.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicEditor.Visitors
{
    class DrawShapeVisitor : IBaseVisitor
    {
        public int X { get; set; }
        public int Y { get; set; }
        public void Visit(Line line)
        {
            line.MoveEndPoint(X, Y);
        }

        public void Visit(Rectangle rectangle)
        {
            rectangle.MoveEndPoint(X, Y);
        }

        public void Visit(Triangle triangle)
        {
            triangle.MoveEndPoint(X, Y);
        }

        public void Visit(Circle circle)
        {
            circle.MoveEndPoint(X, Y);
        }
    }
}
