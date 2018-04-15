/*
    This is an implementation of a visitor pattern,
    where the visitor is familliar with a stucture.
*/

using System.Collections.Generic;

namespace visitor2 {

    public abstract class Tree { }

    public class TreeNode : Tree {
        public Tree left {get; set; }
        public Tree right {get; set; } 
    }

    public class TreeLeaf : Tree { }

    public abstract class TreeVisitor {

        public void visit(Tree tree) {
            if (tree is TreeLeaf)
                visitLeaf((TreeLeaf) tree);
            else
                visitNode((TreeNode) tree);
        }


        public virtual void visitNode(TreeNode node) {
            if (node != null) {
                visit(node.left);
                visit(node.right);
            }
        }

        public virtual void visitLeaf(TreeLeaf leaf) {
        }
    }


    public class HeightVisitor : TreeVisitor {
        public int height {set; get; } = 0;
        Stack<int> h = new Stack<int>();

        public override void visitNode(TreeNode node) {
            if (node == null)
                return;
            h.Push(height);

            base.visitNode(node);

            // h(node) = 1 + max(h(node.left), h(node.right))
            
            int maxH = 0;
            if (node.left != null && node.right != null) {
                int lft = h.Pop();
                int rgt = h.Pop();
                maxH = lft > rgt ? lft : rgt;
            }
            else {
                maxH = h.Pop();
            }
          
            height = maxH + 1;
            h.Pop();
            h.Push(height);
        }

        public override void visitLeaf(TreeLeaf leaf) {
            h.Push(0);
            base.visitLeaf(leaf);
        }   
    }
}