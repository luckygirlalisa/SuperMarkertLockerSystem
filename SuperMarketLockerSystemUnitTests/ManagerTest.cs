using System.Collections.Generic;
using NUnit.Framework;
using SuperMarketLockerSystem;

namespace SuperMarketLockerSystemUnitTests
{
    public class ManagerTest
    {
        [Test]
        public void Should_return_ticket_when_store_bag_into_locker()
        {
            var locker = new Locker(2);
            var manager = new Manager(locker);
            var ticket = manager.Store(new Bag());
            Assert.NotNull(ticket);
            Assert.NotNull(locker.Pick(ticket));
        }
    }

    public class Manager
    {
        private Locker locker;
        public Manager(Locker locker)
        {
            this.locker = locker;
        }

        public Ticket Store(Bag bag)
        {
            return locker.Store(bag);
        }
    }
}
