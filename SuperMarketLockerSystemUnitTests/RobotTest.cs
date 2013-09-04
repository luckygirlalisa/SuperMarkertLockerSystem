using System.Collections.Generic;
using NUnit.Framework;
using SuperMarketLockerSystem;

namespace SuperMarketLockerSystemUnitTests
{
    class RobotTest
    {
        private Locker locker1;
        private Locker locker2;
        private List<Locker> lockers; 
        private Robot robot;

        [SetUp]
        public void SetUp()
        {
            locker1 = new Locker(1);
            locker2 = new Locker(2);
            lockers = new List<Locker> {locker1, locker2};

            robot = new Robot();
            robot.Manage(lockers);
        }

        [Test]
        public void should_return_ticket_when_store()
        {
            var bag = new Bag();
            Ticket ticket = robot.Store(bag);
            Assert.NotNull(ticket);
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
        public void robot_can_manage_multiple_locker()
        {
            robot.Store(new Bag());
            robot.Store(new Bag());
            robot.Store(new Bag());

            Assert.True(locker1.AvailableBoxesNum == 0);
            Assert.True(locker2.AvailableBoxesNum == 0);
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
        public void should_store_in_locker_with_locker_index()
        {
            var storedBag = new Bag();
            Ticket ticket1 = robot.Store(storedBag);
            Bag pickedBag = locker1.Pick(ticket1);
            Assert.That(pickedBag, Is.SameAs(storedBag));
        }

        [Test]
        public void should_return_the_same_bag_stored_when_pick_with_a_ticket()
        {
            var storedBag = new Bag();
            var ticket = robot.Store(storedBag);
            Bag pickedBag = robot.Pick(ticket);
            Assert.That(pickedBag, Is.SameAs(storedBag));
        }

        [Test]
        public void should_return_correct_bag_when_pick_with_ticket_after_multiple_store()
        {
            var bag1 = new Bag();
            var bag2 = new Bag();
            robot.Store(bag1);
            var ticket2 = robot.Store(bag2);
            Assert.That(bag2, Is.SameAs(robot.Pick(ticket2)));
        }

        [Test]
        public void should_return_null_when_pick_with_null_or_not_matched_ticket()
        {
            Assert.Null(robot.Pick(null));
            Assert.Null(robot.Pick(new Ticket()));
        }

        [Test]
        public void should_return_null_when_pick_with_used_ticket()
        {
            robot.Store(new Bag());
            var usedTicket = robot.Store(new Bag());
            robot.Pick(usedTicket);
            Assert.Null(robot.Pick(usedTicket));
        }

        [Test]
        public void should_return_null_when_pick_with_null()
        {
            Assert.Null(robot.Pick(null));
        }
    }
}
