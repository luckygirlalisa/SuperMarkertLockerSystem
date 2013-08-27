using NUnit.Framework;

namespace SuperMarketLockerSystem
{
    class RobotTest
    {
        private Robot robot;
        private int capacity;
        [SetUp]
        public void SetUp()
        {
            capacity = 10;
            robot = new Robot(capacity);
        }

        [Test]
        public void should_return_ticket_when_store()
        {
            //given
            var bag = new Bag();
            //when
            Ticket ticket = robot.Store(bag);
            //then
            Assert.NotNull(ticket);
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
        public void should_be_able_to_store_in_multiple_locker()
        {
            var bag1 = new Bag();
            var bag2 = new Bag();
            robot.Store(bag1);
            Assert.NotNull(robot.Store(bag2));
        }

        [Test]
        public void should_return_null_when_store_with_all_lockers_are_stored()
        {
            for (int i = 0; i < capacity; i++)
            {
                robot.Store(new Bag());
            }
            Assert.Null(robot.Store(new Bag()));
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
    }
}
