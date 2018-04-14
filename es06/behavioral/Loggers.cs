namespace logger {

    public class ConsoleLogger : ILogger {
        public void Log(string Message) {
            System.Console.WriteLine(Message);
        }
    }

    public class FileLogger : ILogger {

        private string filename; 

        public FileLogger(string filename) {
            this.filename = filename;
        }

        public void Log(string Message) {
            System.Console.WriteLine("Writing to " + filename);
        }
    }

    public class NullLogger : ILogger {
        public void Log(string Message) { }
    }
}