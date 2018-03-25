using System;
using System.Diagnostics;

namespace singleton {

    namespace timer {

        public class SingletonTimer {

            private static SingletonTimer _instance;
            private static Stopwatch _stopwatch;

            public static SingletonTimer Instance() {
                if (_instance == null) {
                    _instance = new SingletonTimer();
                    _stopwatch = new Stopwatch();
                    _stopwatch.Start();
                }
                if (_stopwatch.Elapsed.Seconds > 1 ) {
                    _instance = new SingletonTimer();
                    _stopwatch.Restart();
                }
                return _instance;
            }
        }

    }
}