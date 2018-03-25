using airport;
using NUnit.Framework;

namespace airportObjectPoolTests {

    class AirportObjectPoolTest {

        [Test]
        public void AirplanePoolTest() {
            
            AirportObjectPool airport = AirportObjectPool.Instance();
            Plane p1 = airport.AcquirePlane();
            Plane p2 = airport.AcquirePlane();
            Plane p3 = airport.AcquirePlane();

            // Here the pool contains 3 planes and 0 are available
            Assert.AreEqual(3, airport.airplanePoolSize());
            Assert.AreEqual(0, airport.airplaneAvailability());
            
            // Release a plane
            airport.ReleasePlane(p3);

            // A plane has just been released - one plane is available
            Assert.AreEqual(1, airport.airplaneAvailability());

            // Acquire a new plane and check if it's the same plane
            Plane p3a = airport.AcquirePlane();
            Assert.AreSame(p3, p3a);

            // Here the the pool is full and there are no available planes!
            Assert.AreEqual(0, airport.airplaneAvailability());

            // Aquire a plane - throws exception since no planes are available
            Assert.Throws<System.Exception>(() => airport.AcquirePlane());  
        }

    }

}