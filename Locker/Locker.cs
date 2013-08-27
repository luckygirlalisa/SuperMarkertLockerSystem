using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SuperMarketLockerSystem.SuperMarketLockerSystemTest;

namespace SuperMarketLockerSystem
{
    public class Locker
    {
        private int storeFlag = 0;
        List<Bag> bags = new List<Bag>();
        List<Ticket> tickets = new List<Ticket>();

        public Ticket Store(Bag parameterBag)
        {
            if (storeFlag == 0)
            {
                storeFlag ++ ;
                bags.Add(parameterBag);
                Ticket ticket = new Ticket(parameterBag);
                tickets.Add(ticket);
                return ticket;
            }
            else
            {
                throw new StoreBagInFullLockerException("Can't store parameterBag in a full locker");
            }
        }

//        public Bag PickWith(Ticket ticket)
//        {
//            return bags.Where(bag => bag.Equals(ticket.bag));
//        }

        public Bag PickWith(Ticket ticket)
        {
            if (ticket != null)
            {
                storeFlag--; 
                return bags.First(bag => bag.Equals(ticket.bag));
            }
            throw new InvaidTicketException("Ticket is null");
        }
    }
}
