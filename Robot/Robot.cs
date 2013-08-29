namespace SuperMarketLockerSystem
{
    public class Robot
    {
        private int capacity;
        private Locker[] lockers;
        private int index = 0;

        public Robot(int capacity)
        {
            this.capacity = capacity;
            lockers = new Locker[this.capacity];
            for (int i = 0; i < capacity; i++)
            {
                lockers[i] = new Locker(10);
            }
        }

        public Ticket Store(Bag bag)
        {
            if (index > capacity-1)
            {
                return null;
            }
            Ticket ticket = lockers[index].Store(bag);
            ticket.belonedLockerId = index;
            index++;
            return ticket;
        }

        public Bag Pick(Ticket ticket)
        {
            for (int i = 0; i < capacity; i++)
            {
                Bag bag = lockers[i].Pick(ticket);
                if (bag != null)
                {
                    return bag;
                }
            }
            return null;
        }
    }
}