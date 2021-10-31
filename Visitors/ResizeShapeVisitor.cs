using GraphicEditor.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicEditor.Visitors
{
    class ResizeShapeVisitor : BaseVisitor
    {
        public int X { get; set; }
        public int Y { get; set; }
        public bool IsShapeResized { get; set; }
        public Point2D CurrentPoint { get; private set; }
        public ResizeShapeVisitor()
        {
            IsShapeResized = false;
        }
        public void Visit(Line line)
        {
            if (!line.IsSelected) return;

            Point2D start = line.GetPoint(0);
            Point2D end = line.GetPoint(1);

            if((start.X - 2) <= X && X <= ((start.X - 2)+5) && start.Y <= Y && Y <= start.Y - 2 + 5)
            {
                CurrentPoint = start;
                IsShapeResized = true;
                return;
            }
            if ((end.X - 2) <= X && X <= ((end.X - 2) + 5) && end.Y <= Y && Y <= end.Y - 2 + 5)
            {
                CurrentPoint = end;
                IsShapeResized = true;
                return;
            }
        }

        public void Visit(Rectangle rectangle)
        {
            if (!rectangle.IsSelected) return;

            Point2D start = rectangle.GetPoint(0);
            Point2D end = rectangle.GetPoint(1);

            if ((start.X - 2) <= X && X <= ((start.X - 2) + 5) && start.Y <= Y && Y <= start.Y - 2 + 5)
            {
                CurrentPoint = start;
                IsShapeResized = true;
                return;
            }
            if ((end.X - 2) <= X && X <= ((end.X - 2) + 5) && end.Y <= Y && Y <= end.Y - 2 + 5)
            {
                CurrentPoint = end;
                IsShapeResized = true;
                return;
            }
        }
        public void Visit(Triangle triangle)
        {
            if (!triangle.IsSelected) return;
            Point2D start = triangle.GetPoint(0);
            Point2D middle = triangle.GetPoint(1);
            Point2D end = triangle.GetPoint(2);
            if ((start.X - 2) <= X && X <= ((start.X - 2) + 5) && start.Y <= Y && Y <= start.Y - 2 + 5)
            {
                CurrentPoint = start;
                IsShapeResized = true;
                return;
            }
            if ((middle.X - 2) <= X && X <= ((middle.X - 2) + 5) && middle.Y <= Y && Y <= middle.Y - 2 + 5)
            {
                CurrentPoint = middle;
                IsShapeResized = true;
                return;
            }
            if ((end.X - 2) <= X && X <= ((end.X - 2) + 5) && end.Y <= Y && Y <= end.Y - 2 + 5)
            {
                CurrentPoint = end;
                IsShapeResized = true;
                return;
            }
        }
        public void Visit(Circle circle)
        {
            if (!circle.IsSelected) return;

            Point2D start = circle.GetStartPoint();
            Point2D end = circle.GetEndPoint();

            if ((start.X - 2) <= X && X <= ((start.X - 2) + 5) && start.Y <= Y && Y <= start.Y - 2 + 5)
            {
                CurrentPoint = start;
                IsShapeResized = true;
                return;
            }
            if ((end.X - 2) <= X && X <= ((end.X - 2) + 5) && end.Y <= Y && Y <= end.Y - 2 + 5)
            {
                CurrentPoint = end;
                IsShapeResized = true;
                return;
            }
        }
    }
}
