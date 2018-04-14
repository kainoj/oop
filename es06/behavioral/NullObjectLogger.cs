namespace logger {

    public interface ILogger {
        void Log( string Message );
    }
    
    public enum LogType { None, Console, File }


    public class LoggerFactory {

        private static LoggerFactory _logger;

        public ILogger GetLogger(LogType LogType=LogType.None, string Parameters=null) {
            switch (LogType) {
                case LogType.Console:
                    return new ConsoleLogger();
                case LogType.File:
                    return new FileLogger(Parameters);
                default:
                    return new NullLogger();   
            }
         }


        public static LoggerFactory Instance {
           get { 
                // TODO: thread safe
                if (_logger == null)
                    _logger = new LoggerFactory();
                return _logger;
           }
        }
    }
}