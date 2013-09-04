using System.Collections.Generic;

namespace SuperMarketLockerSystem
{
    public class Locker
    {
        public bool IsLockerAvailable;
        public int AvailableBoxesNum;
        private readonly Dictionary<Ticket, Bag> ticketBagRelation = new Dictionary<Ticket, Bag>(); 

        public Locker(int availableBoxesNum)
        {
            AvailableBoxesNum = availableBoxesNum;
            IsLockerAvailable = IsAvailableLocker();
        }

        public Ticket Store(Bag bag)
        {
            if (IsLockerAvailable)
            {
                var ticket = new Ticket();
                ticketBagRelation.Add(ticket, bag);
                AvailableBoxesNum--;
                IsLockerAvailable = IsAvailableLocker();
                return ticket;
            }
            return null;
        }

        public Bag Pick(Ticket ticket)
        {
            if (HasMatchedTicket(ticket))
            {
                AvailableBoxesNum++;
                IsLockerAvailable = IsAvailableLocker();
                var bag = ticketBagRelation[ticket];
                ticketBagRelation.Remove(ticket);
                return bag;
            }
            return null;

        }

        private bool HasMatchedTicket(Ticket ticket)
        {
            return ticketBagRelation != null && ticket != null && ticketBagRelation.ContainsKey(ticket);
        }

        private bool IsAvailableLocker()
        {
            return AvailableBoxesNum > 0;
        }

    }
}
