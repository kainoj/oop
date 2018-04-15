using NUnit.Framework;
using visitor2;

namespace tests {

    public class TreeVisitor2Test {

        [Test]
        public void test() {
            //      ____r____
            //   __l__     __r
            //  ll   lr   rl
            Tree root = new TreeNode() {
                            left = new TreeNode() {
                                left = new TreeLeaf(),
                                right = new TreeLeaf() },
                            right = new TreeNode() {
                                left = new TreeLeaf()
                            }
                        };
            
            HeightVisitor visitor = new HeightVisitor();
            visitor.visit(root);
            Assert.AreEqual(2, visitor.height);
        }

        [Test]
        public void bigTreeHeightTest() {
            //        r
            //      /   \
            //     a     b
            //    /  \
            //   c    d
            //  /  \   
            // e    f
            // | \
            // g  h

            Tree root = new TreeNode() {                        // r
                            left = new TreeNode() {             // a
                                left = new TreeNode() {         // c
                                    left = new TreeNode() {     // e
                                        left = new TreeLeaf(),  // g
                                        right = new TreeLeaf()},// h
                                    right = new TreeLeaf()},    // f
                                right = new TreeLeaf() },       // d
                            right = new TreeLeaf()              // b
                        };
            HeightVisitor visitor = new HeightVisitor();
            visitor.visit(root);
            Assert.AreEqual(4, visitor.height);
        }
    }
}