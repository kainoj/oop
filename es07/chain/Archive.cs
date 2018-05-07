using System;
using mail;

namespace archive {

    public class Archives {

        private static Archives _instance;

        public static Archives Instance() {
            if (_instance == null) {
                _instance = new Archives();
            }
            return _instance;
        }

        public void archive(Mail mail) {
            Console.WriteLine("[Archived]\t{0}", mail.body);
        }
    }
}