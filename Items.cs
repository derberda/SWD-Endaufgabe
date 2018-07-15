using System;
using System.Collections.Generic;

namespace swd_projekt
{
    class Items
    {
        public string Title;
        public string Description;
        public Items (string title, string description)
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
            if (foundItem != null && location.Items.Count > 0)
            {
                Console.WriteLine("Found: " + foundItem.Title);
                 location.Items.Remove(foundItem);
                avatarInfos.Inventory.Add(foundItem);
            }
            else
            {
                ConsoleOutput.NotExistingItem();
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
        public static void DropLoot(Location location, Enemy enemyInfos)
        {
            if (enemyInfos.Dead == true)
            {
                foreach (var i in enemyInfos.Inventory)
                {
                    location.Items.Add(i);
                }
                Console.WriteLine("Look there!! Your enemy dropped some items!");
                Console.WriteLine("_______________________________________________________________________________________________________________________________________________________________");
            }
        }
        #endregion
    }
}