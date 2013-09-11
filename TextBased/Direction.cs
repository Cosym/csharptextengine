using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextBased
{
    public struct Direction
    {
        //the direction that the player can move in  - 2d grid
        public const string Up = "up";
        public const string Right = "right";
        public const string Down = "down";
        public const string Left = "left";

        public static bool isValidDirection(string direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    return true;

                case Direction.Down:
                    return true;

                case Direction.Right:
                    return true;

                case Direction.Left:
                    return true;
            }
            return false;
        }
    }
}
