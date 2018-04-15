using System;
using System.Collections.Generic;

namespace interpreter {

    public class Context {

        Dictionary<string, bool> vars = new Dictionary<string, bool>();

        public bool GetValue(string VariableName) {
            try {
                return vars[VariableName];
            }
            catch {
                throw new Exception("Variable does not exist");
            }
        }
        public bool SetValue(string VariableName, bool Value) {
            return vars[VariableName] = Value;
        }
    }

    public abstract class AbstractExpression {
        public abstract bool Interpret(Context context);
    }
}