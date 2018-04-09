using System;
using System.Collections;
using adapter;
using NUnit.Framework;

namespace Tests {

    public class CompareAdapterTest {

        [Test]
        public void test() {
            
            var ca = new PuzzleAdapter();
            ArrayList a = ca.puzzle();

            // Check if is Sorted
            for (int i = 1; i < a.Count; i++) {
                Assert.True((int)a[i-1] <=  (int)a[i]);
            }  
        }
    }

}