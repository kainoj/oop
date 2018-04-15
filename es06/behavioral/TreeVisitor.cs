using System;
using System.Collections.Generic;

namespace visitor {

    public abstract class TreeVisitor {
        public abstract void visitNode(TreeNode node);
        public abstract void visitLeaf(TreeLeaf leaf);
    }

    public class HeightVisitor : TreeVisitor {

        public int height {get; set;} = 0;

        private Dictionary<Tree, int> depth = new Dictionary<Tree, int>();

        public override void visitLeaf(TreeLeaf leaf) {
            if (depth.ContainsKey(leaf) && depth[leaf] > height) {
                height = depth[leaf];
            }
        }

        public override void visitNode(TreeNode node) {
            if (depth.ContainsKey(node)) {
                depth[node.left] = depth[node] + 1;
                depth[node.right] = depth[node] + 1;
            }
            else {
                depth[node] = 0;
                depth[node.right] = 1;
                depth[node.left] = 1;
            }
        }
    }

    public abstract class Tree { 
        public abstract void Accept(TreeVisitor visitor);
    }

    public class TreeNode : Tree {
        
        public Tree left {get; set;}
        public Tree right {get; set;}

        public override void Accept(TreeVisitor visitor) {
            visitor.visitNode(this);
            if (left != null) left.Accept(visitor);
            if (right != null) right.Accept(visitor);
        }
    }

    public class TreeLeaf : Tree {
        public override void Accept(TreeVisitor visitor) {
            visitor.visitLeaf(this);
        }
    }
}