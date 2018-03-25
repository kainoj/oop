namespace singleton {

    namespace process {
        public class SingletonProcess {
            /* A singleton reachable within a same process */
            private static SingletonProcess _instance;

            public static SingletonProcess Instance() {
                if (_instance == null) {
                    _instance = new SingletonProcess();
                }
                return _instance;
            }
        }
    }
}