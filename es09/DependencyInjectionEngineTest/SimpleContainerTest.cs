using System;
using NUnit.Framework;
using simplecontainer;

namespace simplecontainertest
{
    public class SimpleContainerTest {

        interface IFoo {}
        class Foo : IFoo {}

        class Foo2 : IFoo {}

        interface IBar {}
        class Bar : IBar {}

        [Test]
        public void ResolveTest() {
            
            SimpleContainer container = new SimpleContainer();
            Foo foo = container.Resolve<Foo>();

            Assert.True(foo is Foo);
        }

        [Test]
        public void ResolveSingletonTest() {
            SimpleContainer container = new SimpleContainer();
            container.RegisterType<Foo>(true);
            Foo foo = container.Resolve<Foo>();
            Foo fo2 = container.Resolve<Foo>();
            Assert.AreEqual(foo, fo2);
        }

        [Test]
        public void InterfaceResolveTest() {
            SimpleContainer container = new SimpleContainer();
            container.RegisterType<IBar, Bar>();
            IBar bar = container.Resolve<IBar>();
            Assert.True(bar is Bar);            
        }

        [Test]
        public void InterfaceResolveSingletonTest() {
            SimpleContainer container = new SimpleContainer();
            container.RegisterType<IBar, Bar>(true);

            IBar bar = container.Resolve<IBar>();
            Assert.True(bar is Bar);            
        }

        [Test]
        public void ResolveTwiceIFooTest() {
            SimpleContainer c = new SimpleContainer();
            // Register IFoo as Foo
            c.RegisterType<IFoo, Foo>();
            IFoo foo = c.Resolve<IFoo>();
            Assert.True(foo is Foo);
            
            // Re-register IFoo as Foo2
            c.RegisterType<IFoo, Foo2>();
            IFoo foo2 = c.Resolve<IFoo>();
            Assert.True(foo2 is Foo2);
        }

        [Test]
        public void ResolveUnregisteredTest() {
            SimpleContainer c = new SimpleContainer();
            IFoo foo;
            Assert.Throws<Exception>(() => { foo = c.Resolve<IFoo>(); } );
        }
    }
}