namespace  Ex4b
{
    public interface IShape {
        int Area();
    }

    public class Rectangle : IShape {

        public virtual int Width { get; set; }
        public virtual int Height { get; set; }

        public int Area() {
            return Width * Height;
        }
    }

    public class Square : IShape {
        public int height { get; set; }

        public int Area() {
            return height * height;
        }
    }

}


