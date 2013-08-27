using NUnit.Framework;

namespace SuperMarketLockerSystem
{
    class RobotTest
    {
        private Robot robot;
        [SetUp]
        public void SetUp()
        {
            robot = new Robot();
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
        public void should_return_null_when_store_in_stored_locker()
        {
            //given
            var bag = new Bag();
            //when
            robot.Store(bag);
            //then
            Assert.Null(robot.Store(new Bag()));
        }

        [Test]
        public void should_return_the_same_bag_stored_when_pick_with_a_ticket()
        {
            var storedBag = new Bag();
            var ticket = robot.Store(storedBag);
            Bag pickedBag = robot.Pick(ticket);
            Assert.That(pickedBag, Is.SameAs(storedBag));
        }
    }
}
