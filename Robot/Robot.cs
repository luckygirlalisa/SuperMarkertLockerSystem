using System.Collections.Generic;
using System.Linq;

namespace SuperMarketLockerSystem.Robot
{
    public class Robot
    {
        protected List<Locker> Lockers;

        public virtual Ticket Store(Bag bag)
        {
            if (IsRobotAvailable())
            {
                var locker = GetAvailableLockerWithSmallIndex();
                return locker.Store(bag);
            }
            return null;
        }
      
        public Bag Pick(Ticket ticket)
        {
            return Lockers.Select(locker => locker.Pick(ticket)).FirstOrDefault(pickedBag => pickedBag != null);
        }

        public void Manage(List<Locker> lockers)
        {
            Lockers = lockers;
        }

        private Locker GetAvailableLockerWithSmallIndex()
        {
            return Lockers.FirstOrDefault(locker => locker.isLockerAvailable);
        }

        protected bool IsRobotAvailable()
        {
            if (Lockers.Count != 0)
            {
                return Lockers.Any(l => l.isLockerAvailable);
            }
            return false;
        }

    }
}