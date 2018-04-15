namespace interpreter {

    public abstract class UnaryExpression : AbstractExpression {
        protected AbstractExpression expr;

        public UnaryExpression(AbstractExpression expr) {
            this.expr = expr;
        }
    }

    public class Not : UnaryExpression {

        public Not(AbstractExpression expr) : base(expr) {}

        public override bool Interpret(Context context) {
            return !expr.Interpret(context);
        }
    }
}