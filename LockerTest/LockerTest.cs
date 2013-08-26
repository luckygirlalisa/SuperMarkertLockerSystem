using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public void should_return_ticket_when_store_a_bag_from_a_locker()
        {
            //given
            var bag = new Bag();
            //when
            Ticket ticket = locker.Store(bag);
            //then
            Assert.NotNull(ticket);
        }

        [Test]
        public void should_throw_StoreInFullLockerException_when_store_bag_in_full_locker()
        {
            var bag1 = new Bag();
            var bag2 = new Bag();
            locker.Store(bag1);
            Assert.Throws<StoreBagInFullLockerException>(() => locker.Store(bag2));
        }

        [Test]
        public void should_can_store_nothing_in_locker()
        {
            Bag bag = null;
            Ticket ticket = locker.Store(bag);
            Assert.That(ticket, Is.Not.Null);
        }

        [Test]
        public void should_pick_correct_bag_with_ticket()
        {
            Bag storedBag = new Bag();
            Ticket ticket = locker.Store(storedBag);
            Bag pickedBag = locker.PickWith(ticket);
            Assert.AreEqual(storedBag, pickedBag);
        }

        [Test]
        public void should_throw_InvalidTicketException_when_pick_a_bag_with_null_ticket()
        {
            Bag bag = new Bag();
            Ticket ticket = null;
            Assert.Throws<InvaidTicketException>(() => locker.PickWith(ticket));
        }

        [Test]
        [Ignore]
        public void should_return_null_when_pick_a_bag_with_not_mapped_ticket()
        {
            Bag bag = new Bag();
            locker.Store(bag);
            Ticket ticket = new Ticket(new Bag());
            Assert.That(locker.PickWith(ticket), Is.Null);
        }

    }

    internal class InvaidTicketException: Exception
    {
        public InvaidTicketException(string message) : base(message) {}
    }
}
