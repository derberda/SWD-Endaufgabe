using System;
using System.Collections.Generic;

namespace swd_projekt
{
    class RandomNumber
    {
        static Random rnd = new Random();
        public static int AttackPlayerValue()
        {
            int attackPlayer = rnd.Next(0, 15);
            return attackPlayer;
        }
        public static int AttackEnemyValue()
        {
            int attackEnemy = rnd.Next(0, 10);
            return attackEnemy;
        }
    }
}