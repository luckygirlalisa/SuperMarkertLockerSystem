using System.Collections.Generic;
using System.Linq;

namespace SuperMarketLockerSystem.Robot
{
    public class Robot
    {
        protected List<Locker.Locker> Lockers;

        public virtual Ticket Store(Bag bag)
        {
            if (IsRobotAvailable())
            {
                var locker = GetAvailableLockerWithLeastIndex();
                return locker.Store(bag);
            }
            return null;
        }
      
        public Bag Pick(Ticket ticket)
        {
            return Lockers.Select(locker => locker.Pick(ticket)).FirstOrDefault(pickedBag => pickedBag != null);
        }

        public void Manage(List<Locker.Locker> lockers)
        {
            Lockers = lockers;
        }

        private Locker.Locker GetAvailableLockerWithLeastIndex()
        {   
            return Lockers.FirstOrDefault(locker => locker.IsLockerAvailable);
        }

        protected bool IsRobotAvailable()
        {
            return Lockers.Count != 0 && Lockers.Any(l => l.IsLockerAvailable);
        }
    }
}