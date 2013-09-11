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

        [Test]
        public void Should_store_into_smart_robot_when_locker_and_robot_are_full()
        {
            var smartRobot = new SmartRobot();
            smartRobot.Manage(new List<Locker>{new Locker(1)});

            var robot = new Robot();
            robot.Manage(new List<Locker>{new Locker(1)});

            var manager = new Manager(new Locker(1), robot, smartRobot);
           
            manager.Store(new Bag());
            manager.Store(new Bag());
            var ticket = manager.Store(new Bag());
            Assert.NotNull(ticket);
            Assert.NotNull(smartRobot.Pick(ticket));
        }
    }

    public class Manager
    {
        private readonly Locker locker;
        private readonly Robot robot;
        private readonly SmartRobot smartRobot;

        public Manager(Locker locker, Robot robot = null, SmartRobot smartRobot = null)
        {
            this.locker = locker;
            this.robot = robot;
            this.smartRobot = smartRobot;
        }

        public Ticket Store(Bag bag)
        {
            var ticket = locker.Store(bag) ?? (robot.Store(bag) ?? smartRobot.Store(bag));
            return ticket;
        }
    }
}
