namespace SuperMarketLockerSystem
{
    public class Robot
    {
        private Locker locker = new Locker();
        public Ticket Store(Bag bag)
        {
            return locker.Store(bag);
        }

        public Bag Pick(Ticket ticket)
        {
            return locker.Pick(ticket);
        }
    }
}