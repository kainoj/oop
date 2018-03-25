using System.Threading;
using NUnit.Framework;
using singleton.process;

namespace Tests {
    
    public class SingletonProcessTest {

        /// Check wheater two instances are the same 
        [Test]
        public void TestSameInstances() {
            SingletonProcess s = SingletonProcess.Instance();
            SingletonProcess p = SingletonProcess.Instance();
            Assert.AreSame(s, p);
        }

        /// Check wheater two instances within different threads are the same
        [Test]
        public void TestSameInstancesPerThread() {
            SingletonProcess s = SingletonProcess.Instance();

            object s1 = null;
            object s2 = null;
            
            var thr1 = new Thread(() => {s1 = SingletonProcess.Instance();});
            thr1.Start();
            thr1.Join();

            var thr2 = new Thread(() => {s2 = SingletonProcess.Instance();});
            thr2.Start();
            thr2.Join();

            Assert.AreSame(s, s1);
            Assert.AreSame(s, s2);
            Assert.AreSame(s1, s2);
        }

    }




}