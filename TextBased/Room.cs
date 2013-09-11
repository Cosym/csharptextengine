using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextBased
{
    class Room
    {
        private string title;
        private string description;
        private List<string> exits;
        private List<Item> items;
        private bool isDark = false;
        private bool isRadiated = false;

        #region prop

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public bool IsDark
        {
            get { return isDark; }
            set { isDark = value; }
        }

        public bool IsRadiated
        {
            get { return isRadiated; }
            set { isRadiated = value; }
        }

        public List<Item> Items
        {
            get { return items; }
            set { items = value; }
        }

        #endregion

        public Room()
        {
            exits = new List<string>();
            items = new List<Item>();
        }


        //Public Methods

        public void Describe()
        {
            //Debug Util - Display coords at top
            TextBuffer.Add(this.GetCoord());
            //--------
            TextBuffer.Add(this.description);
            TextBuffer.Add(this.GetItemList());
            TextBuffer.Add(this.GetExitList());
        }
        public void ShowTitle()
        {
            TextBuffer.Add(this.title);
        }
        public Item GetItem(string itemName)
        {
            foreach (Item item in this.items)
            {
                if (item.Title.ToLower() == itemName.ToLower())
                    return item;
            }
            return null;
        }
        public void AddExit(string direction)
        {
            if (this.exits.IndexOf(direction) == -1)
                this.exits.Add(direction);
        }
        public void RemoveExit(string direction)
        {
            if (this.exits.IndexOf(direction) != -1)
                this.exits.Remove(direction);
        }
        public bool CanExit(string direction)
        {
            foreach (string validExit in this.exits)
            {
                if (direction == validExit)
                    return true;
            }
            return false;
        }


        //Private Methods

        private string GetItemList()
        {
            string itemString = "";
            string message = "Items in area:";
            string underline = "";
            underline = underline.PadLeft(message.Length, '-');

            if (this.items.Count > 0)
            {
                foreach (Item item in this.items)
                {
                    itemString += "\n[" + item.Title + "]";
                }
            }
            else
            {
                itemString = "\n<none>";
            }

            return "\n" + message + "\n" + underline + itemString;
        }
        private string GetExitList()
        {
            string exitString = "";
            string message = "Possible directions:";
            string underline = "";
            underline = underline.PadLeft(message.Length, '-');

            if (this.exits.Count > 0)
            {
                foreach (string exitDirection in this.exits)
                {
                    exitString += "\n[" + exitDirection + "]";
                }
            }
            else
            {
                exitString = "\n<none>";
            }

            return "\n" + message + "\n" + underline + exitString;
        }
        private string GetCoord()
        {
            for (int y = 0; y < Level.Rooms.GetLength(1); y++)
            {
                for (int x = 0; x < Level.Rooms.GetLength(0); x++)
                {
                    if (this == Level.Rooms[x, y])
                        return "[" + x.ToString() + "," + y.ToString() + "]";
                }
            }
            return "This room is not within the level grid and/or does not exist.";
        }

    }
}
