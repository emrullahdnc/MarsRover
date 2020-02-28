using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.TestApp.Models
{
    public class Area
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Area(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
