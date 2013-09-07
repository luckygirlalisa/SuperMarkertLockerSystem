using System.Collections.Generic;

namespace SuperMarketLockerSystem
{
    public class SuperRobot 
    {
        private readonly List<Locker> lockers = new List<Locker>();

        public Ticket Store(Bag bag)
        {
            if (lockers.Count == 0)
                return null;

            float maxPercentage = 0;
            var maxLocker = new Locker(0);
            foreach (var locker in lockers)
            {
                if (locker.GetAvailableBoxesPercentage() > maxPercentage)
                {
                    maxPercentage = locker.GetAvailableBoxesPercentage();
                    maxLocker = locker;
                }
            }

            return maxLocker.Store(bag);
        }

        public void Manage(List<Locker> lockers)
        {
            foreach (Locker locker in lockers)
            {
                this.lockers.Add(locker);
            }
        }
    }
}