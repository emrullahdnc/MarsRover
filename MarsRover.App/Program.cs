using MarsRover.App.Extensions;
using MarsRover.App.Models;
using System;
using System.Collections.Generic;
using static MarsRover.App.Models.RoverCommands;

namespace MarsRover.App
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                List<Robots> robots = new List<Robots>();
                int robotCount = 0;

                Console.WriteLine("Please Enter Number of Robots");
                string value = Console.ReadLine();
                while (!Validation.IsNumber(value))
                {
                    Console.WriteLine("Value is not valid! Please Enter Number of Robots");
                    value = Console.ReadLine();
                }
                robotCount = Convert.ToInt32(value);


                Console.WriteLine("Please Enter Area of The Plateau");
                value = Console.ReadLine();
                while (!Validation.IsAreaValid(value))
                {
                    value = "";
                    Console.WriteLine("Area is not valid! Please Enter Area of The Plateau");
                    value = Console.ReadLine();
                }
                string[] areas = value.Split(' ');
                Area area = new Area(Convert.ToInt32(areas[0]), Convert.ToInt32(areas[1]));


                for (int i = 0; i < robotCount; i++)
                {
                    Console.WriteLine($"Please Enter {(i + 1).ToString()}. Robot's Current Possition");
                    value = Console.ReadLine();
                    while (!Validation.IsCoordinatesValid(area, value))
                    {
                        value = "";
                        Console.WriteLine($"Robot's Current Possition is not valid! Please Enter {(i + 1).ToString()}. Robot's Current Possition");
                        value = Console.ReadLine();
                    }
                    string[] positions = value.Split(' ');


                    Console.WriteLine($"Please Enter {(i + 1).ToString()}. Robot's Commands");
                    value = Console.ReadLine();
                    while (!Validation.IsCommandsValid(value))
                    {
                        Console.WriteLine($"Commands are not valid! Please Enter {(i + 1).ToString()}. Robot's Commands");
                        value = Console.ReadLine();
                    }
                    string commands = value;

                    Robots robot = new Robots();
                    robot.PositionX = Convert.ToInt32(positions[0]);
                    robot.PositionY = Convert.ToInt32(positions[1]);
                    robot.Direction = (Directions)System.Enum.Parse(typeof(Directions), positions[2]);
                    robot.Commands = commands;

                    robots.Add(robot);
                }

                RoverCommands rc = new RoverCommands(robots, area);
                robots = rc.RedirectRobots();

                foreach (var item in robots)
                {
                    if (item.IsSuccses)
                    {
                        Console.WriteLine($"{(robots.IndexOf(item) + 1).ToString()}. Robot's new Position is {item.NewPosition}");
                    }
                    else
                    {
                        Console.WriteLine($"{(robots.IndexOf(item) + 1).ToString()}. Robot's redirection is failed {item.ErrorMessage}");
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error : {CommonExtensions.GetInnerException(ex).Message}");
            }
            Console.ReadLine();
        }

    }
}

