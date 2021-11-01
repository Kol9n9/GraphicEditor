using GraphicEditor.Shapes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicEditor.Visitors
{
    class SaveShapesVisitor : IBaseVisitor
    {
        private StreamWriter fileStream;
        public SaveShapesVisitor(StreamWriter FileStream)
        {
            fileStream = FileStream;
        }
        public void Visit(Line line)
        {
            string res = $"<line color={line.ShapeColor.Name} width={line.ShapeLineWidth}>";
            Point2D start = line.GetPoint(0);
            Point2D end = line.GetPoint(1);
            res += $"\n  <point x={start.X} y={start.Y}></point>";
            res += $"\n  <point x={end.X} y={end.Y}></point>";
            res += "\n</line>";
            fileStream.WriteLine(res);
        }

        public void Visit(Rectangle rectangle)
        {
            Point2D start = rectangle.GetPoint(0);
            Point2D end = rectangle.GetPoint(1);
            string res = $"<rectangle color={rectangle.ShapeColor.Name} width={rectangle.ShapeLineWidth}>";
            res += $"\n  <point x={start.X} y={start.Y}></point>";
            res += $"\n  <point x={end.X} y={start.Y}></point>";
            res += $"\n  <point x={end.X} y={end.Y}></point>";
            res += $"\n  <point x={start.X} y={end.Y}></point>";
            res += "\n</rectangle>";
            fileStream.WriteLine(res);
        }
        public void Visit(Triangle triangle)
        {
            string res = $"<triangle color={triangle.ShapeColor.Name} width={triangle.ShapeLineWidth}>";
            Point2D start = triangle.GetPoint(0);
            Point2D middle = triangle.GetPoint(1);
            Point2D end = triangle.GetPoint(2);
            res += $"\n  <point x={start.X} y={start.Y}></point>";
            res += $"\n  <point x={middle.X} y={middle.Y}></point>";
            res += $"\n  <point x={end.X} y={end.Y}></point>";
            res += "\n</triangle>";
            fileStream.WriteLine(res);
        }
        public void Visit(Circle circle)
        {
            string res = $"<line color={circle.ShapeColor.Name} width={circle.ShapeLineWidth}>";
            Point2D start = circle.GetStartPoint();
            Point2D end = circle.GetEndPoint();
            res += $"\n  <point x={start.X} y={start.Y}></point>";
            res += $"\n  <point x={end.X} y={end.Y}></point>";
            res += "\n</line>";
            fileStream.WriteLine(res);
        }
    }
}
