using System.Threading;
using NUnit.Framework;
using singleton.timer;

namespace Tests {

    public class SingletonTimerTest {

        /// Test wheater two instances within a process are the same
        [Test]
        public void TestSameInstances() {
            Assert.AreSame(SingletonTimer.Instance(), SingletonTimer.Instance());
        }

        /// Test wheater instances created with 5s delay are diferent
        [Test]
        public void TestDiffInstancesOnTimer() {
            SingletonTimer s = SingletonTimer.Instance();

            System.Console.WriteLine("Sleeping...");
            System.Threading.Thread.Sleep(6000);
            System.Console.WriteLine("...Good morning!");

            SingletonTimer s2 = SingletonTimer.Instance();

            Assert.AreNotSame(s, s2);
        }
    }
}