
using System.Collections.Generic;
using NUnit.Framework;
using SuperMarketLockerSystem;

namespace SuperMarketLockerSystemUnitTests
{
    public class SuperRobotTest
    {
        private SuperRobot superRobot;
        private Locker locker1;
        private Locker locker2;
        private List<Locker> lockers;
            
        [SetUp]
        public void Init()
        {
            superRobot = new SuperRobot();
        }

        [Test]
        public void Should_return_ticket_when_store_multiple_bags()
        {
            locker1 = new Locker(11);
            locker2 = new Locker(10);
            lockers = new List<Locker> { locker1, locker2 };
            superRobot.Manage(lockers);

            var ticket1 = superRobot.Store(new Bag());
            var ticket2 = superRobot.Store(new Bag());
            Assert.NotNull(ticket1);
            Assert.NotNull(ticket2);
        }

        [Test]
        public void Should_store_in_largest_percentage_of_available_boxes()
        {
            locker1 = new Locker(11);
            locker2 = new Locker(10);
            lockers = new List<Locker> { locker1, locker2 };
            superRobot.Manage(lockers);

            locker1.Store(new Bag());
            var ticket = superRobot.Store(new Bag());
            Assert.NotNull(locker2.Pick(ticket));
        }
    }
}
