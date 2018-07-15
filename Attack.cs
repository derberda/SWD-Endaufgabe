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
                    Console.WriteLine("health Enemy: " + enemyInfos.Health);
                    Console.WriteLine("health Avatar: " + avatarInfos.Health);
                }
                else if (words != enemyInfos.Name)
                {
                    avatarInfos.Health = avatarInfos.Health - RandomNumber.AttackEnemyValue();
                    enemyInfos.Health = enemyInfos.Health - RandomNumber.AttackPlayerValue();
                    Console.WriteLine("health Avatar: " + avatarInfos.Health);
                    Console.WriteLine("health Enemy: " + enemyInfos.Health);
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
                    ItemInteraction.dropLoot(location, enemyInfos);
                    break;
                }
            }
        }
       
    }
}