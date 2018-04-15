namespace interpreter {

    public abstract class BinaryExpression : AbstractExpression {

        protected AbstractExpression left;
        protected AbstractExpression right;

        public BinaryExpression(AbstractExpression left, AbstractExpression right) {
            this.left = left;
            this.right = right;
        }
    }

    public class Or : BinaryExpression {

        public Or(AbstractExpression left, AbstractExpression right) 
            : base(left, right) {}

        public override bool Interpret(Context context) {
        return left.Interpret(context) || right.Interpret(context);
        }
    }

    public class And : BinaryExpression {

        public And(AbstractExpression left, AbstractExpression right) 
            : base(left, right) {}

        public override bool Interpret(Context context) {
        return left.Interpret(context) && right.Interpret(context);
        }
    }
}