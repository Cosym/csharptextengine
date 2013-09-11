using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextBased
{
    static class GameManager
    {
        public static void ShowTitle()
        {
            Console.Clear();

            Console.WriteLine(TextUtils.WordWrap("INPUT TITLE SCREEN DESCRIPTION HERE", Console.WindowWidth));


            Console.WriteLine("\n\nPress any key to begin....");
            Console.CursorVisible = false;
            Console.ReadKey();
            Console.CursorVisible = true;
            Console.Clear();
        }
        public static void StartGame()
        {
            Player.GetCurrentRoom().Describe();
            TextBuffer.Display();
        }
        public static void EndGame(string endingText)
        {
            Program.exit = true;

            Console.Clear();

            Console.WriteLine(TextUtils.WordWrap(endingText, Console.WindowWidth));
            Console.WriteLine("\nYou may now close this console.");
            Console.CursorVisible = false;

            while (true)
                Console.ReadKey(true);
        }
        public static void ApplyRules()
        {
            //Death
            if (Player.Health <= 0)
            {
                EndGame("Your limbs feel numb and your eyes slowly close as you fall to the floor... you are dead!");
            }
            //--------

        }
        public static void Achievements()
        {
            //Add if you have activated the achievements menu
        }
    }
}
