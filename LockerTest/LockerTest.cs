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
        public void should_not_store_bag_when_the_locker_is_full()
        {
            var bag1 = new Bag();
            var bag2 = new Bag();
            locker.Store(bag1);
//            locker.Store(bag2);
            //            Assert.Throws<StoreBagInFullLockerException>(delegate { throw new StoreBagInFullLockerException("Can't store bag in a full locker"); } );

                        Assert.Throws<StoreBagInFullLockerException>(() => locker.Store(bag2));
        }

        [Test]
        public void should_store_nothing_in_locker()
        {
            Bag bag = null;
            Ticket ticket = locker.Store(bag);
            Assert.That(ticket, Is.Not.Null);
        }

    }
}
