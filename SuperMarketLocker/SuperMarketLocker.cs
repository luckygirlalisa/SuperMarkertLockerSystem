using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarketLockerSystem.SuperMarketLockerSystemTest;

namespace SuperMarketLockerSystem
{
    public class SuperMarketLocker
    {
        private Ticket ticket = new Ticket();

        public Ticket Store(Bag bag)
        {
            return ticket;
        }
    }

    public class Ticket
    {
    }
}
