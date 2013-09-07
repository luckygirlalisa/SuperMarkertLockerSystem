using System.Collections.Generic;

namespace SuperMarketLockerSystem
{
    public class Locker
    {
        public bool IsLockerAvailable
        {
            get{return AvailableBoxesNum > 0;}
        }

        public int AvailableBoxesNum;
        private readonly int boxesTotal;

        private readonly Dictionary<Ticket, Bag> ticketBagRelation = new Dictionary<Ticket, Bag>();

        public Locker(int boxesTotal)
        {
            AvailableBoxesNum = this.boxesTotal = boxesTotal;
        }

        public Ticket Store(Bag bag)
        {
            if (IsLockerAvailable)
            {
                var ticket = new Ticket();
                ticketBagRelation.Add(ticket, bag);
                AvailableBoxesNum--;
                return ticket;
            }
            return null;
        }

        public Bag Pick(Ticket ticket)
        {
            if (HasMatchedTicket(ticket))
            {
                AvailableBoxesNum++;
                var bag = ticketBagRelation[ticket];
                ticketBagRelation.Remove(ticket);
                return bag;
            }
            return null;

        }

        public float GetAvailableBoxesPercentage()
        {
            return  AvailableBoxesNum/boxesTotal;
        }

        private bool HasMatchedTicket(Ticket ticket)
        {
            return ticketBagRelation != null && ticket != null && ticketBagRelation.ContainsKey(ticket);
        }
    }
}
