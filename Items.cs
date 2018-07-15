using System;
using System.Collections.Generic;

namespace swd_projekt
{
    class Items
    {
        public string Title;
        public string Description;
        public Items(string title, string description)
        {
            Title = title;
            Description = description;
        }

        #region ItemInteractions
        public static void MyInventory(Avatar avatarInfos)
        {
            if (avatarInfos.Inventory.Count > 0)
            {
                foreach (var i in avatarInfos.Inventory)
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
            Items foundItem = location.Items.Find(x => x.Title.Contains(words));
            if (foundItem != null)
            {
                Console.WriteLine("Found: " + foundItem.Title);
            }
            else
            {
                ConsoleOutput.NotExistingItem();
            }
            if (location.Items.Count > 0)
            {
                location.Items.Remove(foundItem);
                avatarInfos.Inventory.Add(foundItem);
            }
            else
            {
                Console.WriteLine("There are no items in this room!");
            }
        }
        public static void DropItem(Location location, string words, Avatar avatarInfos)
        {
            Items foundItem = avatarInfos.Inventory.Find(x => x.Title.Contains(words));
            if (foundItem == null)
            {
                ConsoleOutput.NotExistingItem();
            }
            if (avatarInfos.Inventory.Count > 0)
            {
                avatarInfos.Inventory.RemoveAll(x => x.Title == words);
                location.Items.Add(foundItem);
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
                foreach (var item in enemyInfos.Inventory)
                {
                    location.Items.Add(item);
                }
                Console.WriteLine("Look there!! Your enemy dropped some items!");
                Console.WriteLine("_______________________________________________________________________________________________________________________________________________________________");
            }
        }
        #endregion
    }
}