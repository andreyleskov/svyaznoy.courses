using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApplication1;

namespace ConsumerTests
{



    [TestClass]
    public class ConsumerTests
    {
        //[TestMethod]
        //public void ConsumerGoesToFirstFloor()
        //{
        //    Settings.Instance.MeetingRoom = "first";
        //    var consumer = new Consumer(new SettingsSingletonWrap(Settings.Instance));
        //    Assert.AreEqual("going to first floor", consumer.DoMajorTask());
        //}

        [TestMethod]
        public void ConsumerGoesToFirstFloor()
        {
            TestSettings enviroment = new TestSettings();
            enviroment.MeetingRoom = "first";
            Consumer consumer = new Consumer(enviroment);
            Assert.AreEqual("going to first floor", consumer.DoMajorTask());
        }

        [TestMethod]
        public void ConsumerGoesToSecondFloor()
        {
            var consumer = new Consumer(new TestSettings());
            Assert.AreEqual("going to second floor", consumer.DoMajorTask());
        }

        public class TestSettings : ISettings
        {
            //public TestSettings(string defultMeetingRoom)
            //{

            //}

            public string MeetingRoom
            {
                get;
                set;
            }

        }

        
    }
}
