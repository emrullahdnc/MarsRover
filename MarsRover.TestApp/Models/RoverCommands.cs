using MarsRover.App.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.TestApp.Models
{
    public class RoverCommands
    {
        List<Robots> Robots;
        Area Area;
        public RoverCommands(List<Robots> robots_, Area area)
        {
            Robots = robots_;
            Area = area;
        }
        public enum Directions
        {
            N = 0,
            E = 1,
            S = 2,
            W = 3
        }

        /// <summary>
        /// Sends robots to Commanding method
        /// </summary>
        /// <returns></returns>
        public List<Robots> RedirectRobots()
        {
            foreach (var item in Robots)
            {
                CommandRobots(item);
            }

            return Robots;
        }

        /// <summary>
        /// Sets new position and direction of the robots by commands
        /// </summary>
        /// <param name="robot"></param>
        private void CommandRobots(Robots robot)
        {
            try
            {
                foreach (char item in robot.Commands)
                {
                    if (item == 'M')
                    {
                        robot = SetNewPosition(robot);
                    }
                    else
                    {
                        if (robot.IsSuccses)
                        {
                            robot.Direction = SetNewDirection(robot.Direction, item);
                        }
                        else
                        {
                            return;
                        }

                    }
                }

                robot.NewPosition = robot.PositionX.ToString() + " " + robot.PositionY.ToString() + " " + robot.Direction.ToString();
            }
            catch (Exception ex)
            {
                robot.IsSuccses = false;
                robot.ErrorMessage = $"Robot's redirecting is failed - {CommonExtensions.GetInnerException(ex).Message}";
            }
        }

        /// <summary>
        /// Sets the robot's new  directions by command
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        private Directions SetNewDirection(Directions direction, char command)
        {
            int olddirection = (int)direction;
            if (command == 'L')
            {

                if ((olddirection - 1) < 0)
                {
                    direction = Directions.W;
                }
                else
                {
                    direction = (Directions)(olddirection - 1);
                }
            }
            else if (command == 'R')
            {

                if ((olddirection + 1) > 3)
                {
                    direction = Directions.N;
                }
                else
                {
                    direction = (Directions)(olddirection + 1);
                }
            }

            return direction;
        }

        /// <summary>
        /// Sets the robot's new poistion by command
        /// </summary>
        /// <param name="robot"></param>
        /// <returns></returns>
        private Robots SetNewPosition(Robots robot)
        {
            int PositionX = robot.PositionX;
            int PositionY = robot.PositionY;
            switch (robot.Direction)
            {
                case Directions.N:
                    PositionY++;
                    break;
                case Directions.E:
                    PositionX++;
                    break;
                case Directions.S:
                    PositionY--;
                    break;
                case Directions.W:
                    PositionX--;
                    break;
            }

            if (PositionX > Area.X || PositionY > Area.Y)
            {
                robot.IsSuccses = false;
                robot.ErrorMessage = "Values are out of Area!";
            }
            else
            {
                robot.PositionX = PositionX;
                robot.PositionY = PositionY;
            }

            return robot;
        }
    }
}
