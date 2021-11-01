using GraphicEditor.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicEditor.Visitors
{
    public interface IBaseVisitor
    { 
        public abstract void Visit(Line line);
        public abstract void Visit(Rectangle rectangle);
        public abstract void Visit(Triangle triangle);
        public abstract void Visit(Circle circle);
    }
}
