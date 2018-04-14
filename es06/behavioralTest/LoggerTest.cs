using NUnit.Framework;
using logger;

namespace logger {
    
    public class LoggerTest {

        [Test]
        public void test() {
        
            ILogger console = LoggerFactory.Instance.GetLogger(LogType.Console);
            console.Log("hello console");

            ILogger file = LoggerFactory.Instance.GetLogger(LogType.File, "fname");
            file.Log("hello file");

            ILogger none = LoggerFactory.Instance.GetLogger();
            none.Log("hello nonoe");
        }
    }
}