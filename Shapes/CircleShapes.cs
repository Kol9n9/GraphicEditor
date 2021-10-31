using GraphicEditor.Visitors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicEditor.Shapes
{
    public abstract class CircleShapes : BaseShape
    {
        private Point2D startPoint;
        private Point2D endPoint;
        
        public void SetStartPoint(Point2D point)
        {
            startPoint = point;
        }
        public void SetEndPoint(Point2D point)
        {
            endPoint = point;
        }
        public Point2D GetStartPoint()
        {
            return startPoint;
        }
        public Point2D GetEndPoint()
        {
            return endPoint;
        }
        public abstract override void MoveEndPoint(int X, int Y);
        public abstract override void Accept(BaseVisitor visitor);
    }
}
