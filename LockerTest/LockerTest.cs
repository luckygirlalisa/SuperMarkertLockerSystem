using NUnit.Framework;

namespace SuperMarketLockerSystem.LockerTest
{
    internal class LockerTest
    {
        private Locker.Locker locker;

        [SetUp]
        public void SetUp()
        {
            locker = new Locker.Locker(10);
        }

        [Test]
        public void should_return_ticket_not_null_when_store_a_bag_in_a_locker()
        {
            var bag = new Bag();
            var ticket = locker.Store(bag);
            Assert.NotNull(ticket);
        }

        [Test]
        public void should_return_ticket_not_null_when_store_nothing()
        {
            Ticket ticket = locker.Store(null);
            Assert.NotNull(ticket);
        }

        [Test]
        public void should_be_able_to_store_multiple_bags_in_one_locker()
        {
            locker = new Locker.Locker(2);
            locker.Store(new Bag());
            Assert.NotNull(locker.Store(new Bag()));
        }

        [Test]
        public void should_return_the_same_bag_as_stored_when_pick()
        {
            var storedBag = new Bag();
            Ticket ticket =  locker.Store(storedBag);
            var pickedBag = locker.Pick(ticket);
            Assert.That(pickedBag, Is.SameAs(storedBag));
        }

        [Test]
        public void should_return_null_when_pick_with_null_ticket()
        {
            Assert.Null(locker.Pick(null));
        }

        [Test]
        public void should_return_null_when_pick_with_not_matched_ticket()
        {
            var notMatchedTicket = new Ticket();
            locker.Store(new Bag());
            Assert.Null(locker.Pick(notMatchedTicket));
        }

        [Test]
        public void should_be_able_to_store_after_picked_from_full_locker()
        {
            locker = new Locker.Locker(1);
            var bag1 = new Bag();
            var bag2 = new Bag();
            locker.Pick(locker.Store(bag1));
            Assert.NotNull(locker.Store(bag2));
        }
    }
}

       