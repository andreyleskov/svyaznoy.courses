using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApplication1;

namespace ConsumerTests
{
    [TestClass]
    public class ConsumerTests
    {
        [TestMethod]
        public void ConsumerGoesToFirstFloor()
        {
            var consumer = new Consumer();
            Assert.AreEqual("going to first floor",consumer.DoMajorTask());
        }
    }
}
