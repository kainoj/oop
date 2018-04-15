using NUnit.Framework;
using visitor;

namespace tests {

    public class TreeVisitorTest {

        [Test]
        public void heightTest() {
            //      r
            //    l    r
            //  ll lr
            Tree root = new TreeNode() {
                            left = new TreeNode() {
                                left = new TreeLeaf(),
                                right = new TreeLeaf() },
                            right = new TreeLeaf()
                        };
            
            HeightVisitor visitor = new HeightVisitor();
            root.Accept(visitor);

            Assert.AreEqual(2, visitor.height);
        }

        [Test]
        public void oneNodeHeightTest() {
            Tree root = new TreeLeaf();
            HeightVisitor visitor = new HeightVisitor();
            root.Accept(visitor);
            Assert.AreEqual(0, visitor.height);
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
            root.Accept(visitor);
            Assert.AreEqual(4, visitor.height);
        }
    }
}