using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using static MarsRover.TestApp.Models.RoverCommands;

namespace MarsRover.TestApp.Models
{
    public static class Validation
    {

        /// <summary>
        /// Number Validation
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNumber(string value)
        {
            Regex regex = new Regex(@"^\d$");
            return regex.IsMatch(value);
        }

        /// <summary>
        /// Direction Validation
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsDirectionCorrect(string value)
        {
            Directions directions;
            return Enum.TryParse<Directions>(value, out directions);
        }

        /// <summary>
        /// Valid Coordinates
        /// </summary>
        /// <param name="area"></param>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <returns></returns>
        public static bool IsCoordinatesValid(Area area, string value)
        {
            bool IsOk = true;
            try
            {
                if (value.Split(' ').Length != 3)
                {
                    IsOk = false;
                }
                else
                {
                    string[] values = value.Split(' ');
                    if (!IsNumber(values[0]) || !IsNumber(values[1]))
                    {
                        IsOk = false;
                    }
                    else
                    {
                        if (area.X < Convert.ToInt32(values[0]) || area.Y < Convert.ToInt32(values[1]))
                        {
                            IsOk = false;
                        }
                        else
                        {
                            IsOk = IsDirectionCorrect(values[2]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                IsOk = false;
            }
            return IsOk;
        }
        /// <summary>
        /// Current Position is Valid
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsAreaValid(string value)
        {
            bool IsOk = true;
            try
            {
                if (value.Split(' ').Length != 2)
                {
                    IsOk = false;
                }
                else
                {
                    string[] areas = value.Split(' ');
                    if (!IsNumber(areas[0]) || !IsNumber(areas[1]))
                    {
                        IsOk = false;
                    }
                }


            }
            catch (Exception)
            {
                IsOk = false;
            }

            return IsOk;
        }

        /// <summary>
        /// Command is valid
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsCommandsValid(string value)
        {
            bool IsOk = true;
            Regex regex = new Regex(@"^[a-zA-Z]+$");
            IsOk = regex.IsMatch(value);
            if (IsOk)
            {
                foreach (char item in value.ToUpper())
                {
                    if (item != 'L' && item != 'R' && item != 'M') { IsOk = false; }
                }
            }
            return IsOk;
        }

    }
}
