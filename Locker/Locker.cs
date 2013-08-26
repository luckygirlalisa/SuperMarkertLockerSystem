using SuperMarketLockerSystem.SuperMarketLockerSystemTest;

namespace SuperMarketLockerSystem
{
    public class Locker
    {
        private Ticket ticket = new Ticket();
        private int storeFlag = 0;
        public Ticket Store(Bag bag)
        {
            if (storeFlag == 0)
            {
                storeFlag ++ ;
                return ticket;
            }
            else
            {
                throw new StoreBagInFullLockerException("Can't store bag in a full locker");
            }
        }
    }

    public class Ticket
    {
    }
}
