using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;
using expressionvisitor;
using NUnit.Framework;

namespace tests {

    public class ExpressionVisitorTest {

        [Test]
        public void lambdaCounterTest() {
            Expression<Func<int, int>> f = n => 4 * (7 + n);
            LambdaCounterVisitor l = new LambdaCounterVisitor();
            l.Visit(f);           
            Assert.AreEqual(1, l.lambdaCounter);
        }

        [Test]
        public void flattenTest() {
            Expression<Func<int, int>> f = n => 4 * (7 + n);
            FlattenVisitor flat = new FlattenVisitor();
            flat.Visit(f);       
 
            List<String> ans = new List<String>() {"4", "7", "n"};
            Assert.AreEqual(ans, flat.flatten);
        }
    }   
}