using System;
using System.Collections.Generic;
using MarsRover.TestApp.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static MarsRover.TestApp.Models.RoverCommands;

namespace MarsRover.TestApp
{
    [TestClass]
    public class MarsRoverTest
    {
        [TestMethod]
        public void TestKnonwPositionsResult1()
        {
            Robots robot1 = new Robots() { PositionX = 1, PositionY = 2, Direction = Directions.N, Commands = "LMLMLMLMM" };
            string resul1 = "1 3 N";

            List<Robots> robots = new List<Robots>() { robot1 };

            RoverCommands rc = new RoverCommands(robots, new Area(5, 4));
            robots = rc.RedirectRobots();

            Assert.AreEqual(robots[0].NewPosition, resul1);
        }

        [TestMethod]
        public void TestKnonwPositionsResult2()
        {
            Robots robot2 = new Robots() { PositionX = 3, PositionY = 3, Direction = Directions.E, Commands = "MMRMMRMRRM" };

            string result2 = "5 1 E";

            List<Robots> robots = new List<Robots>() { robot2 };

            RoverCommands rc = new RoverCommands(robots, new Area(5, 4));
            robots = rc.RedirectRobots();

            Assert.AreEqual(robots[0].NewPosition, result2);

        }
    }
}
