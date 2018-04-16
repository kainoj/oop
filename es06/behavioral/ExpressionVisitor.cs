using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace expressionvisitor {

    public class FlattenVisitor : ExpressionVisitor {

        public List<string> flatten = new List<string>();

        protected override Expression VisitBinary(BinaryExpression expression) {
            if ( !(expression.Left is BinaryExpression))
                 flatten.Add(expression.Left.ToString());
            if ( !(expression.Right is BinaryExpression))
                 flatten.Add(expression.Right.ToString());
            return base.VisitBinary(expression);
        }

        protected override Expression VisitUnary(UnaryExpression expression) {
            flatten.Add(expression.Operand.ToString());
            return base.VisitUnary(expression);
        }
    }


    public class LambdaCounterVisitor : ExpressionVisitor {

        public int lambdaCounter {get; set;} = 0;
      
        protected override Expression VisitLambda<T>(Expression<T> expression) {
            lambdaCounter++;
            return base.VisitLambda<T>(expression);
        }
    }
}
