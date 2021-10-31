using GraphicEditor.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicEditor.Helpers
{
    public static class GeometryFunctions
    {
        /// <summary>
        /// Функция проверяющая, принадлежит ли точка отрезку
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        public static bool IsPointAffilationLine(Point2D start, Point2D end, Point2D point, double epsilon = 5)
        {
            if (point.X - Math.Max(start.X, end.X) > epsilon ||
                  Math.Min(start.X, end.X) - point.X > epsilon ||
                  point.Y - Math.Max(start.Y, end.Y) > epsilon ||
                  Math.Min(start.Y, end.Y) - point.Y > epsilon)
                return false;

            if (Math.Abs(end.X - start.X) < epsilon)
                return Math.Abs(start.X - point.X) < epsilon || Math.Abs(end.X - point.X) < epsilon;
            if (Math.Abs(end.Y - start.Y) < epsilon)
                return Math.Abs(start.Y - point.Y) < epsilon || Math.Abs(end.Y - point.Y) < epsilon;

            double x = start.X + (point.Y - start.Y) * (end.X - start.X) / (end.Y - start.Y);
            double y = start.Y + (point.X - start.X) * (end.Y - start.Y) / (end.X - start.X);

            return Math.Abs(point.X - x) < epsilon || Math.Abs(point.Y - y) < epsilon;
        }

        public static bool IsPointInRectangle(Point2D start, Point2D end, Point2D point)
        {
            return ((start.X <= point.X && point.X <= end.X) || (end.X <= point.X && point.X <= start.X))
                && ((start.Y <= point.Y && point.Y <= end.Y) || (end.Y <= point.Y && point.Y <= start.Y));

        }
        public static bool IsPointInTriangle(Point2D start, Point2D middle, Point2D end, Point2D point)
        {
            float d1, d2, d3;
            bool has_neg, has_pos;

            d1 = Sign(point, start, middle);
            d2 = Sign(point, middle, end);
            d3 = Sign(point, end, start);

            has_neg = (d1 < 0) || (d2 < 0) || (d3 < 0);
            has_pos = (d1 > 0) || (d2 > 0) || (d3 > 0);

            return !(has_neg && has_pos);
        }
        private static float Sign(Point2D p1, Point2D p2, Point2D p3)
        {
            return (p1.X - p3.X) * (p2.Y - p3.Y) - (p2.X - p3.X) * (p1.Y - p3.Y);
        }
        public static bool IsPointInCircle(Point2D start, Point2D end, Point2D point)
        {
            Point2D center = GetCircleCenter(start, end);
            double radius = GetCircleRadius(start, end);
            return Math.Pow((point.X - center.X), 2) + Math.Pow((point.Y - center.Y), 2) < Math.Pow(radius, 2);
        }
        public static Point2D GetCircleCenter(Point2D start, Point2D end)
        {
            return new Point2D((start.X + end.X) / 2, (start.Y + end.Y) / 2);
        }
        public static double GetCircleRadius(Point2D start, Point2D end)
        {
            return Math.Sqrt(Math.Pow((end.X - start.X), 2) + Math.Pow((end.Y - start.Y), 2))/2;
        }
    }
}
