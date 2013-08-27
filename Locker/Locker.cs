using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SuperMarketLockerSystem.SuperMarketLockerSystemTest;

namespace SuperMarketLockerSystem
{
    public class Locker
    {
        private bool isStored = false;
        private Bag bag;
        private Ticket ticket;

        public Ticket Store(Bag bag)
        {
            if (!isStored)
            {
                this.bag = bag;
                isStored = true;
                ticket =  new Ticket();
                return ticket;
            }
            return null;
        }

        public Bag Pick(Ticket ticket)
        {
            if (this.ticket == ticket)
            {
                isStored = false;
                return bag;
            }
            return null;

        }
    }
}
