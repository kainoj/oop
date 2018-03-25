using System;

namespace Creator {

    class A {
        private string my_name;
        public A(string my_name) {
            this.my_name = my_name;
        }
        public void hello(string your_name) {
            Console.WriteLine(my_name + ": hello, " + your_name);
        }
    }

    class B {
        private A a;
        
        public B() {
            // Class B uses class A thus B creates A
            a = new A("a");
        }

        public void useA() {
            a.hello("B");
        }
    }
}