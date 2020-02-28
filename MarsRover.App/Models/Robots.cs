using System;
using System.Collections.Generic;
using System.Text;
using static MarsRover.App.Models.RoverCommands;

namespace MarsRover.App.Models
{
    public class Robots
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public Directions Direction { get; set; }
        public string Commands { get; set; }
        public string NewPosition { get; set; }
        public bool IsSuccses { get; set; } = true;
        public string ErrorMessage { get; set; }
    }
}
