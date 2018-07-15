using System;
using System.Collections.Generic;

namespace swd_projekt
{
    class RandomNumber
    {
        static Random Rnd = new Random();
        public static int AttackPlayerValue()
        {
            int attackPlayer = Rnd.Next(0, 15);
            return attackPlayer;
        }
        public static int AttackEnemyValue()
        {
            int attackEnemy = Rnd.Next(0, 10);
            return attackEnemy;
        }
    }
}