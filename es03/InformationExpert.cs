using System;

namespace InformationExpert {

    class Car {
        Speedometer speedometer = new Speedometer();

        public void run() {
            Console.WriteLine("brum brum");
        }
        // Speedometer contains necessary information about speed,
        // thus it is spedometer who displays speed
        public void dispalySpeed() {
            speedometer.dispalySpeed();
        }
    }

    class Speedometer {
        private int speed;

        public Speedometer() {
            this.speed = 7;
        }

        public void dispalySpeed() {
            Console.WriteLine(this.speed);
        }

    }
}