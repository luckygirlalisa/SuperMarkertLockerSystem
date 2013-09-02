using System.Collections.Generic;
using System.Linq;

namespace SuperMarketLockerSystem.Robot
{
    public class Robot
    {
        private List<Locker> lockers;

        public Ticket Store(Bag bag)
        {
            if (IsRobotAvailable())
            {
                var locker = GetLockerWithMostAvailableBoxes();
                return locker.Store(bag);
            }
            return null;
        }
      
        public Bag Pick(Ticket ticket)
        {
            return lockers.Select(locker => locker.Pick(ticket)).FirstOrDefault(pickedBag => pickedBag != null);
        }

        public void Manage(List<Locker> lockers)
        {
            this.lockers = lockers;
        }

        private Locker GetLockerWithMostAvailableBoxes()
        {
            return lockers.Find(l =>
            {
                var max = lockers.Select(locker => locker.availableBoxesNum).Concat(new[] {0}).Max();
                return l.availableBoxesNum == max;
            });
        }

        private bool IsRobotAvailable()
        {
            if (lockers.Count != 0)
            {
                return lockers.Any(l => l.isLockerAvailable);
            }
            return false;
        }

    }
}