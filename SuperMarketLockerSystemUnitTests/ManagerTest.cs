using System.Collections.Generic;
using NUnit.Framework;
using SuperMarketLockerSystem;

namespace SuperMarketLockerSystemUnitTests
{
    public class ManagerTest
    {
        [Test]
        public void should_store_into_locker_when_locker_is_not_full()
        {
            var locker = new Locker(2);
            var manager = new Manager(locker);

            var ticket = manager.Store(new Bag());

            Assert.NotNull(ticket);
            Assert.NotNull(locker.Pick(ticket));
        }

        [Test]
        public void should_store_into_robot_when_locker_is_full()
        {
            var robot = new Robot();
            robot.Manage(new List<Locker> {new Locker(1)});

            var locker = new Locker(1);

            var manager = new Manager(locker, robot);

            manager.Store(new Bag());
            var ticket = manager.Store(new Bag());

            Assert.NotNull(ticket);
            Assert.NotNull(robot.Pick(ticket));
        }

        [Test]
        public void should_store_into_smart_robot_when_locker_and_robot_are_full()
        {
            var smartRobot = new SmartRobot();
            smartRobot.Manage(new List<Locker> {new Locker(1)});

            var robot = new Robot();
            robot.Manage(new List<Locker> {new Locker(1)});

            var locker = new Locker(1);

            var manager = new Manager(locker, robot, smartRobot);

            manager.Store(new Bag());
            manager.Store(new Bag());
            var ticket = manager.Store(new Bag());
            Assert.NotNull(ticket);
            Assert.NotNull(smartRobot.Pick(ticket));
        }

        [Test]
        public void should_store_into_super_robot_when_locker_and_robot_and_smart_robot_are_all_full()
        {
            var superRobot = new SuperRobot();
            superRobot.Manage(new List<Locker> {new Locker(1)});

            var smartRobot = new SmartRobot();
            smartRobot.Manage(new List<Locker> {new Locker(1)});

            var robot = new Robot();
            robot.Manage(new List<Locker> {new Locker(1)});

            var locker = new Locker(1);

            var manager = new Manager(locker, robot, smartRobot, superRobot);

            manager.Store(new Bag());
            manager.Store(new Bag());
            manager.Store(new Bag());
            var ticket = manager.Store(new Bag());

            Assert.NotNull(ticket);
            Assert.NotNull(superRobot.Pick(ticket));
        }
    }

    public class Manager
    {
        private readonly Locker locker;
        private readonly Robot robot;
        private readonly SmartRobot smartRobot;
        private readonly SuperRobot superRobot;

        public Manager(Locker locker, Robot robot = null, SmartRobot smartRobot = null, SuperRobot superRobot = null)
        {
            this.locker = locker;
            this.robot = robot;
            this.smartRobot = smartRobot;
            this.superRobot = superRobot;
        }

        public Ticket Store(Bag bag)
        {
            var ticket = locker.Store(bag) ?? (robot.Store(bag) ?? (smartRobot.Store(bag) ?? superRobot.Store(bag)));
            return ticket;
        }
    }
}
