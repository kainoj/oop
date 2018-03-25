using factory;
using NUnit.Framework;

namespace shapeFactoryTests {

    public class ShapeFactoryTest {

        [Test]
        public void shapeFactoryTest() {

            ShapeFactory factory = new ShapeFactory();
            IShape square = factory.CreateShape("Square", 5);

            Assert.AreEqual(5, square.length);

            // Extend factory
            factory.RegisterWorker( new RectangleFactoryWorker() );
            Rectangle rect = (Rectangle) factory.CreateShape("Rectangle", 3, 5);

            Assert.AreEqual(3, rect.length);
            Assert.AreEqual(5, rect.width);
        }
    }


}