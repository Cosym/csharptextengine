using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextBased
{
    static class CommandProc
    {
        public static void ProcessCommand(string input)
        {
            string command = TextUtils.ExtractCmd(input.Trim()).Trim().ToLower();
            string arguement = TextUtils.ExtractArgs(input.Trim().Trim().ToLower());

            if (Direction.isValidDirection(command))
            {
                Player.Go(command);
            }
            else
            {
                switch (command)
                {
                    case "exit":
                        Program.exit = true;
                        return;

                    case "help":
                        ShowHelp();
                        break;

                    case "examine":
                        Player.Examine(arguement);
                        break;

                    case "move":
                        Player.Go(arguement);
                        break;

                    case "look":
                        Player.GetCurrentRoom().Describe();
                        break;

                    case "pickup":
                        Player.PickupItem(arguement);
                        break;

                    case "pickupall": //Not built in to engine.
                        Player.PickupAll();
                        break;

                    case "drop":
                        Player.DropItem(arguement);
                        break;

                    case "inventory":
                        Player.DisplayInventory();
                        break;

                    case "whereami":
                        Player.GetCurrentRoom().ShowTitle();
                        break;

                    case "use":
                        Player.Use(arguement); //Not built into engine
                        break;

                    default:
                        TextBuffer.Add("Input not understood.");
                        break;
                }
                GameManager.ApplyRules();
                TextBuffer.Display();
            }
        }
            private static void ShowHelp()
            {
                Console.Clear();
                Console.WriteLine(TextUtils.WordWrap("Help menu not inputted: for info on commands open in VSC# and look in CommandProc class and commands in switch command.", Console.WindowWidth));
            }
        }
    }

