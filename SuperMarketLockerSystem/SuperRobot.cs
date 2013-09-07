﻿namespace SuperMarketLockerSystem
{
    public class SuperRobot : Robot
    {
        protected override Locker GetLocker()
        {
            float maxPercentage = 0;
            var maxVacancyRateLocker = new Locker(0);
            foreach (var locker in Lockers)
            {
                if (locker.GetAvailableBoxesPercentage() > maxPercentage)
                {
                    maxPercentage = locker.GetAvailableBoxesPercentage();
                    maxVacancyRateLocker = locker;
                }
            }
            return maxVacancyRateLocker;
        }
    }
}