using System;
using System.Collections.Generic;

namespace swd_projekt
{
    class RandomNumber
    {
        static Random Rnd = new Random();
        public static int AttackPlayerValue()
        {
            int attackPlayer = Rnd.Next(0, 13);

            return attackPlayer;
        }
        public static int AttackEnemyValue()
        {
            int attackEnemy = Rnd.Next(0, 10);

            return attackEnemy;
        }
        public static void EnemyRandomLocation(Enemy enemy)
        {
            if (enemy.Dead == false)
            {
                double randomRoomNumber = Rnd.NextDouble();
                randomRoomNumber = ((randomRoomNumber * (3.0 - 2.0)) + 2.0);
               
                int NewrandomRoomNumber = Convert.ToInt32(randomRoomNumber);
                Enemy.RandomLocation = NewrandomRoomNumber;
            }
        }
    }
}