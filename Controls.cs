using System;
using System.Collections.Generic;

namespace swd_projekt
{
    class Controls
    {
        public static string[] words;

        public static Location currentRoom = Location.MapSetUp();

        public static Array SplitInput()
        {
            string _input = Console.ReadLine();
            words = _input.Split(' ');
            return words;
        }
        public static void GameControls()
        {
            Enemy enemyInfos = Enemy.EnemySetUp();
            Avatar avatarInfos = Avatar.AvatarSetUp();
            
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Welcome to Nashville. You run away from home and homeless now. But you have to go on and you didn't eat anything in th last times. Maybe you can borrow something from the supermarket");
            Console.ResetColor(); 
            Location.DescribeRoom(currentRoom);

            for (; ; )
            {
                 
                SplitInput();

                switch (words[0])
                {
                    case "north":
                    case "n":
                        RoomDirection(words[0], avatarInfos, enemyInfos);
                        break;
                    case "east":
                    case "e":
                        RoomDirection(words[0], avatarInfos, enemyInfos);
                        break;
                    case "south":
                    case "s":
                        RoomDirection(words[0], avatarInfos, enemyInfos);
                        break;
                    case "west":
                    case "w":
                        RoomDirection(words[0], avatarInfos, enemyInfos);
                        break;
                    case "take":
                    case "t":
                        try
                        {
                            if (words[1] == "")
                            {
                                Console.WriteLine("You have to choose an item!");
                            }
                            else
                            {
                                TakeItem(words[1], currentRoom, avatarInfos);
                            }
                        }
                        catch
                        {
                            Console.WriteLine("I don't understand this input :/ Please write it like this: t/take + itemname.");
                        }
                        break;
                    case "drop":
                    case "d":
                        try
                        {
                            if (words[1] == "")
                            {
                                Console.WriteLine("You have to choose an item!");
                            }
                            else
                            {
                                DropItem(words[1], currentRoom, avatarInfos);
                            }
                        }
                        catch
                        {
                            Console.WriteLine("I don't understand this input :/ Please write it like this: t/take + itemname.");
                        }
                        break;
                    case "inventory":
                    case "i":
                        MyInventory(avatarInfos);
                        break;
                    case "look":
                    case "l":
                        Location.LookThroughRoom(currentRoom);
                        break;
                    case "attack":
                    case "a":
                        if (avatarInfos.playerLocation == Enemy.randomLocation)
                        {
                            try
                            {
                                if (Controls.words[1] == "")
                                {
                                    Console.WriteLine("You've made a wrong decision");
                                    Controls.words[1] = null;
                                }
                                Attack.Fight(currentRoom, Controls.words[1], avatarInfos, enemyInfos);
                            }
                            catch
                            {
                                Console.WriteLine("I don't understand this input :/ Please write it like this: a/attack + enemyname.");
                                Console.WriteLine("_______________________________________________________________________________________________________________________________________________________________");
                            }
                        }
                        else
                        {
                            Console.WriteLine("There's no one to attack!");
                        }
                        break;
                    case "commands":
                    case "c":
                        Console.WriteLine("commands(c), look(l), inventory(i), take(t) item, drop(d) item, quit(q)");
                        break;
                    case "quit":
                    case "q":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("You cant use this button. Use another one. If you don't know the Controls press c!");
                        Console.ResetColor();
                        break;
                }
            }
        }
        public static Location RoomDirection(string words, Avatar avatarInfos, Enemy enemyInfos)
        {
            Location direction = null;
            if (words == "n" || words == "north")
            {
                direction = currentRoom.North;
            }
            else if (words == "e" || words == "east")
            {
                direction = currentRoom.East;
            }
            else if (words == "s" || words == "south")
            {
                direction = currentRoom.South;
            }
            else if (words == "w" || words == "west")
            {
                direction = currentRoom.West;
            }
            if (direction != null)
            {
                currentRoom = direction;
                avatarInfos.AvatarCurrentLocation(currentRoom, avatarInfos, enemyInfos);
            }
            else
            {
                Console.WriteLine("There is no way! Choose another one!");
            }
            return currentRoom;
        }

        public static void TakeItem(string words, Location location, Avatar avatarInfos)
        {
            Items foundItem = location.items.Find(x => x.Title.Contains(words));
            if (foundItem != null)
            {
                Console.WriteLine("Found: " + foundItem.Title);
            }
            else
            {
                Console.WriteLine("This item does not exist!");
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
                Console.WriteLine("Your bag is empty!");
            }
        }

        public static void DropItem(string words, Location location, Avatar avatarInfos)
        {
            if (avatarInfos.inventory.Count > 0)
            {
                Items foundItem = avatarInfos.inventory.Find(x => x.Title.Contains(words));
                location.items.Find(x => x.Title.Contains(words));
                avatarInfos.inventory.RemoveAll(x => x.Title == words);
                location.items.Add(foundItem);
                MyInventory(avatarInfos);
            }
            else
            {
                Console.WriteLine("There is nothing in your bag.");
            }
        }
    }
}