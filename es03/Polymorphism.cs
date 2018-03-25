using System;

namespace Polymorphism {

    public interface IAnimal {
        string makeSound();
        void eats();
    }

    public class Cat : IAnimal
    {
        public void eats() {
            Console.WriteLine("milk");
        }

        public string makeSound() {
            return "Meeeeeeow";
        }
    }

    public class Dog : IAnimal {
        public void eats() {
            Console.WriteLine("Ham");
        }

        public virtual string makeSound()
        {
            return "wooooww woow";
        }
    }

    public class Doge : Dog {
        public override string makeSound() {
            return base.makeSound() + " woow such code";
        }
    }

}

