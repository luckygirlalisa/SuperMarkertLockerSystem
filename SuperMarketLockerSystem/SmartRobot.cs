using System.Linq;

namespace SuperMarketLockerSystem
{
    public class SmartRobot : Robot
    {
        protected override Locker GetLocker()
        {
            return Lockers.Find(l =>
            {
                var max = Lockers.Select(locker => locker.AvailableBoxesNum).Concat(new[] {0}).Max();
                return l.AvailableBoxesNum == max;
            });
        }
    }
}