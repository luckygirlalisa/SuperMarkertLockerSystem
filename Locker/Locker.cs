using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SuperMarketLockerSystem
{
    public class Locker
    {
        public bool isLockerAvailable;
        public int availableBoxesNum;
        private Dictionary<Ticket, Bag> ticketBagRelation = new Dictionary<Ticket, Bag>(); 

        public Locker(int availableBoxesNum)
        {
            this.availableBoxesNum = availableBoxesNum;
            isLockerAvailable = isAvailableLocker();
        }

        public Ticket Store(Bag bag)
        {
            if (isLockerAvailable)
            {
                var ticket = new Ticket();
                ticketBagRelation.Add(ticket, bag);
                availableBoxesNum--;
                isLockerAvailable = isAvailableLocker();
                return ticket;
            }
            return null;
        }

        public Bag Pick(Ticket ticket)
        {
            if (hasMatchedTicket(ticket))
            {
                availableBoxesNum++;
                isLockerAvailable = isAvailableLocker();
                var bag = ticketBagRelation[ticket];
                ticketBagRelation.Remove(ticket);
                return bag;
            }
            return null;

        }

        private bool hasMatchedTicket(Ticket ticket)
        {
            return ticketBagRelation != null && ticket != null && ticketBagRelation.ContainsKey(ticket);
        }

        private bool isAvailableLocker()
        {
            return availableBoxesNum > 0;
        }

    }
}
