using System;

namespace factory {

    public interface IShapeFactoryWorker {
        
        string Name { get;}

        IShape CreateShape(params object[] p);
    }


    public class RectangleFactoryWorker : IShapeFactoryWorker {
        
        public string Name => "Rectangle";

        public IShape CreateShape(params object[] p) {
            return new Rectangle(Convert.ToInt32(p[0]), Convert.ToInt32(p[1]));
        }
    }

    public class SquareFactoryWorker : IShapeFactoryWorker
    {
        public string Name => "Square";

        public IShape CreateShape(params object[] p) {
            return new Square(Convert.ToInt32(p[0]));
        }
    }

}