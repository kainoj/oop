namespace singleton {
    namespace thread {

        public class SingletonThread {

            /* One singleton per thread */
            [System.ThreadStatic]
            private static SingletonThread _instance;

            public static SingletonThread Instance() {
                if (_instance == null) {
                    _instance = new SingletonThread();
                }
                return _instance;
            }
        }
        
    }
}