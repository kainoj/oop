namespace factory {


    public interface IShape {
        int length { get; set; }
    }


    public class Rectangle : IShape {
        public int length { get; set; }
        public int width  { get; set; }

        public Rectangle(int length, int width) {
            this.length = length;
            this.width = width;
        }
    }


    public class Square : IShape {

        public int length { get; set; }

        public Square(int length) {
            this.length = length;
        }

    }


}