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
            
            ConsoleOutput.Introduction();
            ConsoleOutput.DescribeRoom(currentRoom);

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
                                ConsoleOutput.ChooseItem();
                            }
                            else
                            {
                                ItemInteraction.TakeItem(currentRoom, words[1], avatarInfos);
                            }
                        }
                        catch
                        {
                            ConsoleOutput.FalseItemInput(words[0]);
                        }
                        break;
                    case "drop":
                    case "d":
                        try
                        {
                            if (words[1] == "")
                            {
                                ConsoleOutput.ChooseItem();
                            }
                            else
                            {
                                ItemInteraction.DropItem(currentRoom, words[1], avatarInfos);
                            }
                        }
                        catch
                        {
                            ConsoleOutput.FalseItemInput(words[0]);
                        }
                        break;
                    case "inventory":
                    case "i":
                        ItemInteraction.MyInventory(avatarInfos);
                        break;
                    case "look":
                    case "l":
                        RoomInteraction.LookThroughRoom(currentRoom);
                        break;
                    case "attack":
                    case "a":
                        if (avatarInfos.playerLocation == Enemy.randomLocation)
                        {
                            try
                            {
                                if (Controls.words[1] == "")
                                {
                                    Console.WriteLine("You've made a wrong decision.\nThis enemy does not exist!");

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
    }
}