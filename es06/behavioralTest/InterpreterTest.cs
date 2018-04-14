using System;
using interpreter;
using NUnit.Framework;

namespace test {

    public class InterpreterTest {

        [Test]
        public void test() {

            Context ctx = new Context();
            ctx.SetValue("x", true);
            ctx.SetValue("y", false);

            AbstractExpression exp;

            // x and y <=> true and false <=> false
            exp = new And(new Var("x"), new Var("y"));
            Assert.False(exp.Interpret(ctx));

            // true and x <=> true
            exp = new And(new Const(true), new Var("x"));
            Assert.True(exp.Interpret(ctx));

            // x or y <=> true or false <=> true
            exp = new Or(new Var("x"), new Var("y"));
            Assert.True(exp.Interpret(ctx));

            // false or false <=> false
            exp = new Or(new Const(false), new Const(false));
            Assert.False(exp.Interpret(ctx));

            // not false <=> true
            exp = new Not(new Const(false));
            Assert.True(exp.Interpret(ctx));

            // not not ((x or y) and true) <=> true
            exp = new Not(new Not(new And(new Const(true), new Or(new Var("x"), new Var("y")))));
            Assert.True(exp.Interpret(ctx));

            exp = new Var("z");
            Assert.Throws<Exception>(() => exp.Interpret(ctx));
        }
    }
}