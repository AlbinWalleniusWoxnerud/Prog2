using System;
using System.Threading;
using Library.Entities;
using Rooms;
using Text;

namespace Library
{
    public class PlayerDeathEventArgs : EventArgs
    {
        public DateTime TimeOfDeath { get; private set; }

        public PlayerDeathEventArgs()
        {
            TimeOfDeath = DateTime.Now;
        }
    }
    public class EnemyDeathEventArgs : EventArgs
    {
        public DateTime TimeOfDeath { get; private set; }
        public EntityType DeadEnemyType { get; init; }

        public EnemyDeathEventArgs(EntityType e)
        {
            TimeOfDeath = DateTime.Now;
            DeadEnemyType = e;
        }
    }
    internal class Methods
    {
        //Self explanatory
        // internal static bool IsGameOver(Player player, CurrentRun run)
        // {
        //     //The game is over if the player is dead or if the maze is conquered
        //     if (player._alive == false || player.health <= 0)
        //     {
        //         return true;
        //     }
        //     if (run.conquered == true) return true;
        //     return false;
        // }

        internal static void InitRoom(Player player, RoomFlags[] rooms, CurrentRun currentRun)
        {
            //Really just a switch made into a method to make the code less cluttered
            //Based on current room get that room
            switch (currentRun.currentRoom)
            {
                case 1:
                    Room_1 room1 = new(player, rooms[0], currentRun);
                    break;
                case 2:
                    Room_2 room2 = new(player, rooms[1], currentRun);
                    break;
                case 3:
                    Room_3 room3 = new(player, rooms[2], currentRun);
                    break;
                case 4:
                    Room_4 room4 = new(player, rooms[3], currentRun);
                    break;
                case 5:
                    Room_5 room5 = new(player, rooms[4], currentRun);
                    break;
                case 6:
                    Room_6 room6 = new(player, rooms[5], currentRun);
                    break;
                case 7:
                    Room_7 room7 = new(player, rooms[6], currentRun);
                    break;
                case 8:
                    Room_8 room8 = new(player, rooms[7], currentRun);
                    break;
                case 9:
                    Room_9 room9 = new(player, rooms[8], currentRun);
                    break;
            }
        }
    }
}