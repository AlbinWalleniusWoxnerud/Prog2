using System;
using System.Threading;
using Library.Entities;
using Rooms;

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
        //Check if the player want to play another game
        // internal static void IsPlayAgain()
        // {
        //     SlowRPGWrite("Would you like to play again?");
        //     int input = TextRender.Table("Menu:", "Play again.. End game.".Split(". "));
        //     switch (input)
        //     {
        //         case 1:
        //             StaticPlayer.Reset();
        //             StaticEnemies.Reset();
        //             GameLogic.Reset();
        //             StaticRoom.Reset();
        //             break;
        //         case 2:
        //             GameLogic.playAgain = false;
        //             break;
        //     }

        // }

        //Self explanatory
        internal static bool IsGameOver(Player player, CurrentRun run)
        {
            //The game is over if the player is dead or if the maze is conquered
            if (player._alive == false || player._health <= 0)
            {
                return true;
            }
            if (run.conquered == true) return true;
            return false;
        }

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
                    // case 3:
                    //     Room3Methods.Room3();
                    //     break;
                    // case 4:
                    //     Room4Methods.Room4();
                    //     break;
                    // case 5:
                    //     Room5Methods.Room5();
                    //     break;
                    // case 6:
                    //     Room6Methods.Room6();
                    //     break;
                    // case 7:
                    //     Room7Methods.Room7();
                    //     break;
                    // case 8:
                    //     Room8Methods.Room8();
                    //     break;
                    // case 9:
                    //     Room9Methods.Room9();
                    // break;
            }
        }
    }
}