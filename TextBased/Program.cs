using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextBased
{
    //This namespace is what is ran when the .exe is executed. It runs in a loop through several files notably the commandproc

    class Program
    {
        public static bool exit = false;

        static void Main(string[] args)
        {
            //The title screen is the first thing to show and can be used to build a menu if ran through a loop
            GameManager.ShowTitle();
            //Build the players inventory in case you have items already added from the start
            Player.StartInv();
            //Builds all the rooms in the game
            Level.CallBuild();
            //Game starts with building the initial room and running the text buffer
            GameManager.StartGame();
            //If the exit command is ran this will break the loop and end the game. By default this shows nothing after
            while (!exit)
            {
                CommandProc.ProcessCommand(Console.ReadLine());
            }
        }
    }
}
