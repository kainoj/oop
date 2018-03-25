using System;
using System.Collections.Generic;

namespace airport {

    public class Plane {}

    public class AirportObjectPool {

        private const int MAXPOOL = 3;

        private static AirportObjectPool _intance;

        private List<Plane> _planePool = new List<Plane>();

        private Stack<Plane> _planeAvailable = new Stack<Plane>();

    
        public Plane AcquirePlane() {
            if (_planePool.Count < MAXPOOL) {
                Plane plane = new Plane();
                _planePool.Add(plane);
                _planeAvailable.Push(plane);
            }
            if (_planeAvailable.Count > 0) {
                return _planeAvailable.Pop();
            }
            else {
                throw new Exception("No planes in the pool");
            }
        }

        public void ReleasePlane(Plane plane) {
            
            if (_planePool.Contains(plane)) {
                if (!_planeAvailable.Contains(plane))
                   _planeAvailable.Push(plane);
            }
            else {
                throw new Exception("No such plane in the pool");
            }
        }

        public static AirportObjectPool Instance() {
            if (_intance == null) {
                _intance = new AirportObjectPool();
            }
            return _intance;
        }

        public int airplanePoolSize() {
            return _planePool.Count;
        }

        public int airplaneAvailability() {
            return _planeAvailable.Count;
        }
    }

}