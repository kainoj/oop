using System;
using NUnit.Framework;
using simplecontainer;

namespace simplecontainertest
{
    public class SimpleContainerTest {

        interface IFoo {}
        class Foo : IFoo {}

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

        // [Test]
        // public void ResolveFooBarTest() {
        //     SimpleContainer c = new SimpleContainer();
        //     c.RegisterType<IFoo, Bar>();
        //     IFoo g = c.Resolve<IFoo>();
        //     Assert.True(g is Bar);
        // }

        [Test]
        public void ResolveUnregisteredTest() {
            SimpleContainer c = new SimpleContainer();
            IFoo foo;
            Assert.Throws<Exception>(() => { foo = c.Resolve<IFoo>(); } );
        }
    }
}