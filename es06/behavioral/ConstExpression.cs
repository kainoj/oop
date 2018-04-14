using interpreter;
   
public class ConstExpression : AbstractExpression {

    protected bool isVar;
    protected string varName;
    protected bool constValue;

    public override bool Interpret(Context context) {
        return isVar? context.GetValue(varName) : constValue;
    }
}

public class Var : ConstExpression {
    public Var(string varName) {
        this.varName = varName;
        this.isVar = true;
    }
}

public class Const : ConstExpression {
    public Const(bool constValue) {
        this.constValue = constValue;
        this.isVar = false;
    }
}