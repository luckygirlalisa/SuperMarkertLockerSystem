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
        public void Should_store_in_largest_percentage_of_available_boxes()
        {
            locker1 = new Locker(11);
            locker2 = new Locker(10);
            lockers = new List<Locker> {locker1, locker2};
            superRobot.Manage(lockers);

            locker1.Store(new Bag());
            var ticket = superRobot.Store(new Bag());
            Assert.NotNull(locker2.Pick(ticket));
        }

        [Test]
        public void should_return_null_when_store_with_all_lockers_are_full()
        {
            locker1 = new Locker(1);
            locker2 = new Locker(2);
            lockers = new List<Locker> {locker1, locker2};
            superRobot.Manage(lockers);

            superRobot.Store(new Bag());
            superRobot.Store(new Bag());

            Ticket ticket = superRobot.Store(new Bag());
            Assert.Null(ticket);
        }

        [Test]
        public void Should_return_null_with_no_locker_managed()
        {
            lockers = new List<Locker>();
            superRobot.Manage(lockers);
            Assert.Null(superRobot.Store(new Bag()));
        }
    }
}