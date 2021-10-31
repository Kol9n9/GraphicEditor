using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicEditor.Shapes
{
    public class Point2D
    {
        private static int MaxId = 0;
        /// <summary>
        /// X координата
        /// </summary>
        public int X { get; private set; }
        /// <summary>
        /// Y координата
        /// </summary>
        public int Y { get; private set; }
        /// <summary>
        /// Уникальный индентификатор точки
        /// </summary>
        public int Id { get; }
        public Point2D()
        {
            X = 0;
            Y = 0;
            Id = ++MaxId;
        }
        public Point2D(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
            Id = ++MaxId;
        }
        /// <summary>
        /// Установить новые координаты точки
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        public void SetCoordinates(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }
}
