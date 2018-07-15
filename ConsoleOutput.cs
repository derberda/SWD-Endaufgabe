using System;
using System.Collections.Generic;

namespace swd_projekt
{
    class ConsoleOutput
    {
        #region LocationText
        public static void Introduction()
        {
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Welcome to Nashville. You run away from home and homeless now. But you have to go on and you didn't eat anything in th last times. Maybe you can borrow something from the supermarket");
            Console.ResetColor();
        }
        public static void DescribeRoom(Location location)
        {
            Console.WriteLine("_______________________________________________________________________________________________________________________________________________________________");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(location.Title);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine();
            Console.WriteLine(location.Description);
            Console.ResetColor();
            if (location.Items.Count > 0)
            {
                Console.WriteLine("In the room you can see these items: ");
                foreach (var i in location.Items)
                {
                    Console.WriteLine(i.Title + " - " + i.Description);
                }
            }
            Console.WriteLine("_______________________________________________________________________________________________________________________________________________________________");
        }

        public static void RoomCheckText(Enemy enemyInfos)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("The " + enemyInfos.Name + "is in the house - You have fight!");
            Console.WriteLine("What do you want to do? - You can attack the enemy or flee!\nTo flee walk in a direction. To attack write it like this: a/attack + enemyname.");
            Console.ResetColor();
            Console.WriteLine("_______________________________________________________________________________________________________________________________________________________________");
        }
        #endregion

        #region ItemText
        public static void EmptyBag()
        {
            Console.WriteLine("There is nothing in your bag.");
        }
        public static void NotExistingItem()
        {
            Console.WriteLine("This item does not exist!");
        }
        public static void ChooseItem()
        {
            Console.WriteLine("You have to choose an item!");
        }
        public static void FalseItemInput(string words)
        {
            if (words == "t")
                Console.WriteLine("I don't understand this input :/ Please write it like this: t/take + itemname.");
            else if (words == "d")
                Console.WriteLine("I don't understand this input :/ Please write it like this: d/drop + itemname.");
        }
        #endregion
    }
}