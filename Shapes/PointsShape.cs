using GraphicEditor.Visitors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicEditor.Shapes
{
    /// <summary>
    /// Базовый класс фигур, у которых есть точки
    /// </summary>
    public abstract class PointsShape : BaseShape
    {
        /// <summary>
        /// Список точек
        /// </summary>
        private List<Point2D> points;
        public PointsShape()
        {
            points = new List<Point2D>();
        }
        /// <summary>
        /// Поиск точки по Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        private Point2D FindPoint(int Id)
        {
            return points.Find(q => q.Id == Id);
        }
        /// <summary>
        /// Добавить точку в список
        /// </summary>
        /// <param name="point"></param>
        public void AddPoint(Point2D point)
        {
            if (FindPoint(point.Id) != null) return;
            points.Add(point);
        }
        /// <summary>
        /// Удалить точку из списка
        /// </summary>
        /// <param name="point"></param>
        public void RemovePoint(Point2D point)
        {
            Point2D findPoint = FindPoint(point.Id);
            if (findPoint == null) return;
            points.Remove(findPoint);
        }
        /// <summary>
        /// Очистить список точек
        /// </summary>
        public void ClearPoints()
        {
            points.Clear();
        }
        /// <summary>
        /// Получить список всех точек
        /// </summary>
        /// <returns></returns>
        public List<Point2D> GetPoints()
        {
            return points;
        }
        /// <summary>
        /// Получить точку по индексу
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Point2D GetPoint(int index)
        {
            if(index < 0 || index > points.Count-1)
            {
                throw new Exception("Invalid index");
            }
            return points[index];
        }

        public abstract override void Accept(IBaseVisitor visitor);
        /// <summary>
        /// Передвинуть конечную точку
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        public abstract override void MoveEndPoint(int X, int Y);
    }
}
