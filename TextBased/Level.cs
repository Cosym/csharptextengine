using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextBased
{
    static class Level
    {
        private static Room[,] rooms;

        #region prop

        public static Room[,] Rooms
        {
            get { return rooms; }
        }

        #endregion

        public static void CallBuild()
        {
            BuildLevel();
        }
        private static void BuildLevel()
        {
            //Rooms work in a 2d grid based on x and y (you could alter it to be x, y and z easily) and the current size as 1, 1 gives 4 rooms
            //Alter the number and add a room for each dimension - new room could be 0, 1 or 1, 0 or increase size and that can be bigger
            rooms = new Room[1, 1];

            Room room;
            Item item;

            //A new room is added the the format of the below room
            ///////////Rooms below/////////////
            ////Room [0, 0]

            room = new Room();
            rooms[0, 0] = room;

            room.Title = "New Room";
            room.Description = "No Description";

            item = new Item();

            item.Title = "Ball";
            item.PickUpText = "You picked up the ball.";
            item.Description = "It is a small grey ball.";

            room.Items.Add(item);
        }
    }
}
