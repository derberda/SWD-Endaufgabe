using System;
using System.Collections.Generic;

namespace swd_projekt
{
    class RoomInteraction
    {
        public static void RoomCheck(Avatar avatarInfos, Enemy enemyInfos)
        {
            if (avatarInfos.playerLocation == Enemy.randomLocation)
            {
                ConsoleOutput.RoomCheckText(enemyInfos);
            }
        }
        public static void LookThroughRoom(Location location)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("You're in the " + location.Title);
            Console.ResetColor();
            if (location.items.Count > 0)
            {
                Console.WriteLine("In the room you can see these items: ");
                foreach (var item in location.items)
                {
                    Console.WriteLine(item.Title + " - " + item.Description);
                }
            }
            else
            {
                Console.WriteLine("There are no items in this rooms.");
            }
        }
        
    }
}