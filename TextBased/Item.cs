using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextBased
{
    class Item
    {
        private string title;
        private string pickupText;
        private string description;

        private int weight = 1;
        private int damage = 1;
        private int level = 1;

        private bool isUsable = false;
        private bool isWeapon = false;

        #region props

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

        public string PickUpText
        {
            get { return pickupText; }
            set { pickupText = value; }
        }


        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        public int Damage
        {
            get { return damage; }
            set { damage = value; }
        }

        public int Level
        {
            get { return level; }
            set { level = value; }
        }


        public bool IsUsable
        {
            get { return isUsable; }
            set { isUsable = value; }
        }

        public bool IsWeapon
        {
            get { return isWeapon; }
            set { isWeapon = value; }
        }

        #endregion

        //Usable items listed below: To be added once created.
    }
}
