using System;
using System.Collections.Generic;

using Creator;
using InformationExpert;
using Controller;
using Polymorphism;
using ProtectedVariations;

using Ex4;

namespace es03
{   
    class Program
    {
        static void Main(string[] args)
        {
            // Creator
            Console.WriteLine(">Creator");
            B b = new B();
            b.useA();

            // Information expert
            Console.WriteLine("\n>Information Expert");
            Car car = new Car();
            car.run();
            car.dispalySpeed();

            // Controller
            Console.WriteLine("\n>Controller");
            OneClickBuyHandler oneClickBuyHandler = new OneClickBuyHandler();
            oneClickBuyHandler.oneClickBuy(new List<string>{"item1", "item2"});

            // Polymorphism
            Console.WriteLine("\nPolymorphism");
            List <IAnimal> animals = new List<IAnimal>{new Cat(), new Dog(), new Doge()};
            foreach(IAnimal animal in animals) {
                animal.eats();
                Console.WriteLine(animal.makeSound() + "\n");
            }

            // Protected Variations (Demeter's Law)
            Console.WriteLine("\n>Protected Variations (Demeter's Law)");
            Dinner dinner = new Dinner();
            dinner.cook();



            // 
            int w = 4, h = 5;
            Rectangle rect = new Square() { Width = w, Height = h };
            AreaCalculator calc = new AreaCalculator();
            Console.WriteLine("prostokąt o wymiarach {0} na {1} ma pole {2}",  w, h, calc.CalculateArea(rect) );
        }
    }
}
