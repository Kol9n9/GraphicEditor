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
        public bool IsResized { get; private set; }
        public Color ShapeColor { get; set; }
        public float ShapeLineWidth { get; set; }
        public BaseShape()
        {
        }
        /// <summary>
        /// Передвинуть конечную точку
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        public virtual void MoveEndPoint(int X, int Y)
        {
            throw new Exception("BaseShape.MoveEndPoint Method must be overrided");
        }

        public virtual void Accept(IBaseVisitor visitor)
        {
            throw new Exception("BaseShape.Accept Method must be overrided");
        }
        /// <summary>
        /// Установить флаг выбранной фигуры
        /// </summary>
        /// <param name="selected"></param>
        public void SetSelected(bool selected)
        {
            IsSelected = selected;
        }
        public void SetResized(bool resized)
        {
            IsResized = resized;
        }
    }
}
