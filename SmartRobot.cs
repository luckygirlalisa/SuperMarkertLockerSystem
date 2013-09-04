using System.Linq;

namespace SuperMarketLockerSystem
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
                var max = Lockers.Select(locker => locker.AvailableBoxesNum).Concat(new[] {0}).Max();
                return l.AvailableBoxesNum == max;
            });
        }
    }
}