using System.Collections.Generic;
using System.Linq;

namespace SuperMarketLockerSystem
{
    public class Robot
    {
        protected List<Locker> Lockers = new List<Locker>();

        public virtual Ticket Store(Bag bag)
        {
            if (IsRobotAvailable())
            {
                var locker = GetLocker();
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
            foreach (var locker in lockers)
            {
                Lockers.Add(locker);
            }
        }

        protected virtual Locker GetLocker()
        {   
            return Lockers.FirstOrDefault(locker => locker.IsLockerAvailable);
        }

        protected bool IsRobotAvailable()
        {
            return Lockers.Count != 0 && Lockers.Any(l => l.IsLockerAvailable);
        }
    }
}