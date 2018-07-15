using System;
using System.Collections.Generic;

namespace swd_projekt
{
    class Character
    {
        public string Name;
        public int Health;
        public bool Dead;
        public List<Items> inventory = new List<Items>();
    }

    class Avatar : Character
    {
        public int playerLocation;
        public Avatar(int _health)
        {
            Health = _health;
        }
        public static Avatar AvatarSetUp()
        {
            Avatar avatar = new Avatar(
                100
            );
            return avatar;
        }
        public int AvatarCurrentLocation(Location location, Avatar avatarInfos, Enemy enemyInfos)
        {
            playerLocation = location.RoomNumber;
            ConsoleOutput.DescribeRoom(location);
            Enemy.EnemyRandomLocation(enemyInfos);

            RoomInteraction.RoomCheck(avatarInfos, enemyInfos);
            Win.checkWin(location, avatarInfos);

            return playerLocation;
        }
    }
    class Enemy : Character
    {
        public static int randomLocation = 1;
        public Enemy(string _name, int _health, bool _dead)
        {
            Name = _name;
            Health = _health;
            Dead = _dead;
        }
        public static Enemy EnemySetUp()
        {
            Enemy shopkeeper = new Enemy(
                "shopkeeper",
                100,
                false
            );
            Items money = new Items("money", "It's raining money yeah!!");
            shopkeeper.inventory.Add(money);

            return shopkeeper;
        }
        public static void EnemyRandomLocation(Enemy enemy)
        {
            if (enemy.Dead == false)
            {
                Random rnd = new Random();
                double randomRoomNumber = rnd.NextDouble();
                randomRoomNumber = ((randomRoomNumber * (3.0 - 2.0)) + 2.0);
                if (randomRoomNumber > 1.49)
                {
                    Math.Ceiling(randomRoomNumber);
                }
                else
                {
                    Math.Floor(randomRoomNumber);
                }
                int NewrandomRoomNumber = Convert.ToInt32(randomRoomNumber);
                Enemy.randomLocation = NewrandomRoomNumber;
            }
        }
    }
}