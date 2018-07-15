using System;
using System.Collections.Generic;

namespace swd_projekt
{
    class Controls
    {
        public static string[] Words;
        public static Location CurrentRoom = Location.MapSetUp();
        public static Array SplitInput()
        {
            string _input = Console.ReadLine();
            Words = _input.Split(' ');

            return Words;
        }
        public static void GameControls()
        {
            Enemy enemyInfos = Enemy.EnemySetUp();
            Avatar avatarInfos = Avatar.AvatarSetUp();

            ConsoleOutput.Introduction();
            ConsoleOutput.DescribeRoom(CurrentRoom);

            for (; ; )
            {
                SplitInput();
                switch (Words[0])
                {
                    case "north":
                    case "n":
                        RoomDirection(Words[0], avatarInfos, enemyInfos);
                        break;
                    case "east":
                    case "e":
                        RoomDirection(Words[0], avatarInfos, enemyInfos);
                        break;
                    case "south":
                    case "s":
                        RoomDirection(Words[0], avatarInfos, enemyInfos);
                        break;
                    case "west":
                    case "w":
                        RoomDirection(Words[0], avatarInfos, enemyInfos);
                        break;
                    case "take":
                    case "t":
                        try
                        {
                            if (Words[1] == "")
                            {
                                ConsoleOutput.ChooseItem();
                            }
                            else
                            {
                                Items.TakeItem(CurrentRoom, Words[1], avatarInfos);
                            }
                        }
                        catch
                        {
                            ConsoleOutput.FalseItemInput(Words[0]);
                        }
                        break;
                    case "drop":
                    case "d":
                        try
                        {
                            if (Words[1] == "")
                            {
                                ConsoleOutput.ChooseItem();
                            }
                            else
                            {
                                Items.DropItem(CurrentRoom, Words[1], avatarInfos);
                            }
                        }
                        catch
                        {
                            ConsoleOutput.FalseItemInput(Words[0]);
                        }
                        break;
                    case "inventory":
                    case "i":
                        Items.MyInventory(avatarInfos);
                        break;
                    case "look":
                    case "l":
                        Location.LookThroughRoom(CurrentRoom);
                        break;
                    case "attack":
                    case "a":
                        if (avatarInfos.PlayerLocation == Enemy.RandomLocation)
                        {
                            try
                            {
                                if (Controls.Words[1] == "" || Controls.Words[1] != enemyInfos.Name)
                                {
                                    Console.WriteLine("You've made a wrong decision.\nThis enemy does not exist!");
                                }
                                Attack.Fight(CurrentRoom, Controls.Words[1], avatarInfos, enemyInfos);
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
                        Console.WriteLine("commands(c), look(l), inventory(i), take(t) item, drop(d) item, attack(a) enemy, quit(q)");
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
                direction = CurrentRoom.North;
            }
            else if (words == "e" || words == "east")
            {
                direction = CurrentRoom.East;
            }
            else if (words == "s" || words == "south")
            {
                direction = CurrentRoom.South;
            }
            else if (words == "w" || words == "west")
            {
                direction = CurrentRoom.West;
            }
            if (direction != null)
            {
                CurrentRoom = direction;
                avatarInfos.AvatarCurrentLocation(CurrentRoom, avatarInfos, enemyInfos);
            }
            else
            {
                Console.WriteLine("There is no way! Choose another one!");
            }
            return CurrentRoom;
        }
    }
}