using System;
using System.Collections.Generic;

namespace swd_projekt
{
    class Character
    {
        public string Name;
        public int Health;
        public bool Dead;
        public List<Items> Inventory = new List<Items>();
    }

    class Avatar : Character
    {
        public int PlayerLocation;
        public Avatar(int health)
        {
            Health = health;
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
            PlayerLocation = location.RoomNumber;
            ConsoleOutput.DescribeRoom(location);
            RandomNumber.EnemyRandomLocation(enemyInfos);

            Location.RoomCheck(avatarInfos, enemyInfos);
            WinCondition.CheckWin(location, avatarInfos);

            return PlayerLocation;
        }
    }
    class Enemy : Character
    {
        public static int RandomLocation = 1;
        public Enemy(string name, int health, bool dead)
        {
            Name = name;
            Health = health;
            Dead = dead;
        }
        public static Enemy EnemySetUp()
        {
            Enemy shopkeeper = new Enemy(
                "shopkeeper",
                100,
                false
            );
            Items money = new Items("money", "It's raining money yeah!!");
            shopkeeper.Inventory.Add(money);

            return shopkeeper;
        }
    }
}