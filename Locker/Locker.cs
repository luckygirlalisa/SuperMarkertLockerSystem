using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SuperMarketLockerSystem.SuperMarketLockerSystemTest;

namespace SuperMarketLockerSystem
{
    public class Locker
    {
        private bool isFull;
        private int availableBoxesNum;
        private Dictionary<Ticket, Bag> ticketBagRelation = new Dictionary<Ticket, Bag>(); 

        public Locker(int availableBoxesNum)
        {
            this.availableBoxesNum = availableBoxesNum;
            isFull = isAvailableLocker();
        }

        public Ticket Store(Bag bag)
        {
            if (!isFull)
            {
                var ticket = new Ticket();
                ticketBagRelation.Add(ticket, bag);
                availableBoxesNum--;
                isFull = isAvailableLocker();
                return ticket;
            }
            return null;
        }

        public Bag Pick(Ticket ticket)
        {
            if (hasMatchedTicket(ticket))
            {
                availableBoxesNum++;
                isFull = isAvailableLocker();
                return ticketBagRelation[ticket];
            }
            return null;

        }

        private bool hasMatchedTicket(Ticket ticket)
        {
            return ticketBagRelation != null && ticket != null && ticketBagRelation.ContainsKey(ticket);
        }

        private bool isAvailableLocker()
        {
            return availableBoxesNum < 0;
        }

    }
}
