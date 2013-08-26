using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SuperMarketLockerSystem.SuperMarketLockerSystemTest
{
    class LockerTest
    {
        [Test]
        public void should_return_ticket_when_store_a_bag()
        {
            //given
            var locker = new SuperMarketLocker();
            var bag = new Bag();
            
            //when
            var ticket = locker.Store(bag);
            //then
            Assert.NotNull(ticket);
        }
    }

    public class Bag
    {

    }
}
