using System;
using NUnit.Framework;
using simplecontainer;

namespace simplecontainertest
{
    public class RecursiveSolutionTest {

        public class A{
            public B b;
            public A(B b) {
                this.b = b;
            }
        }

        public class B { }

        public class X {
            public X(string s) { }
        }

        [Test]
        public void RecursiveSolution() {
            SimpleContainer c = new SimpleContainer();
            A a = c.Resolve<A>();
            Assert.True(a.b != null);
        }

        [Test]
        public void RecursiveSolutionRegisterInstance() {
            SimpleContainer c = new SimpleContainer();
            X x;
            // Assert.Throws<Exception>(() => {x = c.Resolve<X>();} );
            c.RegisterInstance("register an instance"); 
            x = c.Resolve<X>();
            Assert.True(x is X);
        }

        public class Foo {
            public Bar bar;
            public Foo(Bar bar) {}
        }

        public class Bar {
            public Bar(Foo foo) {}
        }

        [Test]
        public void RecursiveSolutionDetectCycleTest() {
            SimpleContainer c = new SimpleContainer();
            Assert.Throws<Exception>(() => {Foo foo = c.Resolve<Foo>();});
        }

    }
}