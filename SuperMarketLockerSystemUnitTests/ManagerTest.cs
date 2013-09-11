using System.Collections.Generic;
using NUnit.Framework;
using SuperMarketLockerSystem;

namespace SuperMarketLockerSystemUnitTests
{
    public class ManagerTest
    {
        [Test]
        public void Should_store_into_locker_when_locker_is_not_full()
        {
            var locker = new Locker(2);
            var manager = new Manager(locker);
            
            var ticket = manager.Store(new Bag());
            
            Assert.NotNull(ticket);
            Assert.NotNull(locker.Pick(ticket));
        }

        [Test]
        public void Should_store_into_robot_when_locker_is_full()
        {
            var lockerForRobot = new Locker(1);
            var robot = new Robot();
            robot.Manage(new List<Locker>{lockerForRobot});
            var lockerForManager = new Locker(1);
            var manager = new Manager(lockerForManager,robot);
            
            manager.Store(new Bag());
            var ticket = manager.Store(new Bag());

            Assert.NotNull(ticket);
            Assert.NotNull(robot.Pick(ticket));
        }

    }

    public class Manager
    {
        private readonly Locker locker;
        private Robot robot;

        public Manager(Locker locker)
        {
            this.locker = locker;
        }

        public Manager(Locker locker, Robot robot)
        {
            this.locker = locker;
            this.robot = robot;
        }

        public Ticket Store(Bag bag)
        {
            var ticket = locker.Store(bag);
            return ticket ?? robot.Store(bag);
        }
    }
}
