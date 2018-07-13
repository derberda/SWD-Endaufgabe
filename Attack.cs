using System;
using System.Collections.Generic;

namespace swd_projekt
{
    class Attack
    {
        public static void Fight(Location location, string words, Avatar avatarInfos, Enemy enemyInfos)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Enemy health: " + enemyInfos.Health + " , Avatar health: " + avatarInfos.Health);
            for (; ; )
            {
                if (words == enemyInfos.Name)
                {
                    enemyInfos.Health = enemyInfos.Health - RandomNumber.AttackPlayerValue();
                    avatarInfos.Health = avatarInfos.Health - RandomNumber.AttackEnemyValue();
                    Console.WriteLine("Kampf health Enemy: " + enemyInfos.Health);
                    Console.WriteLine("Kampf health Avatar: " + avatarInfos.Health);
                }
                else if (words != enemyInfos.Name)
                {
                    Console.WriteLine("This enemy does not exist! ");
                    avatarInfos.Health = avatarInfos.Health - RandomNumber.AttackEnemyValue();
                    enemyInfos.Health = enemyInfos.Health - RandomNumber.AttackPlayerValue();
                    Console.WriteLine("Kampf health Avatar: " + avatarInfos.Health);
                    Console.WriteLine("Kampf health Enemy: " + enemyInfos.Health);
                }
                if (avatarInfos.Health < 0)
                {
                    Console.WriteLine("You're dead - GAME OVER!");
                    Console.ResetColor();
                    Environment.Exit(0);
                    break;
                }
                if (enemyInfos.Health < 0)
                {
                    enemyInfos.Dead = true;
                    Enemy.randomLocation = -1;
                    Console.ResetColor();
                    Console.WriteLine("Yeah you killed him. He has a wife and children - you're a MONSTER :(!!");
                    dropLoot(location, enemyInfos);
                    break;
                }
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