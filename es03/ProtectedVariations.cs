using System;

namespace ProtectedVariations {

    class Dinner {
        public void cook() {
            Potato potato = new Potato();
            potato.getThingsDone();
            Console.WriteLine("dinner is ready!");
        }
    }

    class Potato {
        public Potato peel() {
            Console.WriteLine("Peeling potato...");
            return this;
        }

        public Potato slice() {
            Console.WriteLine("Slicing potato...");
            return this;
        }

        public void boil() {
            Console.WriteLine("boiling potato...");
        }

        public void getThingsDone() {
            this.peel();
            this.slice();
            this.boil();
        }
    }
}