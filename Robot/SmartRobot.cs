using System.Linq;

namespace SuperMarketLockerSystem.Robot
{
    public class SmartRobot : Robot
    {
        public override Ticket Store(Bag bag)
        {
            if (IsRobotAvailable())
            {
                var locker = GetLockerWithMostAvailableBoxes();
                return locker.Store(bag);
            }
            return null;
        }
      
        private Locker GetLockerWithMostAvailableBoxes()
        {
            return Lockers.Find(l =>
            {
                var max = Lockers.Select(locker => locker.availableBoxesNum).Concat(new[] {0}).Max();
                return l.availableBoxesNum == max;
            });
        }
    }
}