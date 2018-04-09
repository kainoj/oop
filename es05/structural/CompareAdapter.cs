using System.Collections;

namespace adapter {

    public class IntCmp : IComparer {
        public int Compare(object x, object y) {
            return PuzzleAdapter.IntComparer((int)x, (int)y);
        }
    }

    public class PuzzleAdapter {

        public static int IntComparer(int x, int y) {
            /*
            Returns:
               < 0    <=>   x < y
               = 0    <=>   x = y
               > 0    <=>   x > y
             */
            return x.CompareTo(y);
        }

        public ArrayList puzzle() {
            ArrayList a = new ArrayList() { 1, 5, 3, 3, 2, 4, 3 };

            /* the ArrayList's Sort method accepts ONLY an IComparer */

            // a.Sort( how to pass the IntComparer here ? );
            a.Sort(new IntCmp());
            return a;  
        }
    }
}