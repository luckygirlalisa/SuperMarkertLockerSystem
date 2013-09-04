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
        private SmartRobot robot;

        [SetUp]
        public void SetUp()
        {
            locker1 = new Locker(1);
            locker2 = new Locker(2);
            lockers = new List<Locker> {locker1, locker2};

            robot = new SmartRobot();
            robot.Manage(lockers);
        }

        [Test]
        public void should_be_able_to_store_multiple_bags()
        {
            var bag1 = new Bag();
            var bag2 = new Bag();
            var ticket1 = robot.Store(bag1);
            var ticket2 = robot.Store(bag2);
            Assert.NotNull(ticket2);
            Assert.That(ticket1, Is.Not.EqualTo(ticket2));
        }

        [Test]
        public void should_return_null_when_store_with_all_lockers_are_full()
        {
            robot.Store(new Bag());
            robot.Store(new Bag());
            robot.Store(new Bag());
            
            Ticket ticket = robot.Store(new Bag());
            Assert.Null(ticket);
        }

        [Test]
        public void should_store_in_locker_with_most_available_boxes()
        {
            var storedBag = new Bag();
            Ticket ticket1 = robot.Store(storedBag);
            Bag pickedBag = locker2.Pick(ticket1);
            Assert.That(pickedBag, Is.SameAs(storedBag));
        }
    }
}
