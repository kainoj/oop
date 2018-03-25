using System.Threading;
using NUnit.Framework;
using singleton.thread;

namespace Tests {

    public class SingletonThreadTest {

        /// Test wheater two instances within a process are the same
        [Test]
        public void TestSameInstances() {
            Assert.AreSame(SingletonThread.Instance(), SingletonThread.Instance());
        }

        /// Check wheater two instances within different threads are the same
        [Test]
        public void TestSameInstancesPerThread() {
            SingletonThread s = SingletonThread.Instance();

            object s1 = null;
            object s2 = null;
            
            var thr1 = new Thread(() => {s1 = SingletonThread.Instance();});
            thr1.Start();
            thr1.Join();

            var thr2 = new Thread(() => {s2 = SingletonThread.Instance();});
            thr2.Start();
            thr2.Join();

            Assert.AreNotSame(s, s1);
            Assert.AreNotSame(s, s2);
            Assert.AreNotSame(s1, s2);
        }
    }
}