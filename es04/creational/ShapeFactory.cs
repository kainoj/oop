using System.Collections.Generic;

namespace factory {

    public class ShapeFactory {

        List <IShapeFactoryWorker> workers = new List<IShapeFactoryWorker>();

        public ShapeFactory() {
            workers.Add(new SquareFactoryWorker());
        }

        public void RegisterWorker(IShapeFactoryWorker worker) {
            workers.Add(worker);
        }

        public IShape CreateShape(string ShapeName, params object[] parameters) {

            foreach(IShapeFactoryWorker worker in workers) {
                if (worker.Name == ShapeName) {
                    return worker.CreateShape(parameters);
                }
            }
            throw new System.Exception("No shape found");
        }
    }

}