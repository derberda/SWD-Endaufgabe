using System;
using System.Collections.Generic;

namespace swd_projekt
{
    class Win
    {
        public static void checkWin(Location location, Avatar avatarInfos)
        {
            if (location.Title == "The backyard")
            {
                if (avatarInfos.inventory.Exists(x => x.Title == "plier"))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("You cut a hole in the fence with your plier and you can escape now.\nYou've looted following things:\n");
                    Console.ResetColor();
                    if (avatarInfos.inventory.Count > 0)
                    {
                        foreach (var item in avatarInfos.inventory)
                        {
                            Console.WriteLine(item.Title);
                        }
                    }
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("You can't get over the fences. Search for an Item that could help you!");
                }
            }
        }
    }
}