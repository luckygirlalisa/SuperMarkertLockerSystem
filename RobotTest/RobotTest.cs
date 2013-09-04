using NUnit.Framework;

namespace SuperMarketLockerSystem.RobotTest
{
    class RobotTest
    {
        private Robot robot = new Robot();
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
        [Ignore]
        public void should_throw_StoreBagInFullLockerException_when_store_in_stored_locker()
        {
            //given
            var bag = new Bag();
            //when

            //then
            Assert.Throws<StoreBagInFullLockerException>(() => robot.Store(bag));
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

    internal class Robot
    {
        public Ticket Store(Bag bag)
        {
            return new Ticket(bag);
        }

        public Bag Pick(Ticket ticket)
        {
            return null;
        }
    }
}
