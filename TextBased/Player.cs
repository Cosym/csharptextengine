using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextBased
{
    static class Player
    {
        //The position of the player which is the room that they are in
        private static int posX;
        private static int posY;

        private static List<Item> inventoryItems;
        //Keep track of how many times the player has ruled for custom rules
        private static int moves = 0;
        //Limit the amount of items the player can carry based on item weight
        private static int weightCapacity = 16;

        //If you wish to add traps this will allow you to damage the player
        private static int health = 32;

        #region properties

        public static int PosX
        {
            get { return posX; }
            set { posX = value; }
        }

        public static int PosY
        {
            get { return posY; }
            set { posY = value; }
        }

        public static int Health
        {
            get { return health; }
            set { health = value; }
        }

        public static int Moves
        {
            get { return moves; }
            set { moves = value; }
        }

        public static int WeightCapacity
        {
            get { return weightCapacity; }
            set { weightCapacity = value; }
        }

        public static int InventoryWeight
        {
            get
            {
                int result = 0;
                foreach (Item item in inventoryItems)
                {
                    result += item.Weight;
                }
                return result;
            }
        }

        #endregion

        static Player()
        {
            inventoryItems = new List<Item>();
        }

        //Commands Below

        //Command to view an items description that they have in their inventory that is in the room
        public static void Examine(string itemName)
        {
            Room room = Player.GetCurrentRoom();
            Item item = Player.GetInventoryItem(itemName);
            Item rmitem = room.GetItem(itemName);
            string underline = "";
            underline = underline.PadLeft(itemName.Length, '-');

            if (itemName != null)
            {

                if (item != null)
                {
                    TextBuffer.Add(itemName + ":" + "\n" + underline + "\n\n" + item.Description);
                }
                else if (room.GetItem(itemName) != null)
                {
                    TextBuffer.Add(itemName + ":" + "\n" + underline + "\n\n" + rmitem.Description);
                }
                else
                    TextBuffer.Add("Please type a valid item that is in your inventory or room to examine.");
            }
            else
                TextBuffer.Add("Please type a valid item that is in your inventory or room to examine.");

        }
        public static void Use(string itemName)
        {
            //Not implemented by default, create functions for certain items if they are used such as a torch
        }
        //Function which is for movement
        public static void Go(string direction)
        {
            Room room = Player.GetCurrentRoom();

            if (!room.CanExit(direction))
            {
                TextBuffer.Add("Invalid Direction");
                return;
            }

            Player.moves++;

            switch (direction)
            {
                case Direction.Up:
                    posY--;
                    break;
                case Direction.Down:
                    posY++;
                    break;
                case Direction.Right:
                    posX++;
                    break;
                case Direction.Left:
                    posX--;
                    break;
            }

            Player.GetCurrentRoom().Describe();
        }
        public static void PickupAll()
        {
            //Not in by default
        }
        public static void PickupItem(string itemName)
        {
            Room room = Player.GetCurrentRoom();
            Item item = room.GetItem(itemName);

            if (item != null)
            {
                if (Player.InventoryWeight + item.Weight > Player.weightCapacity)
                {
                    TextBuffer.Add("Your inventory has exceeded the weight limit, please drop an item first.");
                    return;
                }
                TextBuffer.Add(item.PickUpText);
                room.Items.Remove(item);
                Player.inventoryItems.Add(item);
            }
            else
                TextBuffer.Add("There is no " + itemName + " in this room.");
        }
        public static void DropItem(string itemName)
        {
            Room room = Player.GetCurrentRoom();
            Item item = GetInventoryItem(itemName);

            if (item != null)
            {
                Player.inventoryItems.Remove(item);
                room.Items.Add(item);
                TextBuffer.Add("You dropped " + itemName + " into this room.");
            }
            else
                TextBuffer.Add("There is no " + itemName + " in your inventory");
        }
        public static void DisplayInventory()
        {
            string message = "Your inventory contains:";
            string items = "";
            string underline = "";
            underline = underline.PadLeft(message.Length, '-');

            int health = Player.Health;

            TextBuffer.Add("Health: " + health + "/32\n\n");

            if (inventoryItems.Count > 0)
            {
                foreach (Item item in inventoryItems)
                {
                    items += "\n[" + item.Title + "] wt: " + item.Weight.ToString();
                }
            }
            else
                items = "\n<No Items>";

            items += "\n\nTotal Wt: " + Player.InventoryWeight + " / " + Player.weightCapacity;

            TextBuffer.Add(message + "\n" + underline + items);
        }
        public static Item GetInventoryItem(string itemName)
        {
            foreach (Item item in inventoryItems)
            {
                if (item.Title.ToLower() == itemName.ToLower())
                    return item;
            }
            return null;
        }

        //--------------
        //Load default items if wanted
        public static void StartInv()
        {

        }
        public static Room GetCurrentRoom()
        {
            return Level.Rooms[posX, posY];
        }
    }
}
