using System.Collections.Generic;
using NUnit.Framework;
using SuperMarketLockerSystem;

namespace SuperMarketLockerSystemUnitTests
{
    class SmartRobotTest
    {
        private Locker locker1;
        private Locker locker2;
        private List<Locker> lockers; 
        private SmartRobot smartRobot;

        [SetUp]
        public void SetUp()
        {
            locker1 = new Locker(1);
            locker2 = new Locker(2);
            lockers = new List<Locker> {locker1, locker2};

            smartRobot = new SmartRobot();
        }

        [Test]
        public void should_store_in_locker_with_most_available_boxes()
        {
            smartRobot.Manage(lockers);

            var storedBag = new Bag();
            Ticket ticket1 = smartRobot.Store(storedBag);
            Bag pickedBag = locker2.Pick(ticket1);
            Assert.That(pickedBag, Is.SameAs(storedBag));
        }

        [Test]
        public void Should_return_null_with_no_locker_managed()
        {
            lockers = new List<Locker>();
            smartRobot.Manage(lockers);
            
            Assert.Null(smartRobot.Store(new Bag()));
        }
    }
}
