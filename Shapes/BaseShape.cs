using GraphicEditor.Visitors;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicEditor.Shapes
{
    /// <summary>
    /// Базовый класс фигур
    /// </summary>
    public abstract class BaseShape
    {
        public bool IsSelected { get; private set; }
        public Color ShapeColor { get; set; }
        public float ShapeLineWidth { get; set; }
        /// <summary>
        /// Передвинуть конечную точку
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        public abstract void MoveEndPoint(int X, int Y);


        public abstract void Accept(IBaseVisitor visitor);
        /// <summary>
        /// Установить флаг выбранной фигуры
        /// </summary>
        /// <param name="selected"></param>
        public void SetSelected(bool selected)
        {
            IsSelected = selected;
        }
    }
}
