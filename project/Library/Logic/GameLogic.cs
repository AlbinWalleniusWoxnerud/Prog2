using System;
using System.Threading;
using Library.Entities;

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

        // internal static void InitRoom(Player player, Room[] rooms, int currentRoom)
        // {
        //     //Really just a switch made into a method to make the code less cluttered
        //     //Based on current room get that room
        //     switch (currentRoom)
        //     {
        //         case 1:
        //             Rooms.Room1.Room(player, rooms[0]);
        //             break;
        //         case 2:
        //             Rooms.Room2.Room(player, rooms[1]);
        //             break;
        //             // case 3:
        //             //     Room3Methods.Room3();
        //             //     break;
        //             // case 4:
        //             //     Room4Methods.Room4();
        //             //     break;
        //             // case 5:
        //             //     Room5Methods.Room5();
        //             //     break;
        //             // case 6:
        //             //     Room6Methods.Room6();
        //             //     break;
        //             // case 7:
        //             //     Room7Methods.Room7();
        //             //     break;
        //             // case 8:
        //             //     Room8Methods.Room8();
        //             //     break;
        //             // case 9:
        //             //     Room9Methods.Room9();
        //             // break;
        //     }
        // }
    }
}