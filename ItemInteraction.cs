using System;
using System.Collections.Generic;

namespace swd_projekt
{
    class ItemInteraction
    {
        public static void MyInventory(Avatar avatarInfos)
        {
            if (avatarInfos.inventory.Count > 0)
            {
                foreach (var i in avatarInfos.inventory)
                {
                    Console.WriteLine("Inventar: " + i.Title);
                }
            }
            else
            {
                ConsoleOutput.EmptyBag();
            }
        }
        public static void TakeItem(Location location, string words, Avatar avatarInfos)
        {
            Items foundItem = location.items.Find(x => x.Title.Contains(words));
            if (foundItem != null)
            {
                Console.WriteLine("Found: " + foundItem.Title);
            }
            else
            {
                ConsoleOutput.NotExistingItem();
            }
            if (location.items.Count > 0)
            {
                location.items.Remove(foundItem);
                avatarInfos.inventory.Add(foundItem);
            }
            else
            {
                Console.WriteLine("There are no items in this room!");
            }
        }
        public static void DropItem(Location location, string words, Avatar avatarInfos)
        {
            Items foundItem = avatarInfos.inventory.Find(x => x.Title.Contains(words));
            if (foundItem == null)
            {
                ConsoleOutput.NotExistingItem();
            }
            if (avatarInfos.inventory.Count > 0)
            {
                avatarInfos.inventory.RemoveAll(x => x.Title == words);
                location.items.Add(foundItem);
                MyInventory(avatarInfos);
            }
            else
            {
                ConsoleOutput.EmptyBag();
            }
        }
        public static void dropLoot(Location location, Enemy enemyInfos)
        {
            if (enemyInfos.Dead == true)
            {
                foreach (var item in enemyInfos.inventory)
                {
                    location.items.Add(item);
                }
                Console.WriteLine("Look there!! Your enemy dropped some items!");
                Console.WriteLine("_______________________________________________________________________________________________________________________________________________________________");
            }
        }
    }
}