using NUnit.Framework;

namespace SuperMarketLockerSystem.SuperMarketLockerSystemTest
{
    internal class LockerTest
    {
        private Locker locker;

        [SetUp]
        public void SetUp()
        {
            locker = new Locker();
        }

        [Test]
        public void should_return_ticket_not_null_when_store_a_bag_in_a_locker()
        {
            //given
            var bag = new Bag();
            //when
            Ticket ticket = locker.Store(bag);
            //then
            Assert.NotNull(ticket);
        }

        [Test]
        public void should_return_null_when_store_bag_in_stored_locker()
        {
            var bag1 = new Bag();
            var bag2 = new Bag();
            locker.Store(bag1);
            Assert.Null(locker.Store(bag2));
        }

        [Test]
        public void should_return_ticket_not_null_when_store_nothing()
        {
            Ticket ticket = locker.Store(null);
            Assert.NotNull(ticket);
        }

        [Test]
        public void should_return_the_same_bag_as_stored_when_pick()
        {
            var stored_bag = new Bag();
            Ticket ticket =  locker.Store(stored_bag);
            var picked_bag = locker.Pick(ticket);
            Assert.That(picked_bag, Is.SameAs(stored_bag));
        }

        [Test]
        public void should_return_null_when_pick_with_null_ticket()
        {
            Assert.Null(locker.Pick(null));
        }

        [Test]
        public void should_return_null_when_pick_with_not_matched_ticket()
        {
            Ticket not_matched_ticket = new Ticket();
            locker.Store(new Bag());
            Assert.Null(locker.Pick(not_matched_ticket));
        }

        [Test]
        public void should_be_able_to_store_after_picked()
        {
            Bag bag1 = new Bag();
            Bag bag2 = new Bag();
            locker.Pick(locker.Store(bag1));
            Assert.NotNull(locker.Store(bag2));
        }
    }
}

       